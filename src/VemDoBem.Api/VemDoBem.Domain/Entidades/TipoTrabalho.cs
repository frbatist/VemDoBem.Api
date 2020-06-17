using System;

namespace VemDoBem.Domain.Entidades
{
    public class TipoTrabalho : Entidade<short>
    {
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        const string MensagemErro = "Tipo de trabalho inválido. É necessário informar a descrição!";

        protected TipoTrabalho() { }

        public TipoTrabalho(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new InvalidOperationException(MensagemErro);
            Descricao = descricao;
            Ativo = true;
        }
    }
}
