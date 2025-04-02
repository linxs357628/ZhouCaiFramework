namespace ZhouCaiFramework.Common
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public int PageSize { get; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)System.Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = System.Linq.Enumerable.Count(source);
            var items = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Skip(source, (pageIndex - 1) * pageSize)
                .Take(pageSize));
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}