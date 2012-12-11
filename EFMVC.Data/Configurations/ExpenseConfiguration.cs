using EFMVC.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMVC.Data.Configurations
{
    public class ExpenseConfiguration : EntityTypeConfiguration<Expense>
    {
        public ExpenseConfiguration()
        {
            ToTable("Expenses");
            Property(e => e.Transaction).HasMaxLength(100).IsRequired();
            Property(e => e.Date).IsRequired();
            Property(e => e.Amount).IsRequired();
            Property(e => e.CategoryId).IsRequired();
        }
    }
}
