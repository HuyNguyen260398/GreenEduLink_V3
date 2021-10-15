using GEL.Services.PostAPI.Dtos;

namespace GEL.Services.PostAPI.Repos
{
    public interface IPostRepo
    {
        Task<bool> CreatePost(PostDto postDto);
        Task<IEnumerable<PostDto>> GetPosts();
        Task<PostDto> GetPostById(int id);
        Task<bool> UpdatePost(PostDto postDto);
        Task<bool> DeletePost(int id);
    }
}