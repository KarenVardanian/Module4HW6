using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW6.EntitiesConfigurations
{
    internal class GanreConfigurations : IEntityTypeConfiguration<Ganre>
    {
        public void Configure(EntityTypeBuilder<Ganre> builder)
        {
            builder.ToTable("Ganre").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Ganre").ValueGeneratedOnAdd().IsRequired();
           
        }
    }
}
