using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using EcommerceTrackerAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EcommerceTrackerAPI.DAL
{

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.EmailTypes.Any(et => et.Description == "Gmail"))
            {
                context.EmailTypes.Add(new EmailType { Description = "Gmail" });
                context.EmailTypes.Add(new EmailType { Description = "IMAP" });
            }

            if (!context.Users.Any(u => u.UserName == "chris"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "chris" };
                userManager.Create(userToInsert, "password");
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}