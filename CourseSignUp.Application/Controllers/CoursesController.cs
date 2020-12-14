using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using CourseSignUp.Domain.ViewModel;
using CourseSignUp.Services.Interfaces;
using CourseSignUp.Domain.Model;
using System.Net.Http;

namespace CourseSignUp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        //private readonly ICoursesAppService _CoursesAppService;
        private readonly ILogger _Logger;
        private readonly ICourseSignUpService _CourseService;

        public CoursesController(ICourseSignUpService courseService, ILogger<CoursesController> logger)
        {
            _CourseService = courseService;
            _Logger = logger;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_CourseService.GetAll());
            }
            catch (HttpRequestException ex)
{
                _Logger.LogError(ex, "[CoursesController.GetAll] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {                
                _Logger.LogError(ex, "[CoursesController.GetAll] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                return Ok(_CourseService.Get(id));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetId] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetId] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetId] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CourseViewModel course)
        {
            try
            {
                //Mapper CourseViewModel => CourseModel
                return Ok(_CourseService.Create(new CourseModel()));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] CourseViewModel course)
        {
            try
            {
                //Mapper CourseViewModel => CourseModel
                return Ok(_CourseService.Update(new CourseModel()));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                return Ok(_CourseService.Delete(id));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetAll] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
