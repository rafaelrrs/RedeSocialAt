using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.ComentarioRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _iComentarioRepository;

        public ComentarioController(ApiDbContext apiDbContext, IComentarioRepository iComentarioRepository)
        {
            _iComentarioRepository = iComentarioRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    var coment = _iComentarioRepository.GetAll();
                    return Ok(coment);
                }
                var outro = _iComentarioRepository.GetById(id);
                return Ok(outro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: comentários não encontrados");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Comentario coment)
        {
            try
            {
                _iComentarioRepository.CriarComentario(coment);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: criação de comentário inválida");
            }
            
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                var coment = _iComentarioRepository.GetById(id);
                _iComentarioRepository.Delete(coment);
                return Ok();
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
            
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (comentario.Id == id)
                {
                    _iComentarioRepository.Update(id, comentario);
                    return Ok(comentario);
                }
                else
                {
                    return BadRequest("Dados inconsistentes!");
                }
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
            
        }
    }
}
