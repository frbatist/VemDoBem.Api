using System;
using VemDoBem.Domain.Dtos;

namespace VemDoBem.Domain.ObjetosDeValor
{
    public class Endereco 
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public short Numero { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }

        const string MensagemErro = "Endereço inválido: " +
            "Cep: {0}, " +
            "Rua: {1}, " +
            "Uf: {2}, " +
            "Município: {3}.";

        public Endereco(EnderecoDto enderecoDto)
        {
            if (EnderecoInvalido(enderecoDto))
                throw new InvalidOperationException(string.Format(MensagemErro, enderecoDto.Cep ?? "*vazio*", enderecoDto.Rua ?? "*vazio*", enderecoDto.Uf ?? "*vazio*", enderecoDto.Municipio ?? "*vazio*"));
            Cep = enderecoDto.Cep;
            Rua = enderecoDto.Rua;
            Numero = enderecoDto.Numero;
            Uf = enderecoDto.Uf;
            Municipio = enderecoDto.Municipio;
        }

        private bool EnderecoInvalido(EnderecoDto enderecoDto)
        {
            return string.IsNullOrEmpty(enderecoDto.Cep) || string.IsNullOrEmpty(enderecoDto.Rua) || string.IsNullOrEmpty(enderecoDto.Uf) || string.IsNullOrEmpty(enderecoDto.Municipio);
        }
    }
}
