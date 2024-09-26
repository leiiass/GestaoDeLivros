using GestaoDeLivros.Dominio.Modelos;
using System.Collections.Generic;

namespace GestaoDeLivros.Dominio.Interfaces
{
    public interface ILivroRepositorio
    {
        public List<Livro> ObterTodos();
        public Livro ObterPorId(int id);
        public Livro Criar(Livro livro);
        public void Atualizar(int id, Livro livro);
        public void Remover(int id);
    }
}
