using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using AutoMapper;
using MediatR;
using CourseSignUp.Services.Commands.Statistics;
using CourseSignUp.Application.Model;
using System.Collections.Generic;

namespace CourseSignUp.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger _Logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StatisticsController(
            IMapper mapper,
            IMediator mediator,
            ILogger<StatisticsController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _Logger = logger;
        }


        #region GetAll()
        /// <summary>
        /// Buscar todas as estatisticas
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Estatistica consultada com sucesso</response>
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var course = _mediator.Send(new GetAllStatisticsQuery()).Result;
                return Ok(_mapper.Map<IEnumerable<StatisticsModel>>(course));
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
        #endregion


        #region Get(id)
        /// <summary>
        /// Buscar as estatisticas por Id
        /// </summary>
        /// <returns>course</returns>
        /// <response code="200">Estatistica consultada com sucesso</response>
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var statistics = _mediator.Send(new GetByIdStatisticsQuery(id)).Result;
                return Ok(_mapper.Map<StatisticsModel>(statistics));
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
        #endregion
    }
}


