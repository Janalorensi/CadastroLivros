using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Repository
{
   public interface IAutorRepository
    {

        Autor Save(Autor autor);

        Autor Get(int id);

        Autor Update(Autor autor);

        Autor Delete(int id);

        List<Autor> GetAll();
    }
}
