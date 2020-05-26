using System;

namespace VemDoBem.Domain.Dtos
{
    public static class ValidacaoInstituicaoExtension
    {
        public static bool Validar(this InstituicaoDto dto)
        {
            var validacao = new ValidacaoInstituicao();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            return dto.EhValido;
        }

        public static void ValidarELancarExcessao(this InstituicaoDto dto)
        {
            var validacao = new ValidacaoInstituicao();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            if (!dto.EhValido)
            {
                throw new InvalidOperationException(dto.MensagemErroValidacao);
            }
        }
    }
}
