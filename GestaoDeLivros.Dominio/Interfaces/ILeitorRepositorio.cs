using GestaoDeLivros.Dominio.Modelos;
using System.Collections.Generic;

namespace GestaoDeLivros.Dominio.Interfaces
{
    public interface ILeitorRepositorio
    {
        public List<Leitor> ObterTodos();
        public Leitor ObterPorId(int id);
        public Leitor Criar(Leitor leitor);
        public void Atualizar(int id, Leitor leitor);
        public void Remover(int id);
    }
}
