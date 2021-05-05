using System;
using System.Collections.Generic;
using Bespereboiniki.Datalayer.Tables;

namespace Bespereboiniki.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        
        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public List<Role> PossibleRoles { get; set; }
    }
}