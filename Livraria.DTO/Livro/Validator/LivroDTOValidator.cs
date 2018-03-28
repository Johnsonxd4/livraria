using FluentValidation;

namespace Livraria.DTO.Livro.Validator
{
    public class LivroDTOValidator 
    {
        public class SalvarValidator : AbstractValidator<LivroDTO.Salvar>
        {
            public SalvarValidator()
            {
                RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o título do livro");
            }
        }

        public class AtualizarValidator : AbstractValidator<LivroDTO.Atualizar>
        {
            public AtualizarValidator()
            {
                RuleFor(x => x.Codigo)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Informe o código do livro que deseja atualizar");

                RuleFor(x => x.Titulo)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Nome do livro não pode ser vazio");
            }
        }
    }
}
