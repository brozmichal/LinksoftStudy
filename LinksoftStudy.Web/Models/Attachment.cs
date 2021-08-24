using Newtonsoft.Json;
using System.Collections.Generic;

namespace LinksoftStudy.Web.Models
{
    [JsonObject]
    public class AttachmentsPayload
    {
        [JsonProperty(PropertyName = "attachments")]
        public IEnumerable<Attachment> Attachments { get; set; }
    }

    [JsonObject]
    public class Attachment
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }
    }
}
