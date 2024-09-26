using FluentValidation;
using GestaoDeLivros.Dominio.Modelos;
using GestaoDeLivros.Servicos.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeLivros.Testes
{
    public class teste_servico_livro : TesteBase
    {
        private readonly ServicoLivro _servicoLivro;
        public teste_servico_livro()
        {
            using var serviceProvider = _services.BuildServiceProvider();
            _servicoLivro = serviceProvider.GetService<ServicoLivro>() ?? throw new Exception("Serviço não encontrado.");
        }

        [Fact]
        private void deve_criar_Livro_Com_Sucesso()
        {
            //Arrange
            var livroAhSerCriado = DadosParaCadastro();
            //Act
            var novoLivro = _servicoLivro.Criar(livroAhSerCriado);
            //Assert
            Assert.NotNull(novoLivro);
        }

        [Fact]
        private void deve_lancar_excecao_ao_criar_livro_sem_titulo()
        {
            var livroAhSerCriado = DadosParaCadastroSemTitulo();
            Assert.Throws<ValidationException>(() =>
            {
                _servicoLivro.Criar(livroAhSerCriado);
            });
        }

        [Fact]
        private void deve_lancar_excecao_ao_criar_livro_sem_autor()
        {
            var livroAhSerCriado = DadosParaCadastroSemAutor();
            Assert.Throws<ValidationException>(() =>
            {
                _servicoLivro.Criar(livroAhSerCriado);
            });
        }

        [Fact]
        private void deve_lancar_excecao_ao_criar_livro_sem_editora()
        {
            var livroAhSerCriado = DadosParaCadastroSemEditora();
            Assert.Throws<ValidationException>(() =>
            {
                _servicoLivro.Criar(livroAhSerCriado);
            });
        }

        [Fact]
        private void deve_lancar_excecao_ao_criar_livro_sem_data_da_publicacao()
        {
            var livroAhSerCriado = DadosParaCadastroSemDataDaPublicacao();
            Assert.Throws<ValidationException>(() =>
            {
                _servicoLivro.Criar(livroAhSerCriado);
            });
        }

        private Livro DadosParaCadastro()
        {
            return new Livro
            {
                Titulo = "Para teste",
                Autor = "Teste",
                Editora = "Teste", 
                DataDaPublicacao = DateTime.Now,
                Genero = Genero.Narrativo,
                ISBN = 978
            };
        }

        private Livro DadosParaCadastroSemTitulo()
        {
            return new Livro
            {
                Autor = "Teste",
                Editora = "Teste",
                DataDaPublicacao = DateTime.Now,
                Genero = Genero.Narrativo,
                ISBN = 978
            };
        }

        private Livro DadosParaCadastroSemAutor()
        {
            return new Livro
            {
                Titulo = "Para teste",
                Editora = "Teste",
                DataDaPublicacao = DateTime.Now,
                Genero = Genero.Narrativo,
                ISBN = 978
            };
        }

        private Livro DadosParaCadastroSemEditora()
        {
            return new Livro
            {
                Titulo = "Para teste",
                Autor = "Teste",
                DataDaPublicacao = DateTime.Now,
                Genero = Genero.Narrativo,
                ISBN = 978
            };
        }

        private Livro DadosParaCadastroSemDataDaPublicacao()
        {
            return new Livro
            {
                Titulo = "Para teste",
                Autor = "Teste",
                Editora = "Teste",
                Genero = Genero.Narrativo,
                ISBN = 978
            };
        }
    }
}
