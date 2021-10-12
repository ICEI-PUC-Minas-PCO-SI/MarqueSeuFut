using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
