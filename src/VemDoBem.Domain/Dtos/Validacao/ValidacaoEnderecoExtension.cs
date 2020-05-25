using System;

namespace VemDoBem.Domain.Dtos
{
    public static class ValidacaoEnderecoExtension
    {
        public static bool Validar(this EnderecoDto dto)
        {
            var validacao = new ValidacaoEndereco();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            return dto.EhValido;
        }

        public static void ValidarELancarExcessao(this EnderecoDto dto)
        {
            var validacao = new ValidacaoEndereco();
            dto.AdicionarResultadoValidacao(validacao.Validate(dto));
            if (!dto.EhValido) 
            {
                throw new InvalidOperationException(dto.MensagemErroValidacao);
            }
        }
    }
}
