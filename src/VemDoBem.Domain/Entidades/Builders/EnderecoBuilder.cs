using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades.Builders
{
    public class EnderecoBuilder
    {
        private string _cep = "88333000";
        private string _rua = "distante";
        private string _uf = "SP";
        private string _municipio = "Super distante";

        public EnderecoDto ConstruirDto()
        {
            return new EnderecoDto
            {
                Cep = _cep,
                Rua = _rua,
                Uf = _uf,
                Municipio = _municipio
            };
        }

        public Endereco Construir()
        {
            return new Endereco(ConstruirDto());
        }
    }
}
