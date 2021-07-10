using Task.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Map
{
    public class ItemMap
    {
        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.Title).IsRequired();


            entityBuilder.Property(t => t.IsDeleted).HasDefaultValue(false);

            entityBuilder.Property(x => x.CreatedDate).HasDefaultValueSql("getDate()");


        }
    }
}
