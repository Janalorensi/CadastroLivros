using CadastroLivros.Domain.Entity;
using CadastroLivros.Domain.Exceptions;
using CadastroLivros.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Test.TesteLivro
{
    [TestClass]
    public class LivroDomainTeste
    {
        [TestMethod]
        public void CreatLivroTest()
        {
            Livro livro = ObjectMother.GetLivro();

            Assert.IsNotNull(livro);
        }

        [TestMethod]
        public void CreateAValidLivroTest()
        {
            Livro livro = ObjectMother.GetLivro();

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroTest()
        {
            Livro livro = new Livro();

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroTitulo()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.Titulo = "";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroSubTitulo()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.Subtitulo = "";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroAnoPub1()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.AnoPublicacao = 1600;

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroAnoPub2()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.AnoPublicacao = 2100;

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroAutorNull()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.AutorID = 0;

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroOrigemPublicacao()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.OrigemPublicacao = "";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroResumo()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.Resumo = "";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroResumoTamanho()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.Resumo = "Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala Lalalalala la lalalala";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroEditora()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.Editora = "";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroGenero()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.Genero = "";

            Validator.Validate(livro);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void CreateAInvalidLivroPaginas()
        {
            Livro livro = ObjectMother.GetLivro();

            livro.NumeroDePaginas = 0;

            Validator.Validate(livro);
        }
    }
}
