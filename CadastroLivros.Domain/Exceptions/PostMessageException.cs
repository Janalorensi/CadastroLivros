using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Exceptions
{
    public class PostMessageException : Exception
    {
       public PostMessageException(string message) : base(message) { }
    }
}
