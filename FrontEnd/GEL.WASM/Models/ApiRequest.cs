using static GEL.WASM.StaticDetails;

namespace GEL.WASM.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = String.Empty;
        public object? Data { get; set; }
        public string AccessToken { get; set; } = String.Empty;
    }
}
