using System.Collections.Generic;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades
{
    public class Instituicao : Entidade<int>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Endereco Endereco { get; private set; }
        public long IdUsuarioResponsavel { get; private set; }
        public Usuario UsuarioResponsavel { get; private set; }        
        public IReadOnlyCollection<TipoTrabalho> AtividadesDesenvolvidas => _atividadesDesenvolvidas.AsReadOnly();    
        
        private List<TipoTrabalho> _atividadesDesenvolvidas = new List<TipoTrabalho>();

        public Instituicao(InstituicaoDto dto)
        {
            Nome = dto.Nome;
            Descricao = dto.Descricao;
            Endereco = dto.Endereco;
            IdUsuarioResponsavel = dto.IdUsuarioResponsavel;
        }
    }
}
