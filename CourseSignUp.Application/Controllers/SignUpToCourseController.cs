using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using CourseSignUp.Domain.ViewModel;
using CourseSignUp.Services.Interfaces;
using CourseSignUp.Domain.Model;
using System.Net.Http;

namespace CourseSignUp.Application.Controllers
{
    public class SignUpToCourseController : ControllerBase
    {
        //private readonly ICoursesAppService _CoursesAppService;
        private readonly ILogger _Logger;
        private readonly ISignUpToCourseService _CourseSignUPService;

        public SignUpToCourseController(ISignUpToCourseService courseSignUpService, ILogger<SignUpToCourseController> logger)
        {
            _CourseSignUPService = courseSignUpService;
            _Logger = logger;
        }


        [HttpPost]
        public ActionResult Post([FromBody] SignUpToCourseModel course)
        {
            try
            {
                //Mapper CourseViewModel => CourseModel
                return Ok(_CourseSignUPService.Create(new SignUpToCourseModel()));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[SignUpToCourseController.Post] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[SignUpToCourseController.Post] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[SignUpToCourseController.Post] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }



    }
}
