using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using rede_social_api_at.Repository.PostRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _iPostRepository;

        public PostController(ApiDbContext apiDbContext, IPostRepository iPostRepository)
        {
            _iPostRepository = iPostRepository;
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
                    var post = _iPostRepository.GetAll();
                    return Ok(post);
                }
                var outro = _iPostRepository.GetById(id);
                return Ok(outro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: posts não encontrados");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Post post)
        {
            try
            {
                _iPostRepository.CriarPost(post);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: criação de post inválida");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                var post = _iPostRepository.GetById(id);
                _iPostRepository.Delete(post);
                return Ok();
            }
            catch
            {
                return BadRequest("Request inválido!");
            }
        }

        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Post post)
        {
            try
            {
                if (post.Id == id)
                {
                    _iPostRepository.Update(id, post);
                    return Ok(post);
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
