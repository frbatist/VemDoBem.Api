using Microsoft.AspNetCore.Identity;
using System;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; private set; }        
        public Endereco Endereco { get; private set; }
        public byte[] Foto { get; private set; }

        public Usuario(UsuarioDto usuarioDto)
        {
            usuarioDto.ValidarELancarExcessao();

            Nome = usuarioDto.Nome;
            Email = usuarioDto.Email;
            PasswordHash = usuarioDto.Senha;
            Endereco = usuarioDto.Endereco;
            Foto = usuarioDto.Foto;
        }
    }
}
