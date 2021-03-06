using AutoMapper;
using GEL.Services.PostAPI.Dtos;
using GEL.Services.PostAPI.Models;

namespace GEL.Services.PostAPI.Repos
{
    public class InMemPostRepo : IPostRepo
    {
        private readonly List<Post> posts;
        private readonly IMapper mapper;

        public InMemPostRepo(IMapper mapper)
        {
            this.mapper = mapper;
            posts = SeedingPostList();
        }

        private static List<Post> SeedingPostList()
        {
            return new()
            {
                new Post
                {
                    PostId = 1,
                    Title = "Post 1",
                    Description = "Desc 1",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    Slug = "Slug 1",
                    Thumbnail = "",
                    Content = "Content 1",
                    CreatedAt = DateTime.Now,
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Views = 1,
                    Comments = 1
                },
                new Post
                {
                    PostId = 2,
                    Title = "Post 2",
                    Description = "Desc 2",
                    CategoryId = 2,
                    SubCategoryId = 2,
                    Slug = "Slug 2",
                    Thumbnail = "",
                    Content = "Content 2",
                    CreatedAt = DateTime.Now,
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Views = 2,
                    Comments = 2
                },
                new Post
                {
                    PostId = 3,
                    Title = "Post 3",
                    Description = "Desc 3",
                    CategoryId = 3,
                    SubCategoryId = 3,
                    Slug = "Slug 3",
                    Thumbnail = "",
                    Content = "Content 3",
                    CreatedAt = DateTime.Now,
                    PublishedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Views = 3,
                    Comments = 3
                }
            };
        }

        public async Task<bool> CreatePost(PostDto postDto)
        {
            var post = mapper.Map<Post>(postDto);
            posts.Add(post);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            var postsDto = mapper.Map<IEnumerable<PostDto>>(posts);
            return await Task.FromResult(postsDto);
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var postDto = mapper.Map<PostDto>(posts.SingleOrDefault(p => p.PostId == id));
            return await Task.FromResult(postDto);
        }

        public async Task<bool> UpdatePost(PostDto postDto)
        {
            posts[posts.FindIndex(p => p.PostId == postDto.PostId)] = mapper.Map<Post>(postDto);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = posts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return await Task.FromResult(false);
            }
            posts.Remove(post);
            return await Task.FromResult(true);
        }
    }}
