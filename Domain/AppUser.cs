using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace Domain
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
        }
        public string Avatar { get; set; }
        public ICollection <Message> Messages{ get; set; }
    }
}
