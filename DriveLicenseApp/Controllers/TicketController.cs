using ApplicationCQRS.Handlers.TicketHandlers;
using ApplicationCQRS.Queries.TicketQ;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveLicenseApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private static Random rnd = new Random();
        private readonly IMediator _mediator = default;

        public TicketController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var readlAllAccountsQuery = new ReadAllTicketsQuery();
            var data = await _mediator.Send(readlAllAccountsQuery);
            var tickets =  data.OrderBy(x => rnd.Next()).Take(30).ToList();
            return Ok(tickets);
        }

        // GET api/<ContactController>/5
        [HttpGet]
        [Route("/api/Ticket/ByTopicId/{topicId}")]
        public async Task<IEnumerable<TicketDto>> Get(int topicId)
        {
            var readTicketByTopicHandler = new ReadTicketByTopicQuery() { Topic = topicId};
            var data = await _mediator.Send(readTicketByTopicHandler);
            return data;

        }

        [HttpGet]
        [Route("/api/Ticket/Check/{questionId}/{Answer}/{userId}")]
        public async Task<IActionResult> Get(int questionId,int Answer,int userId)
        {
            
            var readTicketByTopicHandler = new GetCorrectAnswerQuery() { Answer = Answer, QuetionId = questionId, UserId = userId };
            var result =  await _mediator.Send(readTicketByTopicHandler);
            return Ok(new { Status = result.Item1, correctAnswer = result.Item2 });
        }
    }
}
