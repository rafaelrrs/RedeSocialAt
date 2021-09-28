using rede_social_api_at.Models;
using System.Collections.Generic;

namespace rede_social_api_at.Repository.ComentarioRepository
{
    public interface IComentarioRepository
    {
        void CriarComentario(Comentario comentario);
        void Delete(Comentario comentario);
        List<Comentario> GetAll();
        Comentario GetById(int id);
        void Update(int id, Comentario novo);
    }
}