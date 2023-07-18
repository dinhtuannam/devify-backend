namespace Devify.Application.DTO
{
    public class DataListDTO<T>
    {
        public T? Items { get; set; }
        public int? TotalRecords { get; set; }
    }
}
