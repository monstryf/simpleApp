﻿using RestSharp;
using simpleApp;

namespace simpleApp.SimpleApi
{
    internal class UserDTOS
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual AddressDTOs? Address { get; set; } = default!;
    }
}

