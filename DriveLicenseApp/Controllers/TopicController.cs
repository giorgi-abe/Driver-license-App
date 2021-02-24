using ApplicationCQRS.Queries.TopicQ;
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
    public class TopicController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IMediator _mediator = default;

        public TopicController( IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TopicDto>> Get()
        {
            var readlAllAccountsQuery = new ReadAllTopicsQuery();
            return await _mediator.Send(readlAllAccountsQuery);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<TopicDto> Get(int id)
        {
            var readById = new ReadTopicByIdQuery() {TopicId = id};
            return await _mediator.Send(readById);
        }
        
    }
}
