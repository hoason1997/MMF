using Jwt;
using Newtonsoft.Json;
using System;

namespace MFF.DTO.Helpers
{
    public static class EncryptHelper
    {
        private const string SecretKey = "ThisIsSecretKeyForHash";
        private const JwtHashAlgorithm JwtHashAlgorithm = Jwt.JwtHashAlgorithm.HS256;

        public static string Encrypt<T>(T item)
        {
            return JsonWebToken.Encode(item, SecretKey, JwtHashAlgorithm);
        }

        public static T Decrypt<T>(string entry)
        {
            try
            {
                var dataStr = JsonWebToken.Decode(entry, SecretKey);
                return JsonConvert.DeserializeObject<T>(dataStr);
            }
            catch (SignatureVerificationException)
            {
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
