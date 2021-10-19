using GEL.WASM.Dtos;

namespace GEL.WASM.Services.IServices
{
    public interface IPostService : IBaseService
    {
        Task<T> CreatePostAsync<T>(PostDto postDto);
        Task<T> GetAllPostsAsync<T>();
        Task<T> GetPostByIdAsync<T>(int id);
        Task<T> UpdatePostAsync<T>(PostDto postDto);
        Task<T> DeletePostAsync<T>(int id);
    }
}
