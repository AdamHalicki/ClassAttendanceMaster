using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ReactApp.Initializers
{
    public class RoleInitializer
    {
        private readonly RoleManager<Role> roleManager;

        public RoleInitializer(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        private async Task CreateRoleIfNotExist(string roleString)
        {
            var roleExists = await roleManager.RoleExistsAsync(roleString);

            if (!roleExists)
            {
                var role = new Role
                {
                    Name = roleString
                };

                await roleManager.CreateAsync(role);
            }
        }
    }
}
