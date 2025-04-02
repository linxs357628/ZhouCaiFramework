namespace ZhouCaiFramework.Common
{
    /// <summary>
    /// 分页查询基类
    /// </summary>
    public class PaginationQuery
    {
        private int _pageSize = 10;
        
        /// <summary>
        /// 当前页码(从1开始)
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页记录数(默认10)
        /// </summary>
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = value > 100 ? 100 : value; // 限制最大100条
        }

        /// <summary>
        /// 跳过记录数(自动计算)
        /// </summary>
        public int SkipCount => (PageIndex - 1) * PageSize;
    }
}
