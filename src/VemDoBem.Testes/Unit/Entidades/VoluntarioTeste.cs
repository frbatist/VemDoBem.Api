using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VemDoBem.Domain.Entidades;
using VemDoBem.Domain.Entidades.Builders;
using Xunit;

namespace VemDoBem.Testes.Unit.Entidades
{
    public class VoluntarioTeste
    {
        [Fact]
        public void Voluntario_deve_construir_um_voluntario_valido()
        {
            //Arrange            
            var preferencias = new List<TipoTrabalho>
            {
                new TipoTrabalhoBuilder().Construir()
            };
            var voluntarioDto = new VoluntatioBuilder()
                .ComUsuario(10)
                .ComInstituicao(1)
                .ComPreferenciasDeTrabalho(preferencias)
                .ConstruirDto();

            //Act
            var voluntario = new Voluntario(voluntarioDto);

            //Assert
            voluntario.IdUsuario.Should().Be(10);
            voluntario.IdInstituicao.Should().Be(1);
            voluntario.PreferenciasDeTrabalho.Should().BeEquivalentTo(preferencias);
        }
    }
}
