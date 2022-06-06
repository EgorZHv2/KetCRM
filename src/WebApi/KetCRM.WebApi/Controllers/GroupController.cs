using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KetCRM.Application.GroupBl.Queries.GetGroupList;

namespace KetCRM.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public GroupController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        
        public async Task<ActionResult<GroupListVM>> GetAll()
        {
            var query = new GetGroupListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
