using FluentValidation.Results;

namespace VemDoBem.Domain.Dtos
{
    public class DtoBase
    {
        private const string SeparadorErros = " | ";
        private ValidationResult _resultadoValidacao;
        internal void AdicionarResultadoValidacao(ValidationResult validationResult) 
        { 
            _resultadoValidacao = validationResult; 
        }        
        public string MensagemErroValidacao => _resultadoValidacao == null ? "" : _resultadoValidacao.ToString(SeparadorErros);
        public bool EhValido => _resultadoValidacao == null ? false : _resultadoValidacao.IsValid;
    }
}
