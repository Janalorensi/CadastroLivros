using CadastroLivros.Aplication;
using CadastroLivros.Data;
using CadastroLivros.Domain.Entity;
using Data.Access.Twitter.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroLivros.Apresentation
{
    public partial class Form1 : Form
    {
        ILivroService _livroService = new LivroService(new LivroRepository());

        IAutorService _autorService = new AutorService(new AutorRepository());

        IPostService _postService = new PostService(new PostRepositoryTwitterImpl());

        public Form1()
        {
            InitializeComponent();

            AtualizarGridLivros();

            AtualizarGridAutores();
        }

    
        private void AtualizarGridAutores()
        {
            var novaListAutores = _autorService.GetAll().Select(autor => new
            {
                ID = autor.ID,
                Nome = autor.Nome,
                Idade = autor.Idade
            }).ToList();

            gridAutor.DataSource = null; //Limpa o grid;
            gridAutor.DataSource = novaListAutores;
            gridAutor.Refresh();
        }

        private void AtualizarGridLivros()
        {
            var novaListLivros = _livroService.GetAll().Select(livro => new
            {
                ID = livro.ID,
                Titulo = livro.Titulo,
                Ano = livro.AnoPublicacao
            }).ToList();

            gridLivro.DataSource = null; //Limpa o grid;
            gridLivro.DataSource = novaListLivros;
            gridLivro.Refresh();
        }

        private void btLimparLivro_Click(object sender, EventArgs e)
        {
            tbTitulo.Text = "";
            tbSubtitulo.Text = "";
            tbAno.Text = "";
            tbAutor.Text = "";
            tbOrigem.Text = "";
            tbEditora.Text = "";
            tbGenero.Text = "";
            tbPaginas.Text = "";
            tbResumo.Text = "";
        }

        private void btCadastrarLivro_Click(object sender, EventArgs e)
        {
            try
            {
                Livro livro = new Livro();

                int idAutor = 0;
                int.TryParse(tbAutor.Text, out idAutor);
                if (tbAutor.Text == "" || idAutor == 0)
                    MessageBox.Show("Deve ser informado o id do autor do livro");
                Autor autor = GetAutor(idAutor);
                if (autor == null)
                    MessageBox.Show("Autor não encontrado");
                //livro.Autor = autor;
                livro.AutorID = idAutor;
                livro.Titulo = tbTitulo.Text;
                livro.Subtitulo = tbSubtitulo.Text;
                livro.AnoPublicacao = Convert.ToInt32(tbAno.Text);                
                livro.OrigemPublicacao = tbOrigem.Text;
                livro.Resumo = tbResumo.Text;
                livro.Editora = tbEditora.Text;
                livro.Genero = tbGenero.Text;
                livro.NumeroDePaginas = Convert.ToInt32(tbPaginas.Text);

                _livroService.Create(livro);

                AtualizarGridLivros();
                MessageBox.Show("Livro Cadastrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Autor GetAutor(int idAutor)
        {
            Autor autor = _autorService.Get(idAutor);
            return autor;
        }

        private void btRemoverLivro_Click(object sender, EventArgs e)
        {
            if (gridLivro.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridLivro.SelectedRows[0];

                int idLivro = (int)row.Cells["ID"].Value;

                _livroService.Remove(idLivro);
            }
            else
            {
                MessageBox.Show("Selecione uma linha no grid");
            }

            AtualizarGridLivros();
        }

        private void btPublicarTwitter_Click(object sender, EventArgs e)
        {
            if (gridLivro.SelectedRows.Count != 0)
            {
               DataGridViewRow row = this.gridAutor.SelectedRows[0];

               string titulo = (string)row.Cells["Titulo"].Value;

               Post post = new Post();

               post.PostMessage = "O livro: " + titulo + "foi adicionado ao acervo.";

                post.PostDate = DateTime.Now;

                _postService.SaveOrUpdate(post);
            }
            else
            {
                MessageBox.Show("Selecione uma linha no grid");
            }            
        }

        private void btLimparAutor_Click(object sender, EventArgs e)
        {
            tbNome.Text = "";
            tbNacionalidade.Text = "";
            tbBibliogradia.Text = "";
            tbIdade.Text = "";
        }

        private void btCadastrarAutor_Click(object sender, EventArgs e)
        {
            try
            {
                Autor autor = new Autor();
                autor.Nome = tbNome.Text;
                autor.Nacionalidade = tbNacionalidade.Text;
                autor.Idade = Convert.ToInt32(tbIdade.Text);
                autor.Bibliografia = tbBibliogradia.Text;

                _autorService.Create(autor);
                AtualizarGridAutores();
                MessageBox.Show("Autor Cadastrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btRemoverAutor_Click(object sender, EventArgs e)
        {
            if (gridAutor.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.gridAutor.SelectedRows[0];

                int idAutor = (int)row.Cells["ID"].Value;

                _autorService.Remove(idAutor);
            }
            else
            {
                MessageBox.Show("Selecione uma linha no grid");
            }

            AtualizarGridAutores();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
