using KetCRM.Application.DTOs.Account;
using KetCRM.Application.Interfaces.Account;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KetCRM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request, GenerateIPAddress()));
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin));
        }
        [HttpGet("getAllUser")]
        public async Task<IActionResult> AuthenticateUserList()
        {
            return Ok(await _accountService.AuthenticateUserList());
        }
        [HttpDelete("deleteUser/{Id}")]
        public async Task<IActionResult> DeleteUser([Required] string Id)
        {
            return Ok(await _accountService.DeleteUser(Id));
        }
        [HttpGet("getUserById/{Id}")]
        public async Task<IActionResult> GetUserById([Required] string Id)
        {
            return Ok(await _accountService.GetUserById(Id));
        }
        [HttpPut("updateUserById/{Id}")]
        public async Task<IActionResult> UpdateUserById([Required] string Id, UserListDto dto)
        {
            return Ok(await _accountService.UpdateUserById(dto, Id));
        }
        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
