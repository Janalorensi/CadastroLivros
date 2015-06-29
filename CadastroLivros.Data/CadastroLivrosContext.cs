using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Data
{
    public class CadastroLivrosContext : DbContext
    {
        public CadastroLivrosContext()
        {
        }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().ToTable("TBAutor");
            modelBuilder.Entity<Autor>().Property(b => b.Nome).IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Livro>().ToTable("TBLivro");
            modelBuilder.Entity<Livro>().Property(b => b.Titulo).IsRequired().HasMaxLength(255);
        }
    }
}
