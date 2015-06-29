using CadastroLivros.Domain.Exceptions;
using CadastroLivros.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Entity
{
    public class Autor : IObjectValidation
    {
       public int ID { get; set; }
       public string Nome { get; set; }
       public string Nacionalidade { get; set; }
       public int Idade { get; set; }
       public string Bibliografia { get; set; }

       public void Validate()
       {
           if (Nome == "")
               throw new DomainException("Nome Inválido .");

           if (Nacionalidade == "")
               throw new DomainException("Nacionalidade deve estar preenchido.");

           if (Idade < 10)
               throw new DomainException("Idade deve ser maior que 10 anos.");

           if (Bibliografia == "")
               throw new DomainException("Bibliografia deve estar preenchido.");

           if (Bibliografia.Length > 500)
               throw new DomainException("A bibliografia deve conter no máximo 500 caracteres.");
       }
    }
}
