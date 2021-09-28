using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.UsuarioRepository;

namespace rede_social_api_at.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;


        public UsuarioController(ApiDbContext apiDbContext, IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> Get()
        {
            try
            {
                var alunos = await _iUsuarioRepository.GetAll();
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: usuários não encontrados");
            }
          
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            try
            {
                var usuario = await _iUsuarioRepository.GetById(id);

                if (usuario == null)
                    return NotFound($"Erro: {id} não encontrado");

                return Ok(usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: verificar");
            }
            
        }

        // POST: api/Usuario
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.SalvarUsuario(usuario);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: criação de usuário inválida");
            }

        }
        
      
    }
}
