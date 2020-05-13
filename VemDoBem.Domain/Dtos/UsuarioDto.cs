using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Dtos
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public byte[] Foto { get; set; }
    }
}
