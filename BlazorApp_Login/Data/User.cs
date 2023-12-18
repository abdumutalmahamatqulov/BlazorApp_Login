﻿using System;
using System.Data;
using Npgsql;

namespace BlazorApp_Login.Data
{
    [Serializable]
    public class User
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


}

