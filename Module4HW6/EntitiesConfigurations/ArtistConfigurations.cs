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
    internal class ArtistConfigurations : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Artist").ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Name).IsRequired();    
            builder.Property(p => p.DateOfBirth).IsRequired();    
        }
    }
}
