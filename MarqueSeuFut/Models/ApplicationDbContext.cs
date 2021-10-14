using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarqueSeuFut.Models;

namespace MarqueSeuFut.Models
{
    // classe para gerenciar a aplicação com o

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Posicao> Posicoes { get; set; } // tera esse atributo para todas as tabelas que serão criadas
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Escalacao> Escalacoes { get; set; }
    }
}
