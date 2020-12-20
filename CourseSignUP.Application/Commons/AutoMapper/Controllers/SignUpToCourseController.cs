using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using CourseSignUp.Domain.Entities;
using MediatR;
using AutoMapper;
using CourseSignUp.Services.Commands.SignUpToCourse;
using CourseSignUp.Application.Model;

namespace CourseSignUp.Application.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class SignUpToCourseController : ControllerBase
    {
        private readonly ILogger _Logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private int idCourse;
        private int idStudent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public SignUpToCourseController(
            IMapper mapper,
            IMediator mediator,
            ILogger<SignUpToCourseController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _Logger = logger;
        }

        /// <summary>
        /// Consultar as matriculas por curso 
        /// </summary>
        /// <param name="id"> Id Curso  </param>
        /// <returns>course</returns>
        /// <response code="200">Consulta realizada com sucesso</response>
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id )
        {
            try
            {
                var course = _mediator.Send(new GetByIdSignUpToCourseQuery(id)).Result;
                return Ok(_mapper.Map<SignUpToCourseModel>(course));
            }
            catch (HttpRequestException ex)
            {
                _Logger.LogError(ex, "[SignUpToCourseController.GetId] - Http Request Failed." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _Logger.LogError(ex, "[SignUpToCourseController.GetId] - Argument Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "[SignUpToCourseController.GetId] - Generic Error." + ex.Message + " | StackTrace = " + ex.StackTrace, null);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar matriculas por IdCourse e IdStudent
        ///
        /// </summary>
        /// <param name="idCourse"> Id Curso  </param>
        /// <param name="idStudent"> Id Student  </param>  
        /// 
        /// <returns>course</returns>
        /// <response code="200">Matricula realizada com sucesso</response>
        [HttpPost]
        public ActionResult Post(int idCourse , int idStudent )
        {
            try
            {
              return Ok(_mediator.Send(new CreateSignUpToCourseCommand(idCourse, idStudent)).Result);
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
