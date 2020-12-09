using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseSignUP.Interfaces;
using CourseSignUP.DTO;
using Microsoft.Extensions.Logging;

namespace CourseSignUP.Controllers
{
    [ApiController, Route("[controller]")]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerAppService _LecturerAppService;
        private readonly ILogger _Logger;

        public LecturersController(ILecturerAppService _lecturerAppService, ILogger<CoursesController> logger)
        {
            _LecturerAppService = _lecturerAppService;
            _Logger = logger;
        }


        #region public async Task<ActionResult<ResponseDTO<bool>>> CreateLecturer(CreateLecturerDto lecturer)
        /// <summary>
        ///  Incluir Palestrante
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Cadastra novos palestrantes </response>
        [HttpPost, Route("CreateLecturer")]
        public async Task<ActionResult<ResponseDTO<bool>>> CreateLecturer(CreateLecturerDto lecturer)
        {
            var retorno = new ResponseDTO<bool>();
            try
            {
                retorno.Data = await Task.Run(() => _LecturerAppService.CreateLecturer(lecturer));
                retorno.Status = retorno.Data != false;
                retorno.Message = retorno.Status ? "OK" : "Não retornou dados";
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[CoursesController.CreateLecturer] - Erro ao inserir dados." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest(retorno);
            }

        }
        #endregion
    }
}