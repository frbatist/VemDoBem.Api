using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public byte[] Foto { get; set; }        
        public IReadOnlyCollection<Experiencia> Experiencias => _experiencias.AsReadOnly();
        public IReadOnlyCollection<TipoTrabalho> PreferenciasDeTrabalho => _preferenciasDeTrabalho.AsReadOnly();

        private List<Experiencia> _experiencias = new List<Experiencia>();
        private List<TipoTrabalho> _preferenciasDeTrabalho = new List<TipoTrabalho>();
    }
}
