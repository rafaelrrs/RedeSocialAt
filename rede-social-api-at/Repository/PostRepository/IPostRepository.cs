using rede_social_api_at.Models;
using System.Collections.Generic;

namespace rede_social_api_at.Repository.PostRepository
{
    public interface IPostRepository
    {
        void CriarPost(Post post);
        void Delete(Post post);
        List<Post> GetAll();
        Post GetById(int id);
        void Update(int id, Post novo);
    }
}