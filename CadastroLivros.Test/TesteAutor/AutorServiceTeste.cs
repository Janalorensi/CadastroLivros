using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadastroLivros.Domain.Entity;
using CadastroLivros.Infra;
using CadastroLivros.Aplication;
using Moq;
using CadastroLivros.Domain.Repository;

namespace CadastroLivros.Test.TesteAutor
{
    [TestClass]
    public class AutorServiceTeste
    {
        [TestMethod]
        public void SaveAutorServiceValidationAndPersistenceTest()
        {
            //Arrange
            Autor autor = ObjectMother.GetAutor();

            //Fake do repositório
            var repositoryFake = new Mock<IAutorRepository>();

            repositoryFake.Setup(r => r.Save(autor)).Returns(autor);

            //Fake do dominio
            var autorFake = new Mock<Autor>();

            autorFake.As<IObjectValidation>().Setup(b => b.Validate());

            IAutorService service = new AutorService(repositoryFake.Object);

            //Action
            service.Create(autorFake.Object);

            //Assert
            autorFake.As<IObjectValidation>().Verify(b => b.Validate());

            repositoryFake.Verify(r => r.Save(autorFake.Object));
        }

        [TestMethod]
        public void UpdateAutorServiceValidationAndPersistenceTest()
        {
            //Arrange
            Autor autor = ObjectMother.GetAutor();

            //Fake do repositório
            var repositoryFake = new Mock<IAutorRepository>();

            repositoryFake.Setup(r => r.Update(autor)).Returns(autor);

            //Fake do dominio
            var autorFake = new Mock<Autor>();

            autorFake.As<IObjectValidation>().Setup(b => b.Validate());

            IAutorService service = new AutorService(repositoryFake.Object);

            //Action
            service.Update(autorFake.Object);

            //Assert
            autorFake.As<IObjectValidation>().Verify(b => b.Validate());

            repositoryFake.Verify(r => r.Update(autorFake.Object));
        }

        [TestMethod]
        public void DeleteAutorServiceTest()
        {
            //Arrange
            Autor autor = null;

            //Fake do repositório
            var repositoryFake = new Mock<IAutorRepository>();

            repositoryFake.Setup(r => r.Delete(1)).Returns(autor);

            IAutorService service = new AutorService(repositoryFake.Object);

            //Action
            var autorFake = service.Remove(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));

            Assert.IsNull(autorFake);
        }

        [TestMethod]
        public void GetAutorServiceTest()
        {
            //Arrange
            Autor autor = ObjectMother.GetAutor();

            //Fake do repositório
            var repositoryFake = new Mock<IAutorRepository>();

            repositoryFake.Setup(r => r.Get(1)).Returns(autor);

            IAutorService service = new AutorService(repositoryFake.Object);

            //Action
            var autorFake = service.Get(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));

            Assert.IsNotNull(autorFake);
        }



        public object AutorFake { get; set; }
    }
}
