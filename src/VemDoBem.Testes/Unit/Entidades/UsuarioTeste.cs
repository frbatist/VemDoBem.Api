using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using VemDoBem.Domain;
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
            var senha = "Ahjfs4f54asd=";
            var foto = new byte[]
            {
               0x01, 0x01, 0x06, 0x00, 0x00, 0x00, 0x3d, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
               0x00, 0x00
            };
            var experiencias = new List<Experiencia>
            {
                new Experiencia(new ExperienciaDto { Descricao = "nova experiencia bem legal", TipoTrabalho = new TipoTrabalho("Tipo trabalho novo") })
            };

            var usuarioDto = new UsuarioDto
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Endereco = EnderecoPadrao,
                Foto = foto,
                Experiencias = experiencias
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
            usuario.Experiencias.Should().HaveCount(1);
        }

        [Theory]
        [ClassData(typeof(UsuarioDtoDados))]
        public void Usuario_deve_lancar_excessao_caso_não_seja_informado_algum_dos_campos_obrigatorios(UsuarioDto usuarioDto, string mensagem)
        { 
            //Act
            Action act = () => new Usuario(usuarioDto);

            //Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage(mensagem);

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
                var nomeTamanhoInvalido = new String('a', 81);
                var senhaValida = "Ab9iu3wer12@";

                yield return new object[] { new UsuarioDto { Nome = null, Email = "teste@teste.com", Senha = senhaValida, Endereco = EnderecoPadrao }, Resources.NomeUsuarioVazio };
                yield return new object[] { new UsuarioDto { Nome = "a", Email = "teste@teste.com", Senha = senhaValida, Endereco = EnderecoPadrao }, Resources.NomeUsuarioMenorQuePermitido };
                yield return new object[] { new UsuarioDto { Nome = nomeTamanhoInvalido, Email = "teste@teste.com", Senha = senhaValida, Endereco = EnderecoPadrao }, Resources.NomeUsuarioMaiorQuePermitido };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço legal", Email = null, Senha = senhaValida, Endereco = EnderecoPadrao }, Resources.EmailUsuarioVazio };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço legal", Email = "adfjahjsdaaaaaa", Senha = senhaValida, Endereco = EnderecoPadrao }, Resources.EmailInvalido };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço legal", Email = "teste@teste.com", Senha = null, Endereco = EnderecoPadrao }, Resources.SenhaUsuarioVazia };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço legal", Email = "teste@teste.com", Senha = "aiaiai", Endereco = EnderecoPadrao }, Resources.SenhaUsuarioInvalida };
                yield return new object[] { new UsuarioDto { Nome = "Jagunço legal", Email = "teste@teste.com", Senha = senhaValida, Endereco = null }, Resources.EnderecoVazio };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
