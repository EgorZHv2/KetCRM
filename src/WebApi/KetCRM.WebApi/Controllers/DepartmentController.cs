using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace KetCRM.WebApi.Controllers
{
    public class DepartmentController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
