using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VemDoBem.Domain;
using VemDoBem.Domain.Dtos;
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

        [Theory]
        [ClassData(typeof(VoluntarioDtoDados))]
        public void Usuario_deve_lancar_excessao_caso_não_seja_informado_algum_dos_campos_obrigatorios(VoluntarioDto voluntarioDto, string mensagem)
        {
            //Act
            Action act = () => new Voluntario(voluntarioDto);

            //Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage(mensagem);

        }

        public class VoluntarioDtoDados : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new VoluntarioDto { IdUsuario = 0, IdInstituicao = 10 }, Resources.IdUsuarioVazio};
                yield return new object[] { new VoluntarioDto { IdUsuario = 10, IdInstituicao = 0 }, Resources.IdInstituicaoVazio};
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
