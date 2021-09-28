using rede_social_api_at.DbContextConfig;
using rede_social_api_at.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rede_social_api_at.Repository.PostRepository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApiDbContext _dbContext;

        public PostRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Post> GetAll()
        {
            var posts = _dbContext.Posts.ToList();
            return posts;
        }

        public void CriarPost(Post post)
        {
            //var post = new Post();
            //post.Id = create.;
            //post.Texto = create.Author;
            //post.Texto = create.Subject;

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public Post GetById(int id)
        {
            Post post = _dbContext.Posts.Find(id);
            return post;
        }

        public void Delete(Post post)
        {
            //var post = _dbContext.Posts.Find(id);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Post novo)
        {
            var post = _dbContext.Posts.Find(id);
            post.Tiulo = novo.Tiulo;
            post.Foto = novo.Foto;
            post.Texto = novo.Texto;
            post.Autor = novo.Autor;
            _dbContext.SaveChanges();
        }
    }
}
