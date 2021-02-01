using System;
using JWT.Algorithms;
using JWT.Builder;

namespace WeavySyncfusionChat.Core.Services
{
    public interface ITokenService
    {
        string GenerateToken();
    }


    public class TokenService : ITokenService
    {
        public string GenerateToken()
        {

            // generate a token for Weavy. Here we are simulating a user. In a real world appplication, this should of course be based on the signed in user.
            // check out the Weavy Docs (https://docs.weavy.com/client/authentication) how to create a jwt token and what different claims you can set.
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                .WithSecret(Constants.ClientSecret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim("iss", Constants.ClientId)
                .AddClaim("sub", "1")
                .AddClaim("email", "johndoe@test.com")
                .AddClaim("name", "John Doe")
                .Encode();
        }
    }
}
