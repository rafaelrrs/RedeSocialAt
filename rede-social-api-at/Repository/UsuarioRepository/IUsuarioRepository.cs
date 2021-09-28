using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rede_social_api_at.Models;

namespace rede_social_api_at.Repository.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        void SalvarUsuario(Usuario usuario);
        Task<Usuario> GetById(int usuarioId);
    }
}