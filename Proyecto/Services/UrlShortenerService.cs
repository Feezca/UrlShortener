using System.Security.Cryptography;

namespace UrlShortener.Proyecto.Services
{
    public class UrlShortenerService
    {
        private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int ShortUrlLength = 6;
        public string UrlShortener()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[ShortUrlLength];
                rng.GetBytes(bytes);

                var charArray = new char[ShortUrlLength];
                for (int i = 0; i < ShortUrlLength; i++)
                {
                    charArray[i] = AllowedCharacters[bytes[i] % AllowedCharacters.Length];
                }

                return new string(charArray);
            }
        }
    }
}
