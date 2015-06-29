using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Repository
{
    public interface IPostRepository
    {
        Post SaveOrUpdate(Post post);
        Post Get(long id);
        IEnumerable<Post> GetAll();
        void Delete(Post post);
    }
}
