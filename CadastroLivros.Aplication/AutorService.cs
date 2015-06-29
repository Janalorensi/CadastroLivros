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
    public class AutorService : IAutorService
    {

        private IAutorRepository _repository;

        public AutorService() { }

        public AutorService(IAutorRepository repository)
        {
            _repository = repository;
        }
        public Autor Create(Autor autor)
        {
            Validator.Validate(autor);

            _repository.Save(autor);

            return autor;
        }

        public Autor Get(int id)
        {
            return _repository.Get(id);
        }
        public Autor Update(Autor autor)
        {
            Validator.Validate(autor);

            autor = _repository.Update(autor);

            return autor;
        }
        public Autor Remove(int id)
        {
            return _repository.Delete(id);
        }

        public List<Autor> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

