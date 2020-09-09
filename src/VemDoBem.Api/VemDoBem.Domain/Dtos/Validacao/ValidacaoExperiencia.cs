using FluentValidation;

namespace VemDoBem.Domain.Dtos.Validacao
{
    public class ValidacaoExperiencia : AbstractValidator<ExperienciaDto>
    {
        public ValidacaoExperiencia()
        {
            RuleFor(d => d.Descricao)
                .NotEmpty().WithMessage(Resources.DescricaoExperienciaVazia)
                .MaximumLength(250).WithMessage(Resources.DescricaoExperienciaMaiorQuePermitido)
                .MinimumLength(10).WithMessage(Resources.DescricaoExperienciaMenorQuePermitido);

            RuleFor(d => d.TipoTrabalho)
                .NotEmpty().WithMessage(Resources.TipoDeTrabalhoVazio);
        }
    }
}
