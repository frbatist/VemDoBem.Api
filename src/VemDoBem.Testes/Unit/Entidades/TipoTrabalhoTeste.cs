using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VemDoBem.Domain.Entidades;
using Xunit;

namespace VemDoBem.Testes.Unit.Entidades
{
    public class TipoTrabalhoTeste
    {
        [Fact]
        public void TipoTrabalho_deve_construir_um_tipoTrabalho_valido()
        {
            //Arrange
            var descricao = "Atendimento";

            //Act
            var tipoTrabalho = new TipoTrabalho(descricao);

            //Assert
            tipoTrabalho.Descricao.Should().Be(descricao);
            tipoTrabalho.Ativo.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TipoTrabalho_deve_lancar_excessao_caso_não_seja_informada_a_descricao_do_tipo_de_trabalho(string descricao)
        {
            //Arrange
            var mensagemErro = "Tipo de trabalho inválido. É necessário informar a descrição!";

            //Act
            Action act = () => new TipoTrabalho(descricao);

            //Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage(mensagemErro);
        }
    }
}
