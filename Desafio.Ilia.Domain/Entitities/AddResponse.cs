namespace Desafio.Ilia.Domain.Entitities
{
    public class AddResponse<T>
    {
        public AddResponse(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
