using CadastroLivros.Domain.Entity;
using CadastroLivros.Domain.Exceptions;
using CadastroLivros.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Test.TesteAutor
{
    [TestClass]
    public class AutorDomainTeste
    {
        [TestMethod]
        public void CreatAutorTest()
        {
            Autor autor = ObjectMother.GetAutor();

            Assert.IsNotNull(autor);
        }

        [TestMethod]
        public void CreateAValidAutorTest()
        {
            Autor autor = ObjectMother.GetAutor();

            Validator.Validate(autor);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidAutorTest()
        {
            Autor autor = new Autor();

            Validator.Validate(autor);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidAutorNome()
        {
            Autor autor = ObjectMother.GetAutor();

            autor.Nome = "";

            Validator.Validate(autor);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidAutorNacionalidade()
        {
            Autor autor = ObjectMother.GetAutor();

            autor.Nacionalidade = "";

            Validator.Validate(autor);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidAutorIdade()
        {
            Autor autor = ObjectMother.GetAutor();

            autor.Idade = 8;

            Validator.Validate(autor);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidAutorBiografia()
        {
            Autor autor = ObjectMother.GetAutor();

            autor.Bibliografia = "";

            Validator.Validate(autor);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidAutorBiografiaTamanho()
        {
            Autor autor = ObjectMother.GetAutor();

            autor.Bibliografia = "Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala";

            Validator.Validate(autor);
        }
    }
}
