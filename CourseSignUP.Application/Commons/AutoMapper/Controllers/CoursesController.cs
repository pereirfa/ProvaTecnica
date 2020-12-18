using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using MediatR;
using AutoMapper;
using CourseSignUp.Domain.Entities;
using CourseSignUp.Services.Commands.Course;
using System.Collections.Generic;
using CourseSignUp.Application.Model;

namespace CourseSignUp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger _Logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CoursesController(
            ILogger<CoursesController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _Logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }


        #region GetAll()
        /// <summary>
        /// Listar todos os cursos 
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Retorna todos os cursos cadastrados</response>
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var course = _mediator.Send(new GetAllCourseQuery()).Result;
                return Ok(_mapper.Map<IEnumerable<CourseModel>>(course));
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
        #endregion

        #region Get(Id)
        /// <summary>
        /// Listar curso pelo Id
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Busca do curso com sucesso.</response>
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var course = _mediator.Send(new GetByIdCourseQuery(id)).Result;
                return Ok(_mapper.Map<CourseModel>(course));
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
        #endregion

        #region Create()
        /// <summary>
        /// Cadastrar curso
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Cadastro executado com sucesso</response>
        [HttpPost]
        public ActionResult Post([FromBody] CourseModel model)
        {
            try
            {
                var course = _mediator.Send(new CreateCourseCommand(_mapper.Map<Course>(model))).Result;
                return Ok(_mapper.Map<CourseModel>(course));
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
        #endregion

        #region Put()
        /// <summary>
        /// Atualizar curso
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Curso atualizado com sucesso</response>
        [HttpPut]
        public ActionResult Put([FromBody] CourseModel model)
        {
            try
            {
                var course = _mediator.Send(new UpdateCourseCommand(_mapper.Map<Course>(model))).Result;
                return Ok(_mapper.Map<CourseModel>(course));
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
        #endregion

        #region Delete()
        /// <summary>
        /// Deletar curso por Id
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Curso deletado com sucesso</response>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                return Ok(_mediator.Send(new DeleteCourseCommand(id)).Result);
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
        #endregion
    }
}
