using FluentValidation.Attributes;
using Livraria.DTO.Livro.Validator;

namespace Livraria.DTO.Livro
{
    public class LivroDTO
    {
        [Validator(typeof(LivroDTOValidator.SalvarValidator))]
        public class Salvar
        {
            public string Titulo { get; set; }
        }

        [Validator(typeof(LivroDTOValidator.AtualizarValidator))]
        public class Atualizar
        {
            public int Codigo { get; set; }
            public string Titulo { get; set; }
        }
    }
}
