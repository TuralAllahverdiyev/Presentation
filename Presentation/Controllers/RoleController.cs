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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService RoleService)
        {
            _roleService = RoleService;
        }

        [HttpGet]
        [Route("Get /{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {

                var res = _roleService.Get(id);

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

        public IEnumerable<RoleDTO> Get()
        {
            return _roleService.Get();
        }

        //[HttpGet]
        //[Route("GetContacts")]

        //public IEnumerable<RoleContactsDTO> GetRoleContacts()
        //{
        //    return _RoleService.GetRoleContacts();
        //}

        [HttpPost]
        [Route("Create")]

        public RoleDTO Create([FromBody] RoleDTO Role)
        {
            return _roleService.Create(Role);
        }

        [HttpPut]
        [Route("Update")]

        public RoleDTO Update([FromBody] RoleDTO Role)
        {
            return _roleService.Update(Role);
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public void Delete([FromRoute] int id)
        {
            _roleService.Delete(id);
        }
     }
}
