using Microsoft.AspNetCore.Identity;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public byte[] Foto { get; private set; }
    }
}
