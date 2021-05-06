using System;
using System.Collections.Generic;
using System.Linq;
using Bespereboiniki.Datalayer.Tables;

namespace Bespereboiniki.Datalayer.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Guid? GetRoleIdByName(string name);
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly UPSContext context;

        public RoleRepository(UPSContext context)
        {
            this.context = context;
        }

        public List<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public Guid? GetRoleIdByName(string name)
        {
            return context.Roles.FirstOrDefault(item => item.Name == name)?.Id;
        }
    }
}