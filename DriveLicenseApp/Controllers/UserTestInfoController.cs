using ApplicationCQRS.Commands.UserTestInfoC;
using ApplicationCQRS.Queries.UserTestInfoQ;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveLicenseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestInfoController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IMediator _mediator = default;

        public UserTestInfoController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<UserTestInfoDto>> Get()
        {
            var readlAllAccountsQuery = new ReadAllUserTestInfosQuery();
            return await _mediator.Send(readlAllAccountsQuery);
        }

        // GET api/<UserController>/5
        [HttpGet("{userid}")]
        public async Task<IEnumerable<UserTestInfoDto>> Get(int userid)
        {
            var readById = new ReadUserTestInfosByUserIdQuery() { UserId = userid };
            return await _mediator.Send(readById);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserTestInfoDto value, int Userid)
        {
            
            if (value == null) { return BadRequest(); }

            var addNewUserTestInfoCommand = new AddNewUserTestInfoCommand() { UserId = Userid, UserTestInfo = value };
            var result = await _mediator.Send(addNewUserTestInfoCommand);
            if (result)
                return Ok(value);

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }
    }
}
