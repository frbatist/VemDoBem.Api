using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VemDoBem.Domain.Entidades;
using VemDoBem.Infra.Data.Mapeamentos;

namespace VemDoBem.Infra.Data
{
    public class ContextoVemDoBem : IdentityDbContext<Usuario, AppRole, long>
    {
        public ContextoVemDoBem() {}
        public ContextoVemDoBem(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMapeamento());
            base.OnModelCreating(builder);
        }
    }    
}
