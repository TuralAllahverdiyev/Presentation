﻿using DataAccess;
using DataAccess.Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService:BaseService<User>, IUserService
    {
        public UserService(AppDbContext db) : base(db)
        {
        }

        public User Login(string ps, string us)
        {
            var res = _db.Users.Where(x => x.Name == us && x.Password == ps);

            if (res.Count() == 1)
            {
                return res.First();
            }
            else
            {
                throw new Exception("User Not Found");
            }
        }

    }
}
