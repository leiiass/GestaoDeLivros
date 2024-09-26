using FluentValidation;
using GestaoDeLivros.Dominio.Modelos;

namespace GestaoDeLivros.Dominio.Validadores
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(x => x.Titulo).NotNull().NotEmpty().WithMessage("O titulo é obrigatório.");
            RuleFor(x => x.Editora).NotNull().NotEmpty().WithMessage("A editora é obrigatório.");
            RuleFor(x => x.Autor).NotEmpty().NotNull().WithMessage("O autor é obrigatório.");
            RuleFor(x => x.ISBN).NotEmpty().NotNull().WithMessage("O ISBN é obrigatório.");
            RuleFor(x => x.DataDaPublicacao).NotEmpty().NotNull().WithMessage("A data da publicação é obrigatória.");
            RuleFor(x => x.Genero).IsInEnum().WithMessage("O genero é obrigatorio");
        }
    }
}
