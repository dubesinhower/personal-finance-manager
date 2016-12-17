using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceTrackerAPI.Domain.Entities;

namespace EcommerceTrackerAPI.Infrastructure.Data.EntityTypeConfiguration
{
    public class GmailAccountTypeConfiguration : EntityTypeConfiguration<GmailAccount>
    {
        public GmailAccountTypeConfiguration()
        {
            HasKey(ga => ga.ID);
            Property(ga => ga.UserID);

        }
    }
}
