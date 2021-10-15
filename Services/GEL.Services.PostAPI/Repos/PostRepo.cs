using AutoMapper;
using GEL.Services.PostAPI.DbContexts;
using GEL.Services.PostAPI.Dtos;
using GEL.Services.PostAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GEL.Services.PostAPI.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public PostRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<bool> CreatePost(PostDto postDto)
        {
            var post = mapper.Map<Post>(postDto);
            db.Posts.Add(post);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            var postList = await db.Posts.ToListAsync();
            return mapper.Map<IEnumerable<PostDto>>(postList);
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            return mapper.Map<PostDto>(post);
        }

        public async Task<bool> UpdatePost(PostDto postDto)
        {
            var post = mapper.Map<Post>(postDto);
            db.Posts.Update(post);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return false;
            }
            db.Posts.Remove(post);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
