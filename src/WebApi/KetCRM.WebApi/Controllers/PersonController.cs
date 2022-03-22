using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KetCRM.Application.PersonBl.Queries.GetPersonList;


namespace KetCRM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PersonListVm>> GetAll()
        {
            var query = new GetPersonListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
