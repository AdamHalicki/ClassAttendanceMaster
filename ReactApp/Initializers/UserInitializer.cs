using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApp.Initializers
{
    public class UserInitializer
    {
        private readonly UserManager<User> userManager;

        private const string adminLogin = "admin@gmail.com";
        private const string adminPassword = "Adminhaslo.123";
        private const string userPassword = "Userhaslo.123";

        public UserInitializer(
            UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
    }
}
