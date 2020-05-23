using FluentValidation.Results;

namespace VemDoBem.Domain.Dtos
{
    public class DtoBase
    {
        private const string SeparadorErros = " | ";
        public ValidationResult ResultadoValidacao { get; set; }
        public string MensagemErroValidacao => ResultadoValidacao.ToString(SeparadorErros);
    }
}
