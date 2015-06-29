using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Aplication
{
   public interface ILivroService
    {
        Livro Create(Livro livro);
        Livro Remove(int id);
        Livro Update(Livro livro);
        Livro Get(int id);
        List<Livro> GetAll();
    }
}
