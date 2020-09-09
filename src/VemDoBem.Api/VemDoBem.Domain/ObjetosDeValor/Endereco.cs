using System;
using VemDoBem.Domain.Dtos;

namespace VemDoBem.Domain.ObjetosDeValor
{
    public class Endereco 
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public short? Numero { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }

        protected Endereco() { }

        public Endereco(EnderecoDto enderecoDto)
        {
            enderecoDto.ValidarELancarExcessao();                
            Cep = enderecoDto.Cep;
            Rua = enderecoDto.Rua;
            Numero = enderecoDto.Numero;
            Uf = enderecoDto.Uf;
            Municipio = enderecoDto.Municipio;
        }
    }
}
