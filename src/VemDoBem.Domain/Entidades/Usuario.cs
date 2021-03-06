﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.ObjetosDeValor;

namespace VemDoBem.Domain.Entidades
{
    public class Usuario : IdentityUser<long>
    {
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public byte[] Foto { get; private set; }
        private List<Experiencia> _experiencias = new List<Experiencia>();
        public IReadOnlyCollection<Experiencia> Experiencias => _experiencias.AsReadOnly();
        

        protected Usuario() {}
        public Usuario(UsuarioDto usuarioDto)
        {
            usuarioDto.ValidarELancarExcessao();

            Nome = usuarioDto.Nome;
            Email = usuarioDto.Email;
            UserName = usuarioDto.Email;
            PasswordHash = usuarioDto.Senha;
            Endereco = usuarioDto.Endereco;
            Foto = usuarioDto.Foto;
            _experiencias = usuarioDto.Experiencias;
        }
    }
}
