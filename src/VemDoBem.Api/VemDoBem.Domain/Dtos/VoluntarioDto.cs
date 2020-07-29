using System.Collections.Generic;
using VemDoBem.Domain.Entidades;

namespace VemDoBem.Domain.Dtos
{
    public class VoluntarioDto : DtoBase
    {
        public long IdUsuario { get; set; }
        public int IdInstituicao { get; set; }
        public List<TipoTrabalho> PreferenciasDeTrabalho { get; set; }        
    }
}
