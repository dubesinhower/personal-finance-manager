using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL
{
    public class PersonalFinanceManagerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PersonalFinanceManagerContext>
    {
        protected override void Seed(PersonalFinanceManagerContext context)
        {
            if (!context.Users.Any(u => u.UserName == "chris.dubiel"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "chris.dubiel" };
                userManager.Create(userToInsert, "password");
            }

            var importRules = new List<ImportRule>
            {
                new ImportRule{ColumnName = "Date", TransactionPropertyName = "Date", MayContainCommas = false},
                new ImportRule{ColumnName = "Description", TransactionPropertyName = "Description", MayContainCommas = false},
                new ImportRule{ColumnName = "Comment", TransactionPropertyName = "Comment", MayContainCommas = false},
                new ImportRule{ColumnName = "Ammount", TransactionPropertyName = "Amount", MayContainCommas = false}
            };
            var importType = new ImportType{Name = "American Eagle", ImportRules = importRules};
            context.ImportTypes.Add(importType);
            context.SaveChanges();
        }
    }
}