using VemDoBem.Domain.Dtos;

namespace VemDoBem.Domain.Entidades.Builders
{
    public class ExperienciaBuilder
    {
        private string _descricao = "nova experiencia bem legal";
        private TipoTrabalho _tipoTrabalho = new TipoTrabalhoBuilder().Construir();

        public ExperienciaDto ConstruirDto()
        {
            return new ExperienciaDto
            {
                Descricao = _descricao,
                TipoTrabalho = _tipoTrabalho
            };
        }
        public Experiencia Construir()
        {
            return new Experiencia(ConstruirDto());
        }
    }
}
