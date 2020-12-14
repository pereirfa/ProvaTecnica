using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using CourseSignUp.Domain.ViewModel;
using CourseSignUp.Services.Interfaces;
using CourseSignUp.Domain.Model;
using System.Net.Http;


namespace CourseSignUp.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        //private readonly ICoursesAppService _CoursesAppService;
        private readonly ILogger _Logger;
        private readonly IStatisticsService _StatisticsService;

        public StatisticsController(IStatisticsService statisticService, ILogger<StatisticsController> logger)
        {
            _StatisticsService = statisticService;
            _Logger = logger;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_StatisticsService.GetAll());
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[StatisticsController.GetAll] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[StatisticsController.GetAll] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[StatisticsController.GetAll] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                return Ok(_StatisticsService.Get(id));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[StatisticsController.GetId] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[StatisticsController.GetId] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[StatisticsController.GetId] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}


