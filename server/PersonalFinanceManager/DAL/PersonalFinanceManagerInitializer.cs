using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL
{
    public class PersonalFinanceManagerInitializer : System.Data.Entity.DropCreateDatabaseAlways<PersonalFinanceManagerContext>
    {
        protected override void Seed(PersonalFinanceManagerContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(u => u.UserName == "chris.dubiel"))
            {
                var userToInsert = new ApplicationUser { UserName = "chris.dubiel" };
                userManager.Create(userToInsert, "password");
            }
            var appUser = userManager.FindByName("chris.dubiel");

            var importRules = new List<ImportRule>
            {
                new ImportRule{ColumnName = "Date", TransactionPropertyName = "Date", MayContainCommas = false},
                new ImportRule{ColumnName = "Description", TransactionPropertyName = "Description", MayContainCommas = false},
                new ImportRule{ColumnName = "Comment", TransactionPropertyName = "Comment", MayContainCommas = false},
                new ImportRule{ColumnName = "Amount", TransactionPropertyName = "Amount", MayContainCommas = false}
            };
            var importType = new ImportType { Id = 1, Name = "American Eagle", ImportRules = importRules };
            context.ImportTypes.Add(importType);
            
            var transactions = ImportTransactionsFromDirectory(System.Web.Hosting.HostingEnvironment.MapPath("~/Imports"), importType);
            var account = new Account {UserId = appUser.Id, ImportTypeId = importType.Id, Name = "Bank Account", Transactions = transactions};
            context.Accounts.Add(account);

            context.SaveChanges();
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static List<Transaction> ImportTransactionsFromDirectory(string targetDirectory, ImportType importType)
        {
            var transactions = new List<Transaction>();
            // Process the list of files found in the directory.
            var fileEntries = Directory.GetFiles(targetDirectory);
            foreach (var fileName in fileEntries)
                transactions.AddRange(ImportTransactionsFromFile(fileName, importType));

            // Recurse into subdirectories of this directory.
            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (var subdirectory in subdirectoryEntries)
                transactions.AddRange(ImportTransactionsFromDirectory(subdirectory, importType));
            return transactions;
        }

        // Insert logic for processing found files here.
        public static List<Transaction> ImportTransactionsFromFile(string path, ImportType importType)
        {
            var transactions = new List<Transaction>();

            if (!importType.ImportRules.Any(r => r.MayContainCommas))
            {
                using (var reader = new StreamReader(path))
                {
                    var csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;

                    var transactionMap = new DefaultCsvClassMap<Transaction>();

                    var rules = importType.ImportRules.ToList();
                    // rules holds the property -> csv column mapping 
                    foreach (var rule in rules)
                    {
                        var columnName = rule.ColumnName;

                        if (string.IsNullOrEmpty(columnName)) continue;
                        var propertyInfo = typeof(Transaction).GetProperty(rule.TransactionPropertyName);
                        var newMap = new CsvPropertyMap(propertyInfo);
                        newMap.Name(columnName);

                        if (propertyInfo.Name == "Amount")
                        {
                            newMap.ConvertUsing(row => decimal.Parse(row.GetField<string>(rule.ColumnName), NumberStyles.Currency));
                        }

                        transactionMap.PropertyMaps.Add(newMap);
                    }

                    csvReader.Configuration.RegisterClassMap(transactionMap);
                    transactions = csvReader.GetRecords<Transaction>().ToList();
                }
            }
            
            Console.WriteLine($"Processed file '{path}'.");
            return transactions;
        }
    }
}