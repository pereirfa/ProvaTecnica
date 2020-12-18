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
    public class SignUpToCourseController : ControllerBase
    {
        private readonly ILogger _Logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

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


        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
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


        [HttpPost]
        public ActionResult Post([FromBody] SignUpToCourseModel model)
        {
            try
            {
                var course = _mediator.Send(new CreateSignUpToCourseCommand(_mapper.Map<SignUpToCourse>(model))).Result;
                return Ok(_mapper.Map<SignUpToCourseModel>(course));
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
