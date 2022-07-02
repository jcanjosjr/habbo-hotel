using Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }

        public DbSet<Limpeza> Limpezas { get; set; }

        public DbSet<Quarto> Quartos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Hospede> Hospedes { get; set; }

        public DbSet<Despesa> Despesas { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("server=localhost;User Id=root;database=habbohotel");
    }
}