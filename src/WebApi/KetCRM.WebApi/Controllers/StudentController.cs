using KetCRM.Application;
using KetCRM.Application.StudentBl.Queries;
using KetCRM.Application.StudentBl.Queries.GetStudentList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace KetCRM.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<StudentListVm>> GetAll()
        {
            var query = new GetStudentListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
