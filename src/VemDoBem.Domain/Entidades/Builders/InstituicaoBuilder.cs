using System;
using System.Collections.Generic;
using System.Text;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades.Builders
{
    public class InstituicaoBuilder
    {
        private string _nome = "acapra dos animais";
        private string _descricao = "ong que cuida de animais abandonados";
        private Endereco _endereco = new EnderecoBuilder().Construir();
        private long _idUsuarioResponsavel = 10;
        private List<TipoTrabalho> _atividadesDesenvolvidas = new List<TipoTrabalho> { new TipoTrabalho("TipoTrabalhoLegal") };

        public InstituicaoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public InstituicaoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public InstituicaoBuilder ComIdUsuarioResponsavel(long idUsuarioResponsavel)
        {
            _idUsuarioResponsavel = idUsuarioResponsavel;
            return this;
        }

        public InstituicaoBuilder ComEndereco(Endereco endereco)
        {
            _endereco = endereco;
            return this;
        }

        public InstituicaoDto ConstruirDto()
        {
            return new InstituicaoDto
            {
                Nome = _nome,
                Descricao = _descricao,
                Endereco = _endereco,
                IdUsuarioResponsavel = _idUsuarioResponsavel,
                AtividadesDesenvolvidas = _atividadesDesenvolvidas
            };
        }

        public Instituicao Construir()
        {
            return new Instituicao(ConstruirDto());
        }
    }
}
