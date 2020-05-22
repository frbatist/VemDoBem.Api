using System.Collections.Generic;
using VemDoBem.Domain.Entidades;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Dtos
{
    public class InstituicaoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public long IdUsuarioResponsavel { get; set; }
        public List<TipoTrabalho> AtividadesDesenvolvidas { get; set; }
    }
}
