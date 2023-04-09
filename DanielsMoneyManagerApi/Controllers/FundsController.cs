using DanielsMoneyManagerApi.Data;
using DanielsMoneyManagerApi.Dtos;
using DanielsMoneyManagerApi.Helpers;
using DanielsMoneyManagerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DanielsMoneyManagerApi.Controllers
{
    [Authorize]
    [Route("api/funds")]
    [ApiController]
    public class FundsController : Controller
    {
        private readonly IFundsRepository _fundsRepository;
        private readonly JwtService _jwtService;


        public FundsController(JwtService jwtService, IFundsRepository fundsRepository)
        {
            _jwtService = jwtService;
            _fundsRepository = fundsRepository;
        }

        [HttpGet("funds")]
        public IActionResult GetFunds()
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            List<Fund> categories = _fundsRepository.GetFunds(userId);

            List<FundDto> result = categories.Select(x => new FundDto
            {
                fundId = x.Fund_ID,
                fundName = x.Fund_Name
            }).ToList();

            return Ok(result);
        }

        [HttpPost("funds")]
        public IActionResult InsertCategory(FundInsertDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            Fund fund = null;

            fund = _fundsRepository.GetFundByName(userId, dto.fundName);

            if (fund != null)
            {
                return Conflict();
            }

            fund = _fundsRepository.InsertFund(userId, dto.fundName);

            FundDto result = new FundDto
            {
                fundId = fund.Fund_ID,
                fundName = fund.Fund_Name
            };

            return Ok(result);
        }


        [HttpPut("funds")]
        public IActionResult UpdateCategory(FundDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            Fund targetFund = _fundsRepository.GetFundById(dto.fundId);
            if (userId != targetFund.User_ID)
            {
                return Unauthorized();
            }

            Fund sameFund = _fundsRepository.GetFundByName(userId, dto.fundName);
            if (sameFund != null)
            {
                return Conflict();
            }

            _fundsRepository.UpdateFund(dto.fundId, dto.fundName);
            return Ok();
        }

        [HttpDelete("funds")]
        public IActionResult DeleteCategories(FundDeleteDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            Fund targetFund = _fundsRepository.GetFundById(dto.fundId);
            if (userId != targetFund.User_ID)
            {
                return Unauthorized();
            }

            _fundsRepository.DeleteFund(dto.fundId);
            return Ok();
        }
    }
}
