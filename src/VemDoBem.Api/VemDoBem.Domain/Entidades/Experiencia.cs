using VemDoBem.Domain.Dtos;

namespace VemDoBem.Domain.Entidades
{
    public class Experiencia : Entidade<short>
    {
        public string Descricao { get; protected set; }
        public TipoTrabalho TipoTrabalho { get; protected set; }

        public Experiencia(ExperienciaDto dto)
        {
            dto.ValidarELancarExcessao();
            Descricao = dto.Descricao;
            TipoTrabalho = dto.TipoTrabalho;
        }
    }
}
