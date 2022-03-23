using KetCRM.Application;
using KetCRM.Application.PersonBl.Queries.GetPersonList;
using KetCRM.Application.PersonBl.Commands.CreatePerson;
using KetCRM.WebApi.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;



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
        [HttpPost]
        public async Task<ActionResult<int>>Create([FromBody] CreatePersonDto createPerson)
        {
            var command = _mapper.Map<CreatePersonCommand>(createPerson);
            var personId = await Mediator.Send(command);
            return Ok(personId);
        }
    }
}
