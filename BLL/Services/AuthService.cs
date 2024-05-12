﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static bool Authenticate(string email, string password)
        {
            return DataAccessFactory.AuthData().Authenticate(email, password);
        }
    }
}
