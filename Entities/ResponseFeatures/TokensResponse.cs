using Newtonsoft.Json;

namespace Entities.ResponseFeatures
{
    public class TokenResponse
    {
        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }

        public TokenResponse(string token, DateTime expires)
        {
            RefreshToken = token;
            Expires = expires;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this).Replace(",", @"\002C");
        }
    }
}
