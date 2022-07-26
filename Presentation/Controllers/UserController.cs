﻿using DataAccess.Entities;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Get /{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {

                var res = _userService.Get(id);

                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet]
        [Route("Get")]

        public IEnumerable<UserDTO> Get()
        {
            return _userService.Get();
        }

        [HttpGet]
        [Route("GetContacts")]

        public IEnumerable<UserContactsDTO> GetUserContacts()
        {
            return _userService.GetUserContacts();
        }

        [HttpPost]
        [Route("Create")]

        public UserDTO Create([FromBody] UserDTO user)
        {
            return _userService.Create(user);
        }

        [HttpPut]
        [Route("Update")]

        public UserDTO Update([FromBody] UserDTO user)
        {
            return _userService.Update(user);
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public void Delete([FromRoute] int id)
        {
            _userService.Delete(id);
        }
     }
}
