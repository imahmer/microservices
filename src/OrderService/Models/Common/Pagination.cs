namespace OrderService.Models.Common
{
    public class Pagination<T>
    {
        public string SearchKeyword { get; set; }
        public int StartIndex { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public T TotalRecords { get; set; }
    }
}
