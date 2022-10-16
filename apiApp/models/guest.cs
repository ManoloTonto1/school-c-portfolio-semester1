namespace apiApp.models;

public class Guest : User{
    public Guest(string username, string password, string gender, string role) : base(username, password, gender, role)
    {
    }

    public List<Attraction> likedAttractions { get; set; }
}