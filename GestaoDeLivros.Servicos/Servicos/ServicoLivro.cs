using FluentValidation;
using GestaoDeLivros.Dominio.Interfaces;
using GestaoDeLivros.Dominio.Modelos;
using System.Collections.Generic;

namespace GestaoDeLivros.Servicos.Servicos
{
    public class ServicoLivro
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IValidator<Livro> _validator;
        public ServicoLivro(ILivroRepositorio livroRepositorio, IValidator<Livro> livroValidator)
        {
            _livroRepositorio = livroRepositorio;
            _validator = livroValidator;
        }

        public List<Livro> ObterTodos()
        {
            var livro = _livroRepositorio.ObterTodos();
            return livro;
        }

        public Livro ObterPorId(int id)
        {
            var livro = _livroRepositorio.ObterPorId(id);
            return livro;
        }

        public Livro Criar(Livro livro)
        {
            _validator.ValidateAndThrow(livro);
            var livroAhSerCriado = _livroRepositorio.Criar(livro);
            return livroAhSerCriado;
        }

        public void Atualizar(int id, Livro livro)
        {
            _livroRepositorio.Atualizar(id, livro);
        }

        public void Remover(int id)
        {
            _livroRepositorio.Remover(id);
        }
    }
}
