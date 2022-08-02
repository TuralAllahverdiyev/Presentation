using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserRoleService:BaseService<UserRoleDTO, UserRoles,UserRoleDTO>, IUserRoleService
    {
        public UserRoleService(AppDbContext db, IMapper mapper) : base(db,mapper)
        {
        }

        public override IEnumerable<UserRoleDTO> Get()
        {
            var ent =_dbSet.Include(x => x.User).Include(x => x.Roles);

            var res = new List<UserRoleDTO>();

            foreach (var us in ent)
            {
               var dto= new UserRoleDTO()
                {
                    RoleId = us.RoleId,
                    RoleName = us.Roles.Name,

                    UserId = us.UserId,
                    UserName = us.User.Name

                };
                res.Add(dto);
            }
            return res;
        }
    }
}
