using MicroDDD.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDoBem.Domain.Entidades
{
    public class Entidade<T> : IEntidade<T>
    {
        public T Id { get; set; }
    }
}
