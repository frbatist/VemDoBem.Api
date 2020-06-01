using System.Collections.Generic;
using VemDoBem.Domain.Dtos;

namespace VemDoBem.Domain.Entidades
{
    public class Voluntario : Entidade<long>
    {
        public Usuario Usuario { get; private set; }
        public long IdUsuario { get; private set; }
        public Instituicao Instituicao { get; private set; }
        public int IdInstituicao { get; private set; }
        private List<TipoTrabalho> _preferenciasDeTrabalho = new List<TipoTrabalho>();
        public IReadOnlyCollection<TipoTrabalho> PreferenciasDeTrabalho => _preferenciasDeTrabalho.AsReadOnly();
        public bool Ativo { get; private set; }

        public Voluntario(VoluntarioDto voluntarioDto)
        {
            voluntarioDto.ValidarELancarExcessao();
            IdUsuario = voluntarioDto.IdUsuario;
            IdInstituicao = voluntarioDto.IdInstituicao;
            _preferenciasDeTrabalho = voluntarioDto.PreferenciasDeTrabalho;
            Ativo = false;
        }
    }
}
