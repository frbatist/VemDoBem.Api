using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using VemDoBem.Domain;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;
using Xunit;

namespace VemDoBem.Testes.Unit.Entidades
{
    public class EnderecoTeste
    {
        [Fact]
        public void Endereco_deve_construir_um_endereco_valido()
        {
            //Arrange
            var cep = "88333000";
            var rua = "Onde judas perdeu as botas";
            var uf = "SC";
            var municipio = "Guabiruba";

            var enderecoDto = new EnderecoDto
            {
                Cep = cep,
                Rua = rua,
                Uf = uf,
                Municipio = municipio
            };

            //Act
            var endereco = new Endereco(enderecoDto);

            //Assert
            endereco.Cep.Should().Be(cep);
            endereco.Rua.Should().Be(rua);
            endereco.Uf.Should().Be(uf);
            endereco.Municipio.Should().Be(municipio);
        }

        [Theory]
        [ClassData(typeof(EnderecoDtoDados))]
        public void Endereco_deve_lancar_excessao_caso_não_seja_informado_algum_dos_campos_obrigatorios(EnderecoDto enderecoDto, string mensagem)
        {
            //Act
            Action act = () => new Endereco(enderecoDto);

            //Assert
            act.Should().Throw<InvalidOperationException>()                
                .WithMessage(mensagem);
        }

        public class EnderecoDtoDados : IEnumerable<object[]>
        {            
            public IEnumerator<object[]> GetEnumerator()
            {
                var mensagemErroCompleta = $"{Resources.CepVazio} | {Resources.RuaVazia} | {Resources.UfVazio} | {Resources.MunicipioVazio}";
                yield return new object[] { new EnderecoDto { Cep = null, Rua = "teste", Uf = "SC", Municipio = "Teste" }, Resources.CepVazio };
                yield return new object[] { new EnderecoDto { Cep = "88333000", Rua = null, Uf = "SC", Municipio = "Teste" }, Resources.RuaVazia };
                yield return new object[] { new EnderecoDto { Cep = "88333000", Rua = "teste", Uf = null, Municipio = "Teste" }, Resources.UfVazio };
                yield return new object[] { new EnderecoDto { Cep = "88333000", Rua = "teste", Uf = "SC", Municipio = null }, Resources.MunicipioVazio };
                yield return new object[] { new EnderecoDto { Cep = null, Rua = null, Uf = null, Municipio = null }, mensagemErroCompleta };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
