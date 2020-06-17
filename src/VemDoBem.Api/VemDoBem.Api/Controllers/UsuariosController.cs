using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VemDoBem.Domain.Dtos;
using VemDoBem.Domain.Entidades;
using VemDoBem.Api.Model;
using Microsoft.EntityFrameworkCore;
using VemDoBem.Infra.Data;

namespace VemDoBem.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly ContextoVemDoBem _context;

        public UsuariosController(UserManager<Usuario> userManager, ContextoVemDoBem context)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto model)
        {
            var newUser = new Usuario(model);

            var result = await _userManager.CreateAsync(newUser, model.Senha);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(new RegisterResult { Successful = false, Errors = errors });

            }

            return Ok(new RegisterResult { Successful = true });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Set<Usuario>().Select(d=>d.Nome).ToListAsync());
        }
    }
}
