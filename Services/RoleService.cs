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
    public class RoleService:BaseService<RoleDTO, Role,RoleDTO>, IRoleService
    {
        public RoleService(AppDbContext db, IMapper mapper) : base(db,mapper)
        {
        }

   

    }
}
