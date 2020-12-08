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
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesAppService _CoursesAppService;
        private readonly ILogger _Logger;

        /// <summary>
        /// Constructor da Classe CoursesController
        /// </summary>
        /// <param name="_coursesAppService"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>

        public CoursesController(ICoursesAppService _coursesAppService, ILogger<CoursesController> logger)
        {
            _CoursesAppService = _coursesAppService;
            _Logger = logger;
        }

        #region public async Task<ActionResult<ResponseDTO<IEnumerable<CourseDto>>>> GetCourse(string id)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetCourse")]
        public async Task<ActionResult<ResponseDTO<IEnumerable<CourseDto>>>> GetCourse()
        {
            var retorno = new ResponseDTO<IEnumerable<CourseDto>>();
            try
            {
                retorno.Data = await Task.Run(() => _CoursesAppService.GetCourse());
                retorno.Status = retorno.Data != null;
                retorno.Message = retorno.Status ? "OK" : "Não retornou dados";
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.GetCourse] - Erro ao buscar dados." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest(retorno);
            }

        }
        #endregion
       
    }
}
