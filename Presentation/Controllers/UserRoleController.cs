using DataAccess.Entities;
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
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService UserRoleService)
        {
            _userRoleService = UserRoleService;
        }

        [HttpGet]
        [Route("Get /{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {

                var res = _userRoleService.Get(id);

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

        public IEnumerable<UserRoleDTO> Get()
        {
            return _userRoleService.Get();
        }

        //[HttpGet]
        //[Route("GetContacts")]

        //public IEnumerable<UserRoleContactsDTO> GetUserRoleContacts()
        //{
        //    return _UserRoleService.GetUserRoleContacts();
        //}

        [HttpPost]
        [Route("Create")]

        public UserRoleDTO Create([FromBody] UserRoleDTO UserRole)
        {
            return _userRoleService.Create(UserRole);
        }

        [HttpPut]
        [Route("Update")]

        public UserRoleDTO Update([FromBody] UserRoleDTO UserRole)
        {
            return _userRoleService.Update(UserRole);
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public void Delete([FromRoute] int id)
        {
            _userRoleService.Delete(id);
        }
     }
}
