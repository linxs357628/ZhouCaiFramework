namespace ZhouCaiFramework.Model.Dtos
{
    public class OperationLogStatsDto
    {
        public int TotalCount { get; set; }
        public int ErrorCount { get; set; }
        public IEnumerable<dynamic> ModuleStats { get; set; }
        public IEnumerable<dynamic> ActionStats { get; set; }
    }
}