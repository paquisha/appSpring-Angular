using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Infrastructure.Persistences.Contexts.Configurations
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("evento");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            builder.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            builder.Property(e => e.Lugar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lugar");

            builder.Property(e => e.Numero).HasColumnName("numero");

            builder.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");
        }
    }
}
