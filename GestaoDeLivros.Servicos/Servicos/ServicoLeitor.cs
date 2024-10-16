using GestaoDeLivros.Dominio.Interfaces;
using GestaoDeLivros.Dominio.Modelos;
using System.Collections.Generic;

namespace GestaoDeLivros.Servicos.Servicos
{
    public class ServicoLeitor
    {
        private readonly ILeitorRepositorio _leitorRepositorio;

        public ServicoLeitor(ILeitorRepositorio leitorRepositorio)
        {
            _leitorRepositorio = leitorRepositorio;
        }

        public List<Leitor> ObterTodos()
        {
            return _leitorRepositorio.ObterTodos();
        }

        public Leitor ObterPorId(int id)
        {
            return _leitorRepositorio.ObterPorId(id);
        }

        public Leitor Criar(Leitor leitor)
        {
            //validaçao
            var novoLeitor = _leitorRepositorio.Criar(leitor);
            return novoLeitor;
        }

        public void Atualizar(int id, Leitor leitor)
        {
            //validar
           _leitorRepositorio.Atualizar(id, leitor);
        }

        public void Remover(int id)
        {
            _leitorRepositorio.Remover(id);
        }
    }
}
