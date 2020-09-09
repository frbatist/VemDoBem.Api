using System;

namespace VemDoBem.Domain.Dtos
{
    public static class ValidacaoUsuarioExtension
    {
        public static bool Validar(this UsuarioDto dto)
        {
            var validacao = new ValidacaoUsuario();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            return dto.EhValido;
        }

        public static void ValidarELancarExcessao(this UsuarioDto dto)
        {
            var validacao = new ValidacaoUsuario();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            if (!dto.EhValido)
            {
                throw new InvalidOperationException(dto.MensagemErroValidacao);
            }
        }
    }
}
