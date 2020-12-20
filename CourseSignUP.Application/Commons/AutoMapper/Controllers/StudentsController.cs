using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using MediatR;
using AutoMapper;
using CourseSignUp.Domain.Entities;
using CourseSignUp.Services.Commands.Student;
using System.Collections.Generic;
using CourseSignUp.Application.Model;

namespace CourseSignUp.Application.Commons.AutoMapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger _Logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StudentsController(
            ILogger<StudentsController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _Logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        #region GetAll()
        /// <summary>
        /// Listar todos os alunos 
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Retorna todos os alunos cadastrados</response>
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var course = _mediator.Send(new GetAllStudentQuery()).Result;
                return Ok(_mapper.Map<IEnumerable<StudentModel>>(course));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[StudentsController.GetAll] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[StudentsController.GetAll] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[StudentsController.GetAll] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Get(Id)
        /// <summary>
        /// Listar aluno pelo Id
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Busca do aluno com sucesso.</response>
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var course = _mediator.Send(new GetByIdStudentQuery(id)).Result;
                return Ok(_mapper.Map<StudentModel>(course));
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
        /// Cadastrar aluno
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Cadastro executado com sucesso</response>
        [HttpPost]
        public ActionResult Post([FromBody] StudentModel model)
        {
            try
            {
                return Ok(_mediator.Send(new CreateStudentCommand(_mapper.Map<Student>(model))).Result);
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[StudentsController.Create] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[StudentsController.Create] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[StudentsController.Create] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Delete()
        /// <summary>
        /// Deletar aluno por Id
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Aluno deletado com sucesso</response>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_mediator.Send(new DeleteStudentCommand(id)).Result);
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[StudentsController.Delete] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[StudentsController.Delete] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[StudentsController.Delete] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion



    }
}
