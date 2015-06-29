using CadastroLivros.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Test
{
    public class ObjectMother
    {
        public static Livro GetLivro()
        {
            Livro livro = new Livro();

            livro.Titulo = "A historia da Jana.";

            livro.Subtitulo = "Baseada em fatos reais";

            livro.AnoPublicacao = 2015;

            livro.AutorID = 1;

            livro.OrigemPublicacao = "Brasil";

            livro.Resumo = "Conta a saga de uma universitaria em sua jornada na programação";

            livro.Editora = "Uniplac";

            livro.Genero = "Drama";

            livro.NumeroDePaginas = 715;

            return livro;
        }

        public static Autor GetAutor()
        {
            Autor autor = new Autor();

            autor.Nome = "Jana";

            autor.Idade = 21;

            autor.Nacionalidade = "Brasileira";

            autor.Bibliografia = "Autora renomada com varias publicações baseadas em sua vida, todas as publicações são Dramas";

            return autor;
        }

    }
 }

