using GestaoDeLivros.Dominio.Interfaces;
using GestaoDeLivros.Dominio.Modelos;
using LinqToDB.Data;
using LinqToDB;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LinqToDB.SqlQuery;

namespace GestaoDeLivros.Infraestrutura.Repositorios
{
    public class RepositorioLivro : ILivroRepositorio
    {
        private readonly string connectionString = "Data Source=DESKTOP-RCN2RNI;Initial Catalog=LivrariaTestes;User ID=sa;Password=leia1234;Encrypt=False";
        private readonly DataConnection _conexaoBancoDeDados;
        public RepositorioLivro()
        {
            _conexaoBancoDeDados = new DataConnection(new DataOptions().UseSqlServer(connectionString));
        }
        public List<Livro> ObterTodos()
        {
            using var conexao = _conexaoBancoDeDados;
            var livros = conexao.GetTable<Livro>();
            return livros.ToList();
        }

        public Livro ObterPorId(int id)
        {
            using var conexao = _conexaoBancoDeDados;
            var livro = conexao
                .GetTable<Livro>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return livro;
        }

        public Livro Criar(Livro livro)
        {
            using var conexao = _conexaoBancoDeDados;
            var novo = conexao.InsertWithInt32Identity(livro);
            livro.Id = novo;
            return livro;
        }

        public void Atualizar(int id, Livro livro)
        {
            using var conexao = _conexaoBancoDeDados;
            var livroAhSerAtualizado = conexao
                .GetTable<Livro>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (livroAhSerAtualizado == null)
            {
                throw new SqlException($"Livro com Id {id} não encontrado.");
            }

            livroAhSerAtualizado.Titulo = livro.Titulo;
            livroAhSerAtualizado.Autor = livro.Autor;
            livroAhSerAtualizado.Editora = livro.Editora;
            livroAhSerAtualizado.DataDaPublicacao = livro.DataDaPublicacao;
            livroAhSerAtualizado.ISBN = livro.ISBN;
            livroAhSerAtualizado.Genero = livro.Genero;

            conexao.Update(livroAhSerAtualizado);
        }

        public void Remover(int id)
        {
            using var conexao = _conexaoBancoDeDados;
            var livroAhSerRemovido = conexao
                .GetTable<Livro>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            conexao.Delete(livroAhSerRemovido);
        }
    }
}
