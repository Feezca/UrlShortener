using System.Text;
using System.Xml;
using UrlShortener.Proyecto.Data;
using UrlShortener.Proyecto.Entities;
using UrlShortener.Proyecto.Models;


namespace UrlShortener.Proyecto.Services
{
    public class UrlShortenerService
    {
        private readonly UrlShortenerContext _context;

        public UrlShortenerService(UrlShortenerContext context)
        {
            _context = context;
        }


        private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random random = new Random();
        public string UrlShortener(int length)
        {
            var generator = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(AllowedCharacters.Length);
                char randomChar = AllowedCharacters[randomIndex];
                generator.Append(randomChar);
            }
            return generator.ToString();
        }

        public Url? UrlRedirector(string url)
        {
            Url searchedUrl = _context.Urls.SingleOrDefault(u => u.ShortUrl == url);
            searchedUrl.Click_Counter++;
            _context.SaveChanges();
            return searchedUrl;
        }
        public Url? GetUrl(int id)
        {
            return _context.Urls.SingleOrDefault(u => u.Id == id);
        }
        public bool DeleteUrl(int id)
        {
            Url? UrlToDelete = GetUrl(id);
            if (UrlToDelete != null)
            {
                _context.Urls.Remove(GetUrl(id));
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
