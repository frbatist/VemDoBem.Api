using System.Collections.Generic;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades.Builders
{
    public class UsuarioBuilder
    {
        private string _nome = "Francisco Trinaldo";
        private string _email = "massaranduba@bol.com.br";
        private string _senha = "Ahjfs4f54asd=";
        private Endereco _endereco = new EnderecoBuilder().Construir();
        private byte[] _foto = new byte[]
        {
            0x01, 0x01, 0x06, 0x00, 0x00, 0x00, 0x3d, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00
        };
        private List<Experiencia> _experiencias = new List<Experiencia>
        {
            new ExperienciaBuilder().Construir()
        };

        public UsuarioDto ConstruirDto()
        {
            return new UsuarioDto
            {
                Nome = _nome,
                Email = _email,
                Senha = _senha,
                Endereco = _endereco,
                Foto = _foto,
                Experiencias = _experiencias
            };
        }

        public Usuario Construir()
        {
            return new Usuario(ConstruirDto());
        }
    }
}
