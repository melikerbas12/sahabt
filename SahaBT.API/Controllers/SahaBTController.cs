using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SahaBT.Entities.Shared.ResultModel;
using SahaBT.Service.Abstract;
using SahaBT.Shared.Model;
using SahaBT.Shared.Model.ResultModel;
using SahaBT.Shared.Model.ViewModel;
using SahaBT.Shared.Pagination;
using System.Threading.Tasks;
using SahaBT.Service.Utilities.Filter;

namespace SahaBT.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SahaBTController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<SahaBTController> _logger;
        public SahaBTController(IStudentService studentService, ILogger<SahaBTController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post(StudentLessonAddModel model)
        {
            var response = await _studentService.Create(model);
            return Ok(response);
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Update(StudentLessonUpdateModel model)
        {
            var response = await _studentService.Update(model);
            return Ok(response);
        }

        [HttpDelete("{studentId}")]
        public async Task<ActionResult<ResponseModel>> Delete(int studentId)
        {
            var response = await _studentService.Delete(studentId);
            return Ok(response);
        }

        [ValidationFilter]
        [HttpPost]
        public ActionResult<StudentsResponseModel> Get(PagingParameters model)
        {
            var response =  _studentService.GetStudents(model);
            return Ok(response);
          //  _distributedCache.add


        }

        [HttpGet("{lessonCode}")]
        public ActionResult<StudentsByLessonCodeResponseModel> GetByLessonCode(string lessonCode)
        {
            var response = _studentService.GetStudentsByLessonCode(lessonCode);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<TotalStudentCountResponseModel> GetCount()
        {
            var response = _studentService.GetStudentCount();
            return Ok(response);
        }

        [HttpGet]
        public ActionResult LogTest()
        {
            try
            {
                int number1 = 3000;
                int number2 = 0;
                var a = number1 / number2;
                return new ObjectResult(new
                {
                    message = string.Empty
                })
                { StatusCode = StatusCodes.Status200OK };
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.ToString());
                return new ObjectResult(new
                {
                    message = $"Hata loglandı!"
                })
                { StatusCode = StatusCodes.Status500InternalServerError };
            }

        }
    }
}
