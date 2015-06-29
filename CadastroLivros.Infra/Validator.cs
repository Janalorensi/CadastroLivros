using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Infra
{
  public  class Validator
    {
      public static void Validate(IObjectValidation domainObject)
      {
          domainObject.Validate();
      }
    }
}
