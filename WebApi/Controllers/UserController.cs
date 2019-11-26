
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;

namespace Team17.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : _ApiBaseController
    {
        private readonly IPersonService m_PersonService;

        public UserController(IPersonService personService)
        {
            m_PersonService = personService;
        }

        //[AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User objUser)
        {
            var user = m_PersonService.Authenticate(objUser.Email, objUser.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }

            return Ok(user);
        }

    }
}
