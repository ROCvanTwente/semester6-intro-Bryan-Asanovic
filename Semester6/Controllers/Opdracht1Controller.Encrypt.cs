using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Semester6.Controllers
{
    public partial class Opdracht1Controller : Controller
    {
        public IActionResult Encryption()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EncryptText([FromBody] JsonElement data)
        {
            string text = data.GetProperty("text").GetString();
            int key = data.GetProperty("key").GetInt32();

            string encryptedText = EncryptionFunctions.Encrypt(text, key);
            return Content(encryptedText);
        }

        public static class EncryptionFunctions
        {
            private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            public static string Encrypt(string input, int key)
            {
                if (string.IsNullOrEmpty(input)) return input;

                key = key % Alphabet.Length; // Zorgt ervoor dat de key binnen de grenzen blijft
                return new string(input.Select(c =>
                {
                    int index = Alphabet.IndexOf(c);
                    if (index == -1) return c; // Laat niet-versleutelbare tekens ongemoeid
                    return Alphabet[(index + key) % Alphabet.Length];
                }).ToArray());
            }
        }
    }
}
