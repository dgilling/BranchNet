using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using BranchNet.Extensions;

namespace BranchNet.Models
{
    public class UrlDataParameters
    {
        [JsonProperty(PropertyName = "$og_title")]
        public string OgTitle { get; set; }

        [JsonProperty(PropertyName = "$og_description")]
        public string OgDescription { get; set; }

        [JsonProperty(PropertyName = "$og_image_url")]
        public string OgImageUrl { get; set; }

        [JsonProperty(PropertyName = "$og_video")]
        public string OgVideo { get; set; }

        [JsonProperty(PropertyName = "$og_redirect")]
        public string OgRedirect { get; set; }

        [JsonProperty(PropertyName = "$desktop_url")]
        public string DesktopUrl { get; set; }

        [JsonProperty(PropertyName = "$android_url")]
        public string AndroidUrl { get; set; }

        [JsonProperty(PropertyName = "$ios_url")]
        public string IosUrl { get; set; }

        [JsonProperty(PropertyName = "$ipad_url")]
        public string IPadUrl { get; set; }

        [JsonProperty(PropertyName = "$fire_url")]
        public string FireUrl { get; set; }

        [JsonProperty(PropertyName = "$blackberry_url")]
        public string BlackBerryUrl { get; set; }

        [JsonProperty(PropertyName = "$windows_phone_url")]
        public string WindowsPhoneUrl { get; set; }

        [JsonProperty(PropertyName = "$after_click_url")]
        public string AfterClickUrl { get; set; }

        [JsonProperty(PropertyName = "$deeplink_path")]
        public string DeepLinkPath { get; set; }

        [JsonProperty(PropertyName = "$always_deeplink")]
        public string AlwaysDeeplink { get; set; }
    }
}
