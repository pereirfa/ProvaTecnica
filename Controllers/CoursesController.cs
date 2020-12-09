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

        #region public CoursesController(ICoursesAppService _coursesAppService, ILogger<CoursesController> logger)
        public CoursesController(ICoursesAppService _coursesAppService, ILogger<CoursesController> logger)
        {
            _CoursesAppService = _coursesAppService;
            _Logger = logger;
        }
        #endregion


        #region public async Task<ActionResult<ResponseDTO<IEnumerable<CourseDto>>>> GetCourse(string id)
        /// <summary>
        /// Listar cursos 
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Retorna os cursos cadastrados</response>
        [HttpGet, Route("GetCourse")]
        public async Task<ActionResult<ResponseDTO<IEnumerable<CourseDto>>>> GetCourse(string Id)
        {
            var retorno = new ResponseDTO<IEnumerable<CourseDto>>();
            try
            {
                retorno.Data = await Task.Run(() => _CoursesAppService.GetCourse(Id));
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


        #region public async Task<ActionResult<ResponseDTO<string>>> CreateCourse(CourseDto course)
        /// <summary>
        /// Cadastrar Curso
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Cadastra novos cursos </response>
        [HttpPost, Route("CreateCourse")]
        public async Task<ActionResult<ResponseDTO<string>>> CreateCourse(CourseDto course)
        {
            var retorno = new ResponseDTO<string>();
            try
            {
                retorno.Data = await Task.Run(() => _CoursesAppService.CreateCourse(course));
                retorno.Status = true;
                retorno.Message = retorno.Data;
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.CreateCourse] - Erro ao inserir dados." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest(retorno);
            }

        }
        #endregion


        #region  public async Task<ActionResult<ResponseDTO<string>>> SignUPCourse(SignUpToCourseDto matricula)
        /// <summary>
        /// Inscrever aluno em curso
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Inscreve novos alunos de acordo com a capacidade do curso </response>
        [HttpPost, Route("SignUPCourse")]
        public async Task<ActionResult<ResponseDTO<string>>> SignUPCourse(SignUpToCourseDto matricula)
        {
            var retorno = new ResponseDTO<string>();
            try
            {
                retorno.Data = await Task.Run(() => _CoursesAppService.SignUPCourse(matricula));
                retorno.Status = true ;
                retorno.Message = retorno.Data ;
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.SignUPCourse] - Erro ao inserir dados." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest(retorno);
            }

        }
        #endregion

    }
}
