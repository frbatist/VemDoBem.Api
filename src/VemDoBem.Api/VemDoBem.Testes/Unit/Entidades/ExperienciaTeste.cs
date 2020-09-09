using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VemDoBem.Domain;
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

        [Theory]
        [ClassData(typeof(ExperienciaDtoDados))]
        public void Experiencia_deve_lancar_excessao_caso_não_seja_informado_algum_dos_campos_obrigatorios(ExperienciaDto experienciaDto, string mensagem)
        {
            //Act
            Action act = () => new Experiencia(experienciaDto);

            //Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage(mensagem);

        }

        public class ExperienciaDtoDados : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var descricaoValida = new string('a', 250);
                var descricaoInvalida = new string('a', 251);
                var descricaoTipoTrabalho = "Ajudar idosos";
                var tipoTrabalho = new TipoTrabalho(descricaoTipoTrabalho);

                yield return new object[] { new ExperienciaDto { Descricao = null, TipoTrabalho = tipoTrabalho }, Resources.DescricaoExperienciaVazia };
                yield return new object[] { new ExperienciaDto { Descricao = descricaoInvalida, TipoTrabalho = tipoTrabalho }, Resources.DescricaoExperienciaMaiorQuePermitido };
                yield return new object[] { new ExperienciaDto { Descricao = "a", TipoTrabalho = tipoTrabalho }, Resources.DescricaoExperienciaMenorQuePermitido };
                yield return new object[] { new ExperienciaDto { Descricao = descricaoValida, TipoTrabalho = null }, Resources.TipoDeTrabalhoVazio };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
