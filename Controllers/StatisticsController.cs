using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CourseSignUP.Interfaces;
using CourseSignUP.DTO;


namespace CourseSignUP.Controllers
{
    [ApiController, Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsAppService _StatisticsAppService;
        private readonly ILogger _Logger;

        #region public StatisticsController(IStatisticsAppService _statisticsAppService, ILogger<StatisticsController> logger)
        public StatisticsController(IStatisticsAppService _statisticsAppService, ILogger<StatisticsController> logger)
        {
            _StatisticsAppService = _statisticsAppService;
            _Logger = logger;
        }
        #endregion


        #region public async Task<ActionResult<ResponseDTO<IEnumerable<CourseDto>>>> GetCourse(string id)
        /// <summary>
        ///    Listar cursos 
        /// </summary>
        /// <returns>course</returns>
        [HttpGet, Route("GetStatistics")]
        public async Task<ActionResult<ResponseDTO<IEnumerable<StatisticsDto>>>> GetStatistics()
        {
            var retorno = new ResponseDTO<IEnumerable<StatisticsDto>>();
            try
            {
                retorno.Data = await Task.Run(() => _StatisticsAppService.GetStatistics());
                retorno.Status = retorno.Data != null;
                retorno.Message = retorno.Status ? "OK" : "Não retornou dados";
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetStatistics] - Erro ao buscar dados." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest(retorno);
            }

        }
        #endregion
    }
}