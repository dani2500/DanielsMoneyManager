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
        private readonly IUserRepository _userRepository;
        private readonly IFundActionsRepository _fundActionsRepository;

        private readonly JwtService _jwtService;


        public FundsController(JwtService jwtService, IFundsRepository fundsRepository, IUserRepository userRepository, IFundActionsRepository fundActionsRepository)
        {
            _jwtService = jwtService;
            _fundsRepository = fundsRepository;
            _userRepository = userRepository;
            _fundActionsRepository = fundActionsRepository;
        }

        #region funds

        [HttpGet("funds")]
        public IActionResult GetFunds()
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            List<Fund> funds = _fundsRepository.GetFunds(userId);

            List<FundDto> result = funds.Select(x => new FundDto
            {
                fundId = x.Fund_ID,
                fundName = x.Fund_Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet("status")]
        public IActionResult GetFundsStatus([FromQuery] FundsStatusRequestDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            List<FundStatus> statuses = _fundsRepository.GetFundsStatus(userId, dto.toTime);

            List<FundsStatusResponseDto> result = statuses.Select(x => new FundsStatusResponseDto
            {
                fundId = x.Fund_ID,
                firstInvestmentDate = x.First_Investment_Date,
                lastInvestmentDate = x.Last_Investment_Date,
                investedSum = x.Invested_Sum,
                actualSum = x.Actual_Sum,
                profit = x.Profit
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

        #endregion


        #region fund actions

        [HttpGet("fund_actions")]
        public IActionResult GetFundActions([FromQuery] FundActionsGetRequestDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            List<FundAction> FundActions = _fundActionsRepository.GetFundActions(dto.fromTime, dto.toTime, dto.fundId, userId);
            List<FundActionDto> result = new List<FundActionDto>();

            foreach (var fa in FundActions)
            {
                result.Add(new FundActionDto
                {
                    fundActionId = fa.Fund_Action_ID,
                    fundId = fa.Fund_ID,
                    investmentSum = fa.Investment_Sum,
                    investmentDate = fa.Investment_Date,
                    currentState = fa.Current_State,
                    note = fa.Note,
                });
            }

            return Ok(result);
        }

        [HttpPost("fund_actions")]
        public IActionResult InsertFundActions(FundActionInsertDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            User userByFund = _userRepository.GetUserByFundId(dto.fundId);
            if (userId != userByFund.User_ID)
            {
                return Unauthorized();
            }

            FundAction fa = _fundActionsRepository.InsertFundActions(fundId: dto.fundId, investmentSum: dto.investmentSum, currentState: dto.currentState, note: dto.note, investmentDate: dto.investmentDate);

            FundActionDto result = new FundActionDto
            {
                fundActionId = fa.Fund_Action_ID,
                fundId = fa.Fund_ID,
                investmentSum = fa.Investment_Sum,
                investmentDate = fa.Investment_Date,
                currentState = fa.Current_State,
                note = fa.Note,
            };

            return Ok(result);
        }

        [HttpPut("fund_actions")]
        public IActionResult UpdateFundActions(FundActionUpdateDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            User userByFund = _userRepository.GetUserByFundId(dto.fundId);

            if (userId != userByFund.User_ID)
            {
                return Unauthorized();
            }

            _fundActionsRepository.UpdateFundActions(fundActionId: dto.fundActionId, fundId: dto.fundId, investmentSum: dto.investmentSum, currentState: dto.currentState, note: dto.note, investmentDate: dto.investmentDate);
            return Ok();
        }

        [HttpDelete("fund_actions")]
        public IActionResult DeleteFundActions(FundActionDeleteDto dto)
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            _fundActionsRepository.DeleteFundActions(dto.fundActionIds, userId);
            return Ok();
        }

        #endregion
    }
}
