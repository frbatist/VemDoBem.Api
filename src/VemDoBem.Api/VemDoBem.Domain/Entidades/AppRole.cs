using Microsoft.AspNetCore.Identity;
using System;

namespace VemDoBem.Domain.Entidades
{
    public class AppRole : IdentityRole<long>
    {
        public AppRole() { }

        public AppRole(string name)
        {
            Name = name;
        }
    }
}
