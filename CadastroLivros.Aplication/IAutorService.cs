using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Aplication
{
   public interface IAutorService
    {
        Autor Create(Autor autor);
        Autor Remove(int id);
        Autor Update(Autor autor);
        Autor Get(int id);
        List<Autor> GetAll();
    }
}
