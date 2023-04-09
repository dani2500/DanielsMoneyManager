using DanielsMoneyManagerApi.Data;
using DanielsMoneyManagerApi.Dtos;
using DanielsMoneyManagerApi.Helpers;
using DanielsMoneyManagerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DanielsMoneyManagerApi.Controllers
{
    [Authorize]
    [Route("api/cash_actions")]
    [ApiController]
    public class CashActionsController : ControllerBase
    {
        private readonly ICashActionsRepository _cashActionsRepo;
        private readonly ICategoriesRepository _categoriesRepo;
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;


        public CashActionsController(JwtService jwtService, ICashActionsRepository cashActionsRepo, ICategoriesRepository categoriesRepo, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _cashActionsRepo = cashActionsRepo;
            _categoriesRepo = categoriesRepo;
            _userRepository = userRepository;
        }

        [HttpGet("cash_actions")]
        public IActionResult GetCashActions([FromQuery] CashActionsGetRequestDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            List<CashAction> cashActions = _cashActionsRepo.GetCashActions(dto.fromTime, dto.toTime, dto.categoryId, userId);
            List<CashActionDto> result = new List<CashActionDto>();

            foreach(var ca in cashActions)
            {
                result.Add(new CashActionDto
                {
                    cashActionId = ca.Cash_Action_ID,
                    cashActionTime = ca.Cash_Action_Time,
                    categoryId = ca.Category_ID,
                    description = ca.Description,
                    sum = ca.Sum,
                    insertTime = ca.Insert_Time,
                    updateTime = ca.Update_Time
                });
            }

            return Ok(result);
        }

        [HttpPost("cash_actions")]
        public IActionResult InsertCashActions(CashActionInsertDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            User userByCategory = _userRepository.GetUserByCategoryId(dto.categoryId);
            if (userId != userByCategory.User_ID)
            {
                return Unauthorized();
            }

            CashAction ca = _cashActionsRepo.InsertCashActions(dto.categoryId, dto.description, dto.sum, dto.cashActionTime);

            CashActionDto result = new CashActionDto
                {
                    cashActionId = ca.Cash_Action_ID,
                    cashActionTime = ca.Cash_Action_Time,
                    categoryId = ca.Category_ID,
                    description = ca.Description,
                    sum = ca.Sum,
                    insertTime = ca.Insert_Time,
                    updateTime = ca.Update_Time
                };

            return Ok(result);
        }

        [HttpPut("cash_actions")]
        public IActionResult UpdateCashActions(CashActionUpdateDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            User userByCashAction = _userRepository.GetUserByCashActionId(dto.cashActionId);

            if (userId != userByCashAction.User_ID)
            {
                return Unauthorized();
            }

            _cashActionsRepo.UpdateCashActions(dto.cashActionId, dto.categoryId, dto.description, dto.sum, dto.cashActionTime);
            return Ok();
        }

        [HttpDelete("cash_actions")]
        public IActionResult DeleteCashActions(CashActionDeleteDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            _cashActionsRepo.DeleteCashActions(dto.cashActionIds, userId);
            return Ok();
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            List<Category> categories = _categoriesRepo.GetCategories(userId);

            List<CategoryDto> result = categories.Select(x => new CategoryDto
            {
                categoryId = x.Category_ID,
                categoryName = x.Category_Name
            }).ToList();

            return Ok(result);
        }

        [HttpPost("categories")]
        public IActionResult InsertCategory(CategoryInsertDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            Category category = null;

            category = _categoriesRepo.GetCategoryByName(userId, dto.categoryName);

            if (category != null) 
            {
                return Conflict();
            }

            category = _categoriesRepo.InsertCategory(userId, dto.categoryName);

            CategoryDto result = new CategoryDto
            {
                categoryId = category.Category_ID,
                categoryName = category.Category_Name
            };

            return Ok(result);
        }


        [HttpPut("categories")]
        public IActionResult UpdateCategory(CategoryDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            Category targetCategory = _categoriesRepo.GetCategoryById(dto.categoryId);
            if (userId != targetCategory.User_ID)
            {
                return Unauthorized();
            }

            Category sameCategory = _categoriesRepo.GetCategoryByName(userId, dto.categoryName);
            if (sameCategory != null)
            {
                return Conflict();
            }

            _categoriesRepo.UpdateCategory(dto.categoryId ,dto.categoryName);
            return Ok();
        }

        [HttpDelete("categories")]
        public IActionResult DeleteCategories(CategoryDeleteDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            Category targetCategory = _categoriesRepo.GetCategoryById(dto.categoryId);
            if (userId != targetCategory.User_ID)
            {
                return Unauthorized();
            }

            _categoriesRepo.DeleteCategory(dto.categoryId);
            return Ok();
        }

        [HttpGet("balances")]
        public IActionResult GetBalances([FromQuery] BalancesRequestDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            List<CategoryBalance> balances = _cashActionsRepo.GetBalances(userId, dto.toTime);
            List<BalancesResponseDto> result = new List<BalancesResponseDto>();

            foreach (var item in balances)
            {
                result.Add(new BalancesResponseDto
                {
                    categoryId = item.Category_ID,
                    categoryBalance = item.Category_Balance,
                    cashActionsCount = item.Cash_Actions_Count
                });
            }

            return Ok(result);
        }

        [HttpGet("total_balance")]
        public IActionResult GetTotalBalance([FromQuery] BalancesRequestDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            TotalBalance balance = _cashActionsRepo.GetTotalBalance(userId, dto.toTime);

            TotalBalanceDto result = new TotalBalanceDto
            {
                totalBalance = balance.Total_Balance
            };

            return Ok(result);
        }

    }
}
