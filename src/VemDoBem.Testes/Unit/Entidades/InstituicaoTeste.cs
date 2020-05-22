using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.Entidades;
using VemDoBem.Domain.ObjetosDeValor;
using Xunit;

namespace VemDoBem.Testes.Unit.Entidades
{
    public class InstituicaoTeste
    {
        [Fact]
        public void Instituicao_deve_construir_uma_instituicao_valida()
        {
            //Arrange
            var nome = "acapra";
            var descricao = "ong que cuida de animais abandonados";
            var idUsuario = 10;
            var instituicaoDto = new InstituicaoDto
            {
                Nome = nome,
                Descricao = descricao,
                Endereco = EnderecoPadrao,
                IdUsuarioResponsavel = idUsuario
            };

            //Act
            var instituicao = new Instituicao(instituicaoDto);

            //Assert
            instituicao.Nome.Should().Be(nome);
            instituicao.Descricao.Should().Be(descricao);
            instituicao.IdUsuarioResponsavel.Should().Be(idUsuario);
            instituicao.Endereco.Should().BeEquivalentTo(EnderecoPadrao);
        }

        [Fact]
        public void Instituicao_deve_construir_uma_instituicao_valida_com_lista_de_atividades_desenvolvidas()
        {
            //Arrange
            var nome = "acapra";
            var descricao = "ong que cuida de animais abandonados";
            var idUsuario = 10;
            var atividade01 = "Atendimento";
            var atividade02 = "Organização de fila";

            var atividadesDesenvolvidas = new List<TipoTrabalho>
            { 
                new TipoTrabalho(atividade01),
                new TipoTrabalho(atividade02)
            };
            var instituicaoDto = new InstituicaoDto
            {
                Nome = nome,
                Descricao = descricao,
                Endereco = EnderecoPadrao,
                IdUsuarioResponsavel = idUsuario,
                AtividadesDesenvolvidas = atividadesDesenvolvidas
            };

            //Act
            var instituicao = new Instituicao(instituicaoDto);

            //Assert
            instituicao.Nome.Should().Be(nome);
            instituicao.Descricao.Should().Be(descricao);
            instituicao.IdUsuarioResponsavel.Should().Be(idUsuario);
            instituicao.Endereco.Should().BeEquivalentTo(EnderecoPadrao);
            instituicao.AtividadesDesenvolvidas.Should().HaveCount(2);
            instituicao.AtividadesDesenvolvidas.Any(d => d.Descricao == atividade01);
            instituicao.AtividadesDesenvolvidas.Any(d => d.Descricao == atividade02);
        }

        static Endereco EnderecoPadrao => new Endereco(new EnderecoDto
        {
            Cep = "88333000",
            Rua = "distante",
            Uf = "SP",
            Municipio = "Super distante"
        });
    }
}
