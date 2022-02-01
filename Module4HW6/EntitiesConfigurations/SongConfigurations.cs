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
    internal class SongConfigurations : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.ReleasedDate).IsRequired();
        }
    }
}
