namespace InveonBootcamp.LibaryApi.Models.Pagination
{
    public class Pagination<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public IEnumerable<T>? Items { get; set; }
    }
}
