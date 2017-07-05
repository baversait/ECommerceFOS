using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Data.Configurations
{
    public class UserConfigurations:EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            ToTable("Users");
            HasKey(x => x.UserID);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.LastName).IsRequired().HasMaxLength(50);
            Property(x => x.Email).IsRequired().HasMaxLength(200);
            Property(x => x.Password).IsRequired().HasMaxLength(50);

            HasOptional(x => x.Address)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.AddressID)
                .WillCascadeOnDelete(false);
        }
    }
}
