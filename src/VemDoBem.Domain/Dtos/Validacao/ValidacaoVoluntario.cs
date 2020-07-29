using FluentValidation;

namespace VemDoBem.Domain.Dtos.Validacao
{
    public class ValidacaoVoluntario : AbstractValidator<VoluntarioDto>
    {
        public ValidacaoVoluntario()
        {
            RuleFor(d => d.IdUsuario).NotEmpty().WithMessage(Resources.IdUsuarioVazio);
            RuleFor(d => d.IdInstituicao).NotEmpty().WithMessage(Resources.IdInstituicaoVazio);
        }
    }
}
