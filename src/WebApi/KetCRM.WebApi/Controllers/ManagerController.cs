using KetCRM.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace KetCRM.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _managerService.GetAllUser());
        }
    }
}
