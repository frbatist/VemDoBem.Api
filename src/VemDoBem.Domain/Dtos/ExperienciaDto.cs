using VemDoBem.Domain.Entidades;

namespace VemDoBem.Domain.Dtos
{
    public class ExperienciaDto : DtoBase
    {
        public string Descricao { get; set; }
        public TipoTrabalho TipoTrabalho { get; set; }
    }
}
