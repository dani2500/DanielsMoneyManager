using DanielsMoneyManagerApi.Data;
using DanielsMoneyManagerApi.Helpers;
using DanielsMoneyManagerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DanielsMoneyManagerApi.Controllers
{
    [Authorize]
    [Route("api/CashActions")]
    [ApiController]
    public class CashActionsController : ControllerBase
    {
        private readonly ICashActionsRepository _cashActionsRepo;
        private readonly JwtService _jwtService;


        public CashActionsController(JwtService jwtService, ICashActionsRepository cashActionsRepo)
        {
            _jwtService = jwtService;
            _cashActionsRepo = cashActionsRepo;
        }

        [HttpGet("")]
        [Authorize]
        public IActionResult GetCashActions()
        {
            int userId = _jwtService.GetUserId(HttpContext.User);

            //TODO paramtize
            DateTime fromTime = DateTime.UtcNow.AddYears(-1);
            DateTime toTime = DateTime.UtcNow;

            List<CashAction> cashActions = _cashActionsRepo.GetCashActions(userId, fromTime, toTime);

            return Ok(cashActions);
        }


    }
}
