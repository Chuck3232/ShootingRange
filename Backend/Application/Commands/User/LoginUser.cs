﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.User
{
    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
