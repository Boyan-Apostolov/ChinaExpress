namespace ChinaExpress.DTOs
{
    public class CachedStatisticsDto
    {
        public List<KeyValuePair<string, int>> MostPopularItems { get; set; }
        public List<KeyValuePair<string, int>> SalesPerCategory { get; set; }
        public List<KeyValuePair<string, decimal>> LastTenOrderRecords { get; set; }
    }

}
