using System;

namespace Bespereboiniki.Datalayer.Tables
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Role UserRole { get; set; }
    }
}