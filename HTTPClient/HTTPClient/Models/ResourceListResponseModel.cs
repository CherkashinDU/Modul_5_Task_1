using Newtonsoft.Json;

namespace HTTPClient.Models
{
    public class ResourceListResponseModel
    {
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        public ResourceModel[] Data { get; set; }
        public SupportModel Support { get; set; }
    }
}
