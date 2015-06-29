using CadastroLivros.Domain.Entity;
using CadastroLivros.Domain.Repository;
using CadastroLivros.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Aplication
{
   public class PostService: IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post SaveOrUpdate(Post post)
        {
            Validator.Validate(post);

            return _postRepository.SaveOrUpdate(post);
        }

        public Post Get(long id)
        {
            return _postRepository.Get(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public void Delete(Post post)
        {
            _postRepository.Delete(post);
        }
    }
}
