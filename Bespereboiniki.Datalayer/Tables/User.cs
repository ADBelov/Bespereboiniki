using System;

namespace Bespereboiniki.Datalayer.Tables
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();

        public string Login { get; set; }
        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public Role UserRole { get; set; }
    }
}