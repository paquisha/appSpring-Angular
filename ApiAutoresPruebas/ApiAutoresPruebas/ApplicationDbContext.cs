﻿using ApiAutoresPruebas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiAutoresPruebas
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }
}
