using System;
using VemDoBem.Domain.Dtos.Validacao;

namespace VemDoBem.Domain.Dtos
{
    public static class ValidacaoVoluntarioExtensions
    {
        public static bool Validar(this VoluntarioDto dto)
        {
            var validacao = new ValidacaoVoluntario();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            return dto.EhValido;
        }

        public static void ValidarELancarExcessao(this VoluntarioDto dto)
        {
            var validacao = new ValidacaoVoluntario();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            if (!dto.EhValido)
            {
                throw new InvalidOperationException(dto.MensagemErroValidacao);
            }
        }
    }
}
