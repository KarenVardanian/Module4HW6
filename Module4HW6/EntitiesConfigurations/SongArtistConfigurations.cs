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
    public class SongArtistConfigurations : IEntityTypeConfiguration<SongArtist>
    {
        public void Configure(EntityTypeBuilder<SongArtist> builder)
        {
            builder.ToTable("SongArtist").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("SongArtist").ValueGeneratedOnAdd().IsRequired();
        }
    }
}
