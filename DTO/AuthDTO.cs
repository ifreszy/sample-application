﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AuthDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserDTO User { get; set; }
    }
}
