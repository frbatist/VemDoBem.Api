using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace VemDoBem.Domain.Dtos
{
    public class ValidacaoInstituicao : AbstractValidator<InstituicaoDto>
    {        
        public ValidacaoInstituicao()
        {
            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage(Resources.NomeInstituicaoVazio)
                .MaximumLength(120).WithMessage(Resources.NomeInstituicaoMaiorQuePermitido);
            RuleFor(d => d.Nome).MinimumLength(10).WithMessage(Resources.NomeInstituicaoMenorQuePermitido).Unless(d=> string.IsNullOrEmpty(d.Nome));

            RuleFor(d => d.Descricao)
                .NotEmpty().WithMessage(Resources.DescricaoInstituicaoVazio)
                .MaximumLength(250).WithMessage(Resources.DescricaoInstituicaoMaiorQuePermitido);
            RuleFor(d => d.Descricao).MinimumLength(10).WithMessage(Resources.DescricaoInstituicaoMenorQuePermitido).Unless(d => string.IsNullOrEmpty(d.Descricao));

            RuleFor(d => d.IdUsuarioResponsavel).NotEmpty().WithMessage(Resources.IdUsuarioResponsavelVazio);

            RuleFor(d => d.Endereco)
                .NotNull().WithMessage(Resources.EnderecoVazio);
        }
    }
}
