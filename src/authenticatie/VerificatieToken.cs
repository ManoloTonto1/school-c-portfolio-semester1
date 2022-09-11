using System;
using System.Linq;

namespace authenticatie
{
    public class VerificatieToken
    {
        public string token { get; set; }
        public DateTime verloopDatum { get; set; }

        public VerificatieToken()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var token = new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            this.token = token;
            verloopDatum = DateTime.Now.AddDays(7);

        }
    }
}