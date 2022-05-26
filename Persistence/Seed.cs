using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
       public static async Task SeedDataAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id ="1",
                        UserName="Federico",
                        Email="jerfymatos@federicomatos.com"
                       
                    },
                    new AppUser
                    {
                        Id ="2",
                        UserName="Raul",
                        Email="raul@federicomatos.com"

                    },
                    new AppUser
                    {
                        Id ="3",
                        UserName="Paloma",
                        Email="paloma@federicomatos.com"

                    },
                    new AppUser
                    {
                        Id ="4",
                        UserName="Jose",
                        Email="jose@federicomatos.com"

                    }
                };

                foreach(var user in users)
                {
                   await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}
