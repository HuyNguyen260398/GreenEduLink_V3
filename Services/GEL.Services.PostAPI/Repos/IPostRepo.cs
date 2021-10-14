using GEL.Services.PostAPI.Dtos;

namespace GEL.Services.PostAPI.Repos
{
    public interface IPostRepo
    {
        Task<PostDto> CreatePost(PostDto postDto);
        Task<IEnumerable<PostDto>> GetPosts();
        Task<PostDto> GetPostById(int id);
        Task<PostDto> UpdatePost(PostDto postDto);
        Task<bool> DeletePost(int id);
    }
}