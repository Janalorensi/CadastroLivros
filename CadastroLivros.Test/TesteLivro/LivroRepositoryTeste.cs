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

namespace CadastroLivros.Test.TesteLivro
{
    [TestClass]
    public class LivroRepositoryTeste
    {
      

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<CadastroLivrosContext>());

            //Seta um registro padrão pra ser usado nos testes
            var _contextForTest = new CadastroLivrosContext();

            var autor = _contextForTest.Autores.Add(ObjectMother.GetAutor());

            var livro = ObjectMother.GetLivro();

            livro.Autor = autor;

            _contextForTest.Livros.Add(livro);

            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateLivroRepositoryTest()
        {
            //Arrange
            Livro livro = ObjectMother.GetLivro();

            livro.Autor = ObjectMother.GetAutor();
                        
            ILivrosRepository repository = new LivroRepository();

            //Action pronto
            Livro newLivro = repository.Save(livro);

            //Assert soment pera
            Assert.IsTrue(newLivro.ID > 0);
        }

        [TestMethod]
        public void UpdateLivroRepositoryTest()
        {
            //Arrange
            ILivrosRepository repository = new LivroRepository();

            Livro livro = repository.Get(1);

            livro.AnoPublicacao = 2010;

            livro.Editora = "escala";

            livro.Genero = "romance";

            livro.NumeroDePaginas = 378;

            livro.OrigemPublicacao = "Brasil";

            livro.Resumo = "lalalalallalalala lalalallalalalallalala lallalalalalalllalalallalal lalalallalalalalallalalalallalala lalallalalalalallalalalallala lalallalalallalalalalallalalalallalalallalalalla lalallalalalallalal";

            livro.Subtitulo = "livro sobre sua história";

            livro.Titulo = "Jana Lorensi";

            //Action
            var updatedLivro = repository.Update(livro);

            //Assert
            var persistedLivro = repository.Get(1);

            Assert.IsNotNull(updatedLivro);

            Assert.AreEqual(updatedLivro.ID, persistedLivro.ID);

            Assert.AreEqual(updatedLivro.Titulo, persistedLivro.Titulo);

            Assert.AreEqual(updatedLivro.Subtitulo, persistedLivro.Subtitulo);

            Assert.AreEqual(updatedLivro.Resumo, persistedLivro.Resumo);

            Assert.AreEqual(updatedLivro.OrigemPublicacao, persistedLivro.OrigemPublicacao);

            Assert.AreEqual(updatedLivro.NumeroDePaginas, persistedLivro.NumeroDePaginas);

            Assert.AreEqual(updatedLivro.AnoPublicacao, persistedLivro.AnoPublicacao);

            Assert.AreEqual(updatedLivro.Autor, persistedLivro.Autor);

            Assert.AreEqual(updatedLivro.Editora, persistedLivro.Editora);

            Assert.AreEqual(updatedLivro.AutorID, persistedLivro.AutorID);

            Assert.AreEqual(updatedLivro.Genero, persistedLivro.Genero);

        }

       [TestMethod]
       public void DeleteLivroRepositoryTest()
       {
            //Arrange
           ILivrosRepository repository = new LivroRepository();

            //Action
           var deletedLivro = repository.Delete(1);

            //Assert
           var persistedLivro = repository.Get(1);

           Assert.IsNull(persistedLivro);
        }

        [TestMethod]
        public void GetLivroRepositoryTest()
        {
            //Arrange
            ILivrosRepository repository = new LivroRepository();

            //Action
            Livro livro = repository.Get(1);

            //Assert
            Assert.IsNotNull(livro);

            Assert.IsTrue(livro.ID > 0);

            Assert.IsFalse(string.IsNullOrEmpty(livro.Titulo));

            Assert.IsFalse(string.IsNullOrEmpty(livro.Subtitulo));

            Assert.IsFalse(string.IsNullOrEmpty(livro.Resumo));

            Assert.IsFalse(string.IsNullOrEmpty(livro.OrigemPublicacao));

            Assert.IsFalse(string.IsNullOrEmpty(livro.Editora));


        }
      
    }
}
