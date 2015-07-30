using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#review_uri
    /// </summary>
    public class RbitEditorialReview : WepayRbitBase
    {
        [JsonProperty("review_uri")]
        public string ReviewUri { get; set; }

    }
}
