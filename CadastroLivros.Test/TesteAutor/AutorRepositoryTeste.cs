using CadastroLivros.Data;
using CadastroLivros.Domain.Entity;
using CadastroLivros.Domain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Test.TesteAutor
{
    [TestClass]
    public class AutorRepositoryTeste
    {
        private CadastroLivrosContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<CadastroLivrosContext>());

            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new CadastroLivrosContext();

            _contextForTest.Autores.Add(ObjectMother.GetAutor());

            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateAutorRepositoryTest()
        {
            //Arrange
            Autor autor = ObjectMother.GetAutor();

            IAutorRepository repository = new AutorRepository();

            //Action pronto
            Autor newAutor = repository.Save(autor);

            //Assert soment pera
            Assert.IsTrue(newAutor.ID > 0);
        }

        [TestMethod]
        public void UpdateAutorRepositoryTest()
        {
            //Arrange
            IAutorRepository repository = new AutorRepository();

            Autor autor = _contextForTest.Autores.Find(1);

            autor.Nome = "Jana";

            autor.Nacionalidade = "Brasil";

            autor.Idade = 21;

            //Action
            var updatedAutor = repository.Update(autor);

            //Assert
            var persistedAutor = _contextForTest.Autores.Find(1);

            Assert.IsNotNull(updatedAutor);

            Assert.AreEqual(updatedAutor.ID, persistedAutor.ID);

            Assert.AreEqual(updatedAutor.Nome, persistedAutor.Nome);

            Assert.AreEqual(updatedAutor.Nacionalidade, persistedAutor.Nacionalidade);

            Assert.AreEqual(updatedAutor.Idade, persistedAutor.Idade);
        }

        [TestMethod]
        public void DeleteAutorRepositoryTest()
        {
            //Arrange
            IAutorRepository repository = new AutorRepository();

            //Action
            var deletedAutor = repository.Delete(1);

            //Assert
            var persistedAutor = _contextForTest.Autores.Find(1);

            Assert.IsNull(persistedAutor);
        }

        [TestMethod]
        public void GetAutorRepositoryTest()
        {
            //Arrange
            IAutorRepository repository = new AutorRepository();

            //Action
            Autor autor = repository.Get(2);

            //Assert
            Assert.IsNotNull(autor);

            Assert.IsTrue(autor.ID > 0);

            Assert.IsFalse(string.IsNullOrEmpty(autor.Nome));

            Assert.IsFalse(string.IsNullOrEmpty(autor.Nacionalidade));           


        }
    }
}
