﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace RetoLibreria.Modelos
{
    
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }
            public DbSet<User> Users { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Calificacion> Calificaciones { get; set; }
            public DbSet<Resena> Resenas { get; set; }



    }

}