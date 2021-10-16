using GEL.WASM.Dtos;
using GEL.WASM.Models;

namespace GEL.WASM.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set;  }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
