using GEL.Services.PostAPI.Dtos;
using GEL.Services.PostAPI.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GEL.Services.PostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo postRepo;
        protected ResponseDto responseDto;

        public PostController(IPostRepo postRepo)
        {
            this.postRepo = postRepo;
            responseDto = new ResponseDto();
        }

        [HttpPost]
        public async Task<object> CreatePost([FromBody] PostDto postDto)
        {
            try
            {
                var isSuccess = await postRepo.CreatePost(postDto);
                responseDto.Result = isSuccess;
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string> { e.Message };
            }
            return responseDto;
        }

        [HttpGet]
        public async Task<object> GetPost()
        {
            try
            {
                IEnumerable<PostDto> posts = await postRepo.GetPosts();
                responseDto.Result = posts;
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string> { e.Message };
            }
            return responseDto;
        }

        [HttpGet("{id}")]
        public async Task<object> GetPostById(int id)
        {
            try
            {
                PostDto post = await postRepo.GetPostById(id);
                responseDto.Result = post;
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string> { e.Message };
            }
            return responseDto;
        }

        [HttpPut]
        public async Task<object> UpdatePost([FromBody] PostDto postDto)
        {
            try
            {
                var isSuccess = await postRepo.UpdatePost(postDto);
                responseDto.Result = isSuccess;
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string> { e.Message };
            }
            return responseDto;
        }

        [HttpDelete("{id}")]
        public async Task<object> DeletePost(int id)
        {
            try
            {
                var isSuccess = await postRepo.DeletePost(id);
                responseDto.Result = isSuccess;
            }
            catch (Exception e)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessages = new List<string> { e.Message };
            }
            return responseDto;
        }
    }
}
