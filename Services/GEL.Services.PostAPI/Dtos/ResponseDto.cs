namespace GEL.Services.PostAPI.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public string DissplayMessage { get; set; } = "";
        public List<string>? ErrorMessages { get; set; }
    }
}