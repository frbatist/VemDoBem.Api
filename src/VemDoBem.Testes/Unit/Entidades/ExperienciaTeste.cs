using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.Entidades;
using Xunit;

namespace VemDoBem.Testes.Unit.Entidades
{
    public class ExperienciaTeste
    {
        [Fact]
        public void Experiencia_deve_construir_uma_experiencia_valida()
        {
            //Arrange
            var descricao = "Ajudava idosos a resgatar seus gatos em árvores";
            var descricaoTipoTrabalho = "Ajudar idosos";
            var tipoTrabalho = new TipoTrabalho(descricaoTipoTrabalho);           

            var experienciaDto = new ExperienciaDto
            {
                Descricao = descricao,
                TipoTrabalho = tipoTrabalho
            };

            //Act
            var usuario = new Experiencia(experienciaDto);

            //Assert
            usuario.Descricao.Should().Be(descricao);
            usuario.TipoTrabalho.Should().Be(tipoTrabalho);
        }
    }
}
