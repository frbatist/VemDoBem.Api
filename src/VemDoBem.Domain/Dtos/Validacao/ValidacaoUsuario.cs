using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace VemDoBem.Domain.Dtos
{
    public class ValidacaoUsuario : AbstractValidator<UsuarioDto>
    {
        private const string PadraoSenha = @"(?=^.{8,}$)((?=.*\d)(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
        public ValidacaoUsuario()
        {
            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage(Resources.NomeUsuarioVazio)
                .MaximumLength(80).WithMessage(Resources.NomeUsuarioMaiorQuePermitido)
                .MinimumLength(10).WithMessage(Resources.NomeUsuarioMenorQuePermitido);

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage(Resources.EmailUsuarioVazio)
                .EmailAddress().WithMessage(Resources.EmailInvalido);

            RuleFor(d => d.Senha)
                .NotEmpty().WithMessage(Resources.SenhaUsuarioVazia); ;

            RuleFor(d => d.Senha)
                .Must(ValidarSenha).WithMessage(Resources.SenhaUsuarioInvalida).Unless(d => string.IsNullOrEmpty(d.Senha));

            RuleFor(d => d.Endereco)
                .NotNull().WithMessage(Resources.EnderecoUsuarioVazio);
        }

        private bool ValidarSenha(string senha)
        {
            var valida = Regex.IsMatch(senha, PadraoSenha);
            return valida;
        }
    }
}
