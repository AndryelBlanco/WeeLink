

namespace WeeLink.Utils
{
    public class Helpers
    {

        public string randomLinkGenerator()
        {
            string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 6;
            Random random = new Random();
            string result = new string(
                Enumerable.Repeat(characters, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

    }
}
