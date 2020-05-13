using Microsoft.AspNetCore.Identity;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public byte[] Foto { get; set; }
    }
}
