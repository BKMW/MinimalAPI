﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthManager.Models
{
    public class AuthRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
