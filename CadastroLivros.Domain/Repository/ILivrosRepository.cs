using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Repository
{
  public  interface ILivrosRepository
    {
        Livro Save(Livro livro);

        Livro Get(int id);

        Livro Update(Livro livro);

        Livro Delete(int id);

        List<Livro> GetAll();
    }
}
