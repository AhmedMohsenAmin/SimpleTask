using Task.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Map
{
    public class StepMap
    {
        public StepMap(EntityTypeBuilder<Step> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(a => a.Id).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.Name).IsRequired();

            entityBuilder.Property(t => t.IsDeleted).HasDefaultValue(false);

            entityBuilder.Property(x => x.CreatedDate).HasDefaultValueSql("getDate()");
        }
    }
}
