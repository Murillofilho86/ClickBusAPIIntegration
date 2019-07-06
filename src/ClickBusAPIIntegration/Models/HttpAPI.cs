namespace ClickBusAPIIntegration.Models
{
    using System.Collections.Generic;

    public class HttpAPI
    {
        public string Protocol { get; set; } = "https";
        public string Host { get; set; } = "localhost";
        public string EndPoint { get; set; } = "/";
        public string Method { get; set; } = "GET";
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Content { get; set; }
        public HttpPolice Police { get; set; }
    }
}
