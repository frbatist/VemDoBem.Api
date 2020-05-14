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

        const string MensagemErro = "Usuário inválido: " +
            "Mome: {0}, " +
            "Email: {1}, " +
            "Senha: {2}, " +
            "Endereco: {3}.";

        public Usuario(UsuarioDto usuarioDto)
        {
            if (UsuarioInvalido(usuarioDto))
                throw new InvalidOperationException(ObterMensagemErro(usuarioDto));
            Nome = usuarioDto.Nome;
            Email = usuarioDto.Email;
            PasswordHash = usuarioDto.Senha;
            Endereco = usuarioDto.Endereco;
            Foto = usuarioDto.Foto;
        }

        private static string ObterMensagemErro(UsuarioDto usuarioDto)
        {
            return string.Format(MensagemErro, usuarioDto.Nome ?? "*vazio*", usuarioDto.Email ?? "*vazio*", usuarioDto.Senha ?? "*vazio*", usuarioDto.Endereco?.Cep ?? "*vazio*");
        }

        private bool UsuarioInvalido(UsuarioDto usuarioDto)
        {
            return string.IsNullOrEmpty(usuarioDto.Nome) || string.IsNullOrEmpty(usuarioDto.Email) || string.IsNullOrEmpty(usuarioDto.Senha) || usuarioDto.Endereco == null;
        }
    }
}
