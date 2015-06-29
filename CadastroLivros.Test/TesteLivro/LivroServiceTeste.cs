using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadastroLivros.Domain.Entity;
using CadastroLivros.Domain.Repository;
using Moq;
using CadastroLivros.Infra;
using CadastroLivros.Aplication;

namespace CadastroLivros.Test.TesteLivro
{
    [TestClass]
    public class LivroServiceTeste
    {
        [TestMethod]
        public void SaveLivroServiceValidationAndPersistenceTest()
        {
            //Arrange
            Livro livro = ObjectMother.GetLivro();

            //Fake do repositório
            var repositoryFake = new Mock<ILivrosRepository>();

            repositoryFake.Setup(r => r.Save(livro)).Returns(livro);

            //Fake do dominio
            var livroFake = new Mock<Livro>();

            livroFake.As<IObjectValidation>().Setup(b => b.Validate());

            ILivroService service = new LivroService(repositoryFake.Object);

            //Action
            service.Create(livroFake.Object);

            //Assert
            livroFake.As<IObjectValidation>().Verify(b => b.Validate());

            repositoryFake.Verify(r => r.Save(livroFake.Object));
        }

        [TestMethod]
        public void UpdateLivroServiceValidationAndPersistenceTest()
        {
            //Arrange
            Livro livro = ObjectMother.GetLivro();

            //Fake do repositório
            var repositoryFake = new Mock<ILivrosRepository>();

            repositoryFake.Setup(r => r.Update(livro)).Returns(livro);

            //Fake do dominio
            var livroFake = new Mock<Livro>();

            livroFake.As<IObjectValidation>().Setup(b => b.Validate());

            ILivroService service = new LivroService(repositoryFake.Object);

            //Action
            service.Update(livroFake.Object);

            //Assert
            livroFake.As<IObjectValidation>().Verify(b => b.Validate());

            repositoryFake.Verify(r => r.Update(livroFake.Object));
        }

        [TestMethod]
        public void DeleteLivroServiceTest()
        {
            //Arrange
            Livro livro = null;

            //Fake do repositório
            var repositoryFake = new Mock<ILivrosRepository>();

            repositoryFake.Setup(r => r.Delete(1)).Returns(livro);

            ILivroService service = new LivroService(repositoryFake.Object);

            //Action
            var livroFake = service.Remove(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));

            Assert.IsNull(LivroFake);
        }
        [TestMethod]
        public void GetLivroServiceTest()
        {
            //Arrange
            Livro livro = ObjectMother.GetLivro();

            //Fake do repositório
            var repositoryFake = new Mock<ILivrosRepository>();

            repositoryFake.Setup(r => r.Get(1)).Returns(livro);

            ILivroService service = new LivroService(repositoryFake.Object);

            //Action
            var livroFake = service.Get(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));

            Assert.IsNotNull(livroFake);
        }



        public object LivroFake { get; set; }

    }
}
