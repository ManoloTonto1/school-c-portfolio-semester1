using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace apiApp.models;

public class User: IdentityUser
{
    public User(): base()
    {
    }
    [Required(ErrorMessage = "Username is required")]
    public string? password { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string? gender { get; init; }

    public List<Attraction> likedAttractions { get; set; } = new List<Attraction>();
    [Required(ErrorMessage = "ROLE is required")]
    public bool? isGuest { get; set; }
}