using FluentValidation;
using FluentValidation.Results;

namespace VemDoBem.Domain.Dtos
{
    public class ValidacaoEndereco : AbstractValidator<EnderecoDto>
    {
        public ValidacaoEndereco()
        {
            RuleFor(d => d.Cep)
                .NotEmpty().WithMessage(Resources.CepVazio)
                .Length(8).WithMessage(Resources.TamanhoDoCepInválido);
            RuleFor(d => d.Rua).NotEmpty().WithMessage(Resources.RuaVazia);
            RuleFor(d => d.Uf).NotEmpty().WithMessage(Resources.UfVazio);
            RuleFor(d => d.Municipio).NotEmpty().WithMessage(Resources.MunicipioVazio);
        }
    }

    public static class ValidacaoEnderecoExtension
    {
        public static bool Validar(this EnderecoDto dto)
        {
            var validacao = new ValidacaoEndereco();
            dto.ResultadoValidacao = validacao.Validate(dto);
            return dto.ResultadoValidacao.IsValid;
        }
    }
}
