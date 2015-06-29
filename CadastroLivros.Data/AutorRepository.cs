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
   public class AutorRepository : IAutorRepository
    {
        CadastroLivrosContext context = new CadastroLivrosContext();

        public Autor Save(Autor autor)
        {
            var newAutor = context.Autores.Add(autor);
            context.SaveChanges();
            return newAutor;
        }
        public Autor Get(int id)
        {
            return context.Autores.Find(id);
        }
        public Autor Update(Autor autor)
        {
            DbEntityEntry entry = context.Entry(autor);
            entry.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return autor;
        }
        public Autor Delete(int id)
        {
            Autor autor = context.Autores.Find(id);
            Autor deletedAutores = context.Autores.Remove(autor);
            context.SaveChanges();
            return deletedAutores;
        }

        public List<Autor> GetAll()
        {
            return context.Autores.ToList();
        }
    }
 }

