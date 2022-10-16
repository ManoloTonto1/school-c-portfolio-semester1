namespace apiApp.models;

public class User: UserIdentity
{
    public string gender { get; set; }

    public List<Attraction>? likedAttractions { get; set; }
    

}