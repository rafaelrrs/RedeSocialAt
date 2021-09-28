using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;

namespace rede_social_api_at.Repository.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiDbContext _dbContext;

        public UsuarioRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                return await _dbContext.Usuario.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public void SalvarUsuario(Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            _dbContext.SaveChanges();
        }

        public async Task <Usuario> GetById(int usuarioId)
        {
            try
            {
                var autores = await _dbContext.Usuario.FindAsync(usuarioId);
                return autores;
            }
            catch
            {
                throw;
            }
            var usuarioById = _dbContext.Usuario.Find(usuarioId);
            return usuarioById;
        }
    }
}