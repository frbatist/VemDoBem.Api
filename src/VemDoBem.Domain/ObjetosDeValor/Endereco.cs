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

        const string MensagemErro = "Endereço inválido: " +
            "Cep: {0}, " +
            "Rua: {1}, " +
            "Uf: {2}, " +
            "Município: {3}.";

        public Endereco(EnderecoDto enderecoDto)
        {
            if (!enderecoDto.Validar())
                throw new InvalidOperationException(enderecoDto.MensagemErroValidacao);
            Cep = enderecoDto.Cep;
            Rua = enderecoDto.Rua;
            Numero = enderecoDto.Numero;
            Uf = enderecoDto.Uf;
            Municipio = enderecoDto.Municipio;
        }
    }
}
