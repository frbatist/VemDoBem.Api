using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Dtos
{
    public class UsuarioDto : DtoBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Endereco Endereco { get; set; }
        public byte[] Foto { get; set; }        
    }
}
