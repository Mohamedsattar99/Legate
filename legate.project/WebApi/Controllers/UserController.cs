﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.User.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserDetails;
using Application.Users.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
          //TODO: By convension the controller name is plural i.e. it should be UsersController
    public class UserController : BaseController {

        [HttpGet]
        public async Task<ActionResult<UserLookupDto>> GetAll () {
            return Ok (await Mediator.Send (new GetUsersListQuery ()));
        }

        [HttpGet ("id")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        
        //TODO: Use the [FromQuery] attribute for the the parameter
        public async Task<ActionResult<GetUserDetailsVM>> Get (int id) {
            return Ok (await Mediator.Send (new GetUserDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddUser ([FromBody] CreateUserCommand userCommand) {
            await Mediator.Send (userCommand);
            //TODO: Usually the create command returns the id of the created entity.
            return NoContent ();
        }

        [HttpPut]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update ([FromBody] UpdateUserCommand userCommand) {
            await Mediator.Send (userCommand);
          //TODO: Usually the update command returns a status.
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
      //TODO: Use the [FromQuery] attribute for the the parameter
        public async Task<ActionResult> Delete (int id) {
            await Mediator.Send (new DeleteUserCommand { Id = id });
          //TODO: Usually the delete command returns a status.
            return NoContent ();
        }

    }
}