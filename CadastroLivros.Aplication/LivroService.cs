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
  public  class LivroService : ILivroService
    {
      private ILivrosRepository _repository;

        public LivroService() { }

        public LivroService(ILivrosRepository repository)
        {
            _repository = repository;
        }
        public Livro Create(Livro livro)
        {
            Validator.Validate(livro);

            _repository.Save(livro);

            return livro;
        }
        public Livro Get(int id)
        {
            return _repository.Get(id);
        }
        public Livro Update(Livro livro)
        {
            Validator.Validate(livro);

            livro = _repository.Update(livro);

            return livro;
        }
        public Livro Remove(int id)
        {
            return _repository.Delete(id);
        }
        public List<Livro> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
