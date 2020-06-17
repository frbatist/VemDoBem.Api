using System.Collections.Generic;

namespace VemDoBem.Domain.Entidades
{
    public class Voluntario : Entidade<long>
    {
        public Usuario Usuario { get; set; }
        public IReadOnlyCollection<Experiencia> Experiencias => _experiencias.AsReadOnly();
        public IReadOnlyCollection<TipoTrabalho> PreferenciasDeTrabalho => _preferenciasDeTrabalho.AsReadOnly();

        private List<Experiencia> _experiencias = new List<Experiencia>();
        private List<TipoTrabalho> _preferenciasDeTrabalho = new List<TipoTrabalho>();

        protected Voluntario() { }
    }
}
