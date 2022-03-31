using KetCRM.Application;
using KetCRM.Application.StudentInfoBl.Queries;
using KetCRM.Application.StudentInfoBl.Commands.CreateStudentInfo;
using KetCRM.Application.StudentInfoBl.Commands.DeleteStudentInfo;
using KetCRM.Application.StudentInfoBl.Commands.UpdateStudentInfo;
using KetCRM.WebApi.Models.StudentInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KetCRM.Application.StudentInfoBl.Queries.GetStudentInfoList;

namespace KetCRM.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentInfoController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public StudentInfoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<StudentInfoItemDto>> GetOne(int id)
        {
            var query = new GetStudentInfoQuery() { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<StudentInfoListVm>> GetAll()
        {
            var query = new GetStudentInfoListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<int>>Create([FromBody]CreateStudentInfoDto createStudentInfo)
        {
            var command = _mapper.Map<CreateStudentInfoCommand>(createStudentInfo);
            var studentinfoId = await Mediator.Send(command);
            return Ok(studentinfoId);
        }
        [HttpPut]
        public async Task<ActionResult<int>>Update([FromBody]UpdateStudentInfoDto updateStudentInfo)
        {
            var command = _mapper.Map<UpdateStudentInfoCommand>(updateStudentInfo);
            var studentinfoId = await Mediator.Send(command);
            return Ok(studentinfoId);
        }
        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var command = new DeleteStudentInfoCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
