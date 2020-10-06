using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public class User : IdentityUser
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }
        public string ProfilePic { get; set; }
        public long BirthDate { get; set; }



    }
}
