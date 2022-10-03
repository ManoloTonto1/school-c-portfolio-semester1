using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace admin
{

    public abstract class Gebruiker
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public Gebruiker(string email) => Email = email;

    }

}