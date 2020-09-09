using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VemDoBem.Domain;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.Entidades;
using VemDoBem.Domain.Entidades.Builders;
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
            var nome = "acapra dos animais";
            var descricao = "ong que cuida de animais abandonados";
            var idUsuario = 10;
            var endereco = new EnderecoBuilder().Construir();

            var instituicaoDto = new InstituicaoBuilder()
                .ComNome(nome)
                .ComDescricao(descricao)
                .ComIdUsuarioResponsavel(idUsuario)
                .ComEndereco(endereco)
                .ConstruirDto();
            //Act
            var instituicao = new Instituicao(instituicaoDto);

            //Assert
            instituicao.Nome.Should().Be(nome);
            instituicao.Descricao.Should().Be(descricao);
            instituicao.IdUsuarioResponsavel.Should().Be(idUsuario);
            instituicao.Endereco.Should().BeEquivalentTo(endereco);
        }

        [Fact]
        public void Instituicao_deve_construir_uma_instituicao_valida_com_lista_de_atividades_desenvolvidas()
        {
            //Arrange
            var nome = "acapra dos animais";
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

        [Theory]
        [ClassData(typeof(InstituicaoDtoDados))]
        public void Instituicao_deve_lancar_excessao_caso_não_seja_informado_algum_dos_campos_obrigatorios(InstituicaoDto instituicaoDto, string mensagem)
        {
            //Act
            Action act = () => new Instituicao(instituicaoDto);

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

        public class InstituicaoDtoDados : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var nomeValido = "Nome valido para instituição legal.";
                var nomeTamanhoInvalido = new string('a', 121);
                var descricaoValida = "Descricao Muito Legal";
                var descricaoTamanhoInvalido = new string('a', 251);

                yield return new object[] { new InstituicaoDto { Descricao = descricaoValida, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.NomeInstituicaoVazio };
                yield return new object[] { new InstituicaoDto { Nome = "", Descricao = descricaoValida, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.NomeInstituicaoVazio };
                yield return new object[] { new InstituicaoDto { Nome = "eita", Descricao = descricaoValida, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.NomeInstituicaoMenorQuePermitido };
                yield return new object[] { new InstituicaoDto { Nome = nomeTamanhoInvalido, Descricao = descricaoValida, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.NomeInstituicaoMaiorQuePermitido };

                yield return new object[] { new InstituicaoDto { Nome = nomeValido, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.DescricaoInstituicaoVazio };
                yield return new object[] { new InstituicaoDto { Nome = nomeValido, Descricao = "", Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.DescricaoInstituicaoVazio };
                yield return new object[] { new InstituicaoDto { Nome = nomeValido, Descricao = "eita", Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.DescricaoInstituicaoMenorQuePermitido };
                yield return new object[] { new InstituicaoDto { Nome = nomeValido, Descricao = descricaoTamanhoInvalido, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 1 }, Resources.DescricaoInstituicaoMaiorQuePermitido };

                yield return new object[] { new InstituicaoDto { Nome = nomeValido, Descricao = descricaoValida, IdUsuarioResponsavel = 1 }, Resources.EnderecoVazio };
                yield return new object[] { new InstituicaoDto { Nome = nomeValido, Descricao = descricaoValida, Endereco = EnderecoPadrao, IdUsuarioResponsavel = 0 }, Resources.IdUsuarioResponsavelVazio };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
