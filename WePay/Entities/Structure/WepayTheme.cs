using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayTheme
    {
        [JsonProperty("theme_id")]
        public long ThemeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("primary_color")]
        public string PrimaryColor { get; set; }

        [JsonProperty("secondary_color")]
        public string SecondaryColor { get; set; }

        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; }

        [JsonProperty("button_color")]
        public string ButtonColor { get; set; }
    }
}
