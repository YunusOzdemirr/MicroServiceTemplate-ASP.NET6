using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MicroServiceTemplate.API.Models.UserResponseModels;
using MicroServiceTemplate.Application.Features.Commands.UserCommands;
using MicroServiceTemplate.Application.Features.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroServiceTemplate.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(IResult),StatusCodes.Status200OK)]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result =await _mediator.Send(createUserCommand);
            if (result.Succeeded)
                return Ok(result);
                    return BadRequest(result);
        }

        [ProducesResponseType(typeof(UserViewModel),StatusCodes.Status200OK)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByIdAsync(GetByIdUserQuery getByIdUserQuery)
        {
            var result = await _mediator.Send(getByIdUserQuery);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

