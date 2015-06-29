using CadastroLivros.Domain.Entity;
using CadastroLivros.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Data
{
    public class LivroRepository : ILivrosRepository
    {
        CadastroLivrosContext context = new CadastroLivrosContext();

        public Livro Save(Livro livro)
        {
            var newLivro = context.Livros.Add(livro);
            context.SaveChanges();
            return newLivro;
        }
        public Livro Get(int id)
        {
            return context.Livros.Find(id);
        }
        public Livro Update(Livro livro)
        {
            DbEntityEntry entry = context.Entry(livro);
            entry.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return livro;
        }
        public Livro Delete(int id)
        {
            Livro livro = context.Livros.Find(id);
            Livro deletedLivros = context.Livros.Remove(livro);
            context.SaveChanges();
            return deletedLivros;
        }

        public List<Livro> GetAll()
        {
            return context.Livros.ToList();
        }
    }
}
