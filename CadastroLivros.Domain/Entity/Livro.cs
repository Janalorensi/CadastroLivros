using CadastroLivros.Domain.Exceptions;
using CadastroLivros.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Domain.Entity
{
    public class Livro : IObjectValidation
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public int AnoPublicacao { get; set; }
        public int AutorID { get; set; }
        public virtual Autor Autor { get; set; }
        public string OrigemPublicacao { get; set; }
        public string Resumo { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public int NumeroDePaginas { get; set; }

        public void Validate()
        {
            if (Titulo == "")
                throw new DomainException("Titulo deve estar preenchido.");

            if (Subtitulo == "")
                throw new DomainException("Subtitulo deve estar preenchido.");

            if (AnoPublicacao < 1800 || AnoPublicacao > DateTime.Now.Year)
                throw new DomainException("Ano de Publicação não permitido.");

            if (AutorID <= 0)
                throw new DomainException("Autor deve ser cadastrado.");

            if (OrigemPublicacao == "")
                throw new DomainException("Origem de publicação deve estar preenchido.");

            if (Resumo == "")
                throw new DomainException("Resumo deve estar preenchido.");

            if (Resumo.Length > 500)
                throw new DomainException("O resumo deve conter no máximo 500 caracteres.");

            if (Editora == "")
                throw new DomainException("Editora deve estar preenchido.");

            if (Genero == "")
                throw new DomainException("Genero deve estar preenchido.");

            if (NumeroDePaginas <= 0)
                throw new DomainException("Número de páginas deve ser maior que zero.");
        }
    }
}
