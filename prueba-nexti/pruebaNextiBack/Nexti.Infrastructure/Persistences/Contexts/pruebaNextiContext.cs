using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nexti.Domain.Entities;

namespace Nexti.Infrastructure.Persistences.Contexts
{
    public partial class pruebaNextiContext : DbContext
    {
        public pruebaNextiContext()
        {
        }

        public pruebaNextiContext(DbContextOptions<pruebaNextiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
