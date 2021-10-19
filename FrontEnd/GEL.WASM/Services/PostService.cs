using GEL.WASM.Dtos;
using GEL.WASM.Models;
using GEL.WASM.Services.IServices;

namespace GEL.WASM.Services
{
    public class PostService : BaseService, IPostService
    {
        private readonly IHttpClientFactory _httpClient;
        public PostService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreatePostAsync<T>(PostDto postDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = postDto,
                Url = $"{StaticDetails.ProductApiBase}/api/post"
            });
        }

        public async Task<T> GetAllPostsAsync<T>()
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = $"{StaticDetails.ProductApiBase}/api/post"
            });
        }

        public async Task<T> GetPostByIdAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = $"{StaticDetails.ProductApiBase}/api/post/{id}"
            });
        }

        public async Task<T> UpdatePostAsync<T>(PostDto postDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = postDto,
                Url = $"{StaticDetails.ProductApiBase}/api/post"
            });
        }

        public async Task<T> DeletePostAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = $"{StaticDetails.ProductApiBase}/api/post/{id}"
            });
        }
    }
}
