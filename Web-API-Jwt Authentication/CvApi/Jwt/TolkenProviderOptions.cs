using Microsoft.IdentityModel.Tokens;
using System;

namespace CvApi.Jwt
{
    public class TolkenProviderOptions
    {
        public string Path { get; set; } = "api/users/login";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);
        public SigningCredentials  SigningCredentials { get; set; }
    }
}
