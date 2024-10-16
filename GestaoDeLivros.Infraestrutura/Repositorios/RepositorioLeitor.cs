using GestaoDeLivros.Dominio.Interfaces;
using GestaoDeLivros.Dominio.Modelos;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoDeLivros.Infraestrutura.Repositorios
{
    public class RepositorioLeitor : ILeitorRepositorio
    {
        private readonly string connectionString = "Data Source=DESKTOP-RCN2RNI;Initial Catalog=LivrariaTestes;User ID=sa;Password=leia1234;Encrypt=False";
        private readonly DataConnection _conexaoBancoDeDados;
        public RepositorioLeitor()
        {
            _conexaoBancoDeDados = new DataConnection(new DataOptions().UseSqlServer(connectionString));
        }
        public List<Leitor> ObterTodos()
        {
            using var conexao = _conexaoBancoDeDados;
            return conexao.GetTable<Leitor>().ToList();
        }

        public Leitor ObterPorId(int id)
        {
            using var conexao = _conexaoBancoDeDados;
            return conexao
                .GetTable<Leitor>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

        }

        public Leitor Criar(Leitor leitor)
        {
            using var conexao = _conexaoBancoDeDados;
            var novoLeitor = conexao.InsertWithInt32Identity(leitor);
            leitor.Id = novoLeitor;
            return leitor;
        }

        public void Atualizar(int id, Leitor leitor)
        {
            using var conexao = _conexaoBancoDeDados;
            var leitorAhSerAtualizado = conexao
                .GetTable<Leitor>()
                .Where(x => x.Id == id)
                .FirstOrDefault()
                ?? throw new SqlException($"Leitor não encontrado com id ${id}.");
           
            leitorAhSerAtualizado.Nome = leitor.Nome;
            leitorAhSerAtualizado.GeneroPreferido = leitor.GeneroPreferido;
            leitorAhSerAtualizado.QuantidadeDeLivrosLidos = leitor.QuantidadeDeLivrosLidos;
            leitorAhSerAtualizado.LivrosLidos = leitor.LivrosLidos;

            conexao.Update(leitorAhSerAtualizado);
        }

        public void Remover(int id)
        {
            using var conexao = _conexaoBancoDeDados;
            var leitorAhSerRemovido = conexao
                .GetTable<Leitor>()
                .Where(x => x.Id == id)
                .FirstOrDefault() ?? 
                throw new SqlException($"Leitor não encontrado com id ${id}.");

            conexao.Delete(leitorAhSerRemovido);
        }
    }
}
