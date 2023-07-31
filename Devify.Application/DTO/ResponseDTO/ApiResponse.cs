namespace Devify.Application.DTO.ResponseDTO
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string ErrCode { get; set; }
    }

}
