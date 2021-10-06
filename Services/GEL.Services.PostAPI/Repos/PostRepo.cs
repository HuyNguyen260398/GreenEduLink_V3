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

        public async Task<PostDto> CreateUpdatePost(PostDto postDto)
        {
            Post post = mapper.Map<Post>(postDto);
            if (post.PostId > 0)
            {
                db.Posts.Update(post);
            }
            else
            {
                db.Posts.Add(post);
            }
            await db.SaveChangesAsync();
            return mapper.Map<PostDto>(post);
        }

        public async Task<bool> DeletePost(int id)
        {
            try
            {
                Post post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == id);
                if (post == null)
                {
                    return false;
                }
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PostDto> GetPostById(int id)
        {
            Post post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            return mapper.Map<PostDto>(post);
        }

        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            List<Post> postList = await db.Posts.ToListAsync();
            return mapper.Map<List<PostDto>>(postList);
        }
    }
}
