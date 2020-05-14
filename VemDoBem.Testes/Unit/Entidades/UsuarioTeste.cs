using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.Entidades;
using VemDoBem.Domain.ObjetosDeValor;
using Xunit;

namespace VemDoBem.Testes.Unit.Entidades
{
    public class UsuarioTeste
    {
        [Fact]
        public void Usuario_deve_construir_um_usuário_valido()
        {
            //Arrange
            var nome = "Francisco Trinaldo";
            var email = "massaranduba@bol.com.br";
            var senha = "ahjfs4f54asd=";
            var foto = new byte[]
            {
               0x01, 0x01, 0x06, 0x00, 0x00, 0x00, 0x3d, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
               0x00, 0x00
            };

            var usuarioDto = new UsuarioDto
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Endereco = EnderecoPadrao,
                Foto = foto
            };

            //Act
            var usuario = new Usuario(usuarioDto);

            //Assert
            usuario.Nome.Should().Be(nome);
            usuario.Email.Should().Be(email);
            usuario.PasswordHash.Should().Be(senha);
            usuario.Endereco.Should().BeEquivalentTo(EnderecoPadrao);
            usuario.Foto.Length.Should().Be(foto.Length);
            usuario.Foto.Should().BeEquivalentTo(foto);
        }

        [Theory]
        [ClassData(typeof(UsuarioDtoDados))]
        public void Usuario_deve_lancar_excessao_caso_não_seja_informado_algum_dos_campos_obrigatorios(UsuarioDto usuarioDto)
        { 
            //Arrange
            var mensagemErro = $"Usuário inválido: " +
                $"Mome: { usuarioDto.Nome ?? "*vazio*"}, " +
                $"Email: { usuarioDto.Email ?? "*vazio*"}, " +
                $"Senha: { usuarioDto.Senha ?? "*vazio*"}, " +
                $"Endereco: { usuarioDto.Endereco?.Cep ?? "*vazio*" }.";

            //Act
            Action act = () => new Usuario(usuarioDto);

            //Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage(mensagemErro);

        }

        static Endereco EnderecoPadrao => new Endereco(new EnderecoDto
        {
            Cep = "88333000",
            Rua = "distante",
            Uf = "SP",
            Municipio = "Super distante"
        });

        public class UsuarioDtoDados : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new UsuarioDto { Nome = null, Email = "teste@teste.com", Senha = "asdfhjs==!!", Endereco = EnderecoPadrao } };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço", Email = null, Senha = "asdfhjs==!!", Endereco = EnderecoPadrao } };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço", Email = "teste@teste.com", Senha = null, Endereco = EnderecoPadrao } };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço", Email = "teste@teste.com", Senha = "asdfhjs==!!", Endereco = null } };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
