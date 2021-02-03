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

            // A ready to use, long lived demo (!) token with a pre-defined user. This is only for demo purposes! 
            // This token only works if Constants.RootUrl is set to https://showcase.weavycloud.com/. If you are using a local/remote Weavy of your own, 
            // Please take a look at https://docs.weavy.com/client/authentication on how to setup a Client and generate tokens


            // The available pre-defined test tokens you can use are:

            //Lilly Diaz
            //return eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJsaWxseSIsIm5hbWUiOiJMaWxseSBEaWF6IiwiZXhwIjoyNTE2MjM5MDIyLCJpc3MiOiJzdGF0aWMtZm9yLWRlbW8iLCJjbGllbnRfaWQiOiJXZWF2eURlbW8iLCJkaXIiOiJjaGF0LWRlbW8tZGlyIiwiZW1haWwiOiJsaWxseS5kaWF6QGV4YW1wbGUuY29tIiwidXNlcm5hbWUiOiJsaWxseSJ9.rQvgplTyCAfJYYYPKxVgPX0JTswls9GZppUwYMxRMY0

            //Samara Kaur
            //return eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzYW1hcmEiLCJuYW1lIjoiU2FtYXJhIEthdXIiLCJleHAiOjI1MTYyMzkwMjIsImlzcyI6InN0YXRpYy1mb3ItZGVtbyIsImNsaWVudF9pZCI6IldlYXZ5RGVtbyIsImRpciI6ImNoYXQtZGVtby1kaXIiLCJlbWFpbCI6InNhbWFyYS5rYXVyQGV4YW1wbGUuY29tIiwidXNlcm5hbWUiOiJzYW1hcmEifQ.UKLmVTsyN779VY9JLTLvpVDLc32Coem_0evAkzG47kM

            //Adam Mercer
            //return JhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZGFtIiwibmFtZSI6IkFkYW0gTWVyY2VyIiwiZXhwIjoyNTE2MjM5MDIyLCJpc3MiOiJzdGF0aWMtZm9yLWRlbW8iLCJjbGllbnRfaWQiOiJXZWF2eURlbW8iLCJkaXIiOiJjaGF0LWRlbW8tZGlyIiwiZW1haWwiOiJhZGFtLm1lcmNlckBleGFtcGxlLmNvbSIsInVzZXJuYW1lIjoiYWRhbSJ9.c4P - jeQko3F_ - N4Ou0JQQREePQ602tNDhO1wYKBhjX8

            //Oliver Winter            
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJvbGl2ZXIiLCJuYW1lIjoiT2xpdmVyIFdpbnRlciIsImV4cCI6MjUxNjIzOTAyMiwiaXNzIjoic3RhdGljLWZvci1kZW1vIiwiY2xpZW50X2lkIjoiV2VhdnlEZW1vIiwiZGlyIjoiY2hhdC1kZW1vLWRpciIsImVtYWlsIjoib2xpdmVyLndpbnRlckBleGFtcGxlLmNvbSIsInVzZXJuYW1lIjoib2xpdmVyIn0.VuF_YzdhzSr5-tordh0QZbLmkrkL6GYkWfMtUqdQ9FM";


            // Ucomment the below code if you are running this test app against your own local Weavy installation. 
            // Generates a token for Weavy. Here we are simulating a user. In a real world appplication, this should of course be based on the signed in user.
            // Check out the Weavy Docs (https://docs.weavy.com/client/authentication) how to create a jwt token and what different claims you can set.

            //return new JwtBuilder()
            //    .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
            //    .WithSecret(Constants.ClientSecret)
            //    .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
            //    .AddClaim("iss", Constants.ClientId)
            //    .AddClaim("sub", "1")
            //    .AddClaim("email", "johndoe@test.com")
            //    .AddClaim("name", "John Doe")
            //    .Encode();
        }
    }
}
