using FluentAssertions;
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
            var cep = "88333000";
            var rua = "Onde judas perdeu as botas";
            var uf = "SC";
            var municipio = "Guabiruba";
            var foto = new byte[]
            {
               0x01, 0x01, 0x06, 0x00, 0x00, 0x00, 0x3d, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
               0x00, 0x00
            };

            var enderecoDto = new EnderecoDto
            {
                Cep = cep,
                Rua = rua,
                Uf = uf,
                Municipio = municipio
            };
            var endereco = new Endereco(enderecoDto);

            var usuarioDto = new UsuarioDto
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Endereco = endereco,
                Foto = foto
            };

            //Act
            var usuario = new Usuario(usuarioDto);

            //Assert
            usuario.Nome.Should().Be(nome);
            usuario.Email.Should().Be(email);
            usuario.PasswordHash.Should().Be(senha);
            usuario.Endereco.Should().BeEquivalentTo(endereco);
            usuario.Foto.Length.Should().Be(foto.Length);
            usuario.Foto.Should().BeEquivalentTo(foto);
        }
    }
}
