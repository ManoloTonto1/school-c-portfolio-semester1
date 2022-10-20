namespace apiApp.models;

public class Attraction
{
    public int? ID { get; set; }
    public string name { get; set; }
    public int? fearLevel { get; set; }
    public DateTime? constructionDate { get; set; } = DateTime.Now;
    public List<User> userLikes { get; set; } = new List<User>();

}