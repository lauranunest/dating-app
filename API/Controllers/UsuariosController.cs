using System.Security.Cryptography.X509Certificates;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET /api/usuarios
    public class UsuariosController
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> ObterUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> ObterUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            return usuario;
        }
    }
}