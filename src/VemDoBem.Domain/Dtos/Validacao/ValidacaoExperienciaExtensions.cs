using System;
using VemDoBem.Domain.Dtos.Validacao;

namespace VemDoBem.Domain.Dtos
{
    public static class ValidacaoExperienciaExrensions
    {
        public static bool Validar(this ExperienciaDto dto)
        {
            var validacao = new ValidacaoExperiencia();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            return dto.EhValido;
        }

        public static void ValidarELancarExcessao(this ExperienciaDto dto)
        {
            var validacao = new ValidacaoExperiencia();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            if (!dto.EhValido)
            {
                throw new InvalidOperationException(dto.MensagemErroValidacao);
            }
        }
    }
}
