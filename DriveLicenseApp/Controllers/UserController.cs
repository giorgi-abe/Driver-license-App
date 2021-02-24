using ApplicationCQRS.Commands.UserC;
using ApplicationCQRS.Queries.UserQ;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IMediator _mediator = default;

        public UserController( IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var readlAllAccountsQuery = new ReadallUsersQuery();
            return await _mediator.Send(readlAllAccountsQuery);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<UserDto> Get(int id)
        {
            var readById = new ReadUserByIdQuery() { UserId = id };
            return await _mediator.Send(readById);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand value)
        {
            if (value == null) { return BadRequest(); }

            var result = await _mediator.Send(value);
            if (result)
                return Ok(new { status=result });

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] User value)
        {
            if (value == null) { return BadRequest(); }

            var updateUserCommand = new UpdateUserCommand() { Id = id ,User = _mapper.Map<UserDto>(value) };
            var result = await _mediator.Send(updateUserCommand);
            if (result)
                return Ok(value);

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteUserCommand = new DeleteUserCommand() { UserId = id,};
            var result = await _mediator.Send(deleteUserCommand);
            if (result)
                return Ok();

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }
    }
}
