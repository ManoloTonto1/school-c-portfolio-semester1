namespace apiApp.models;

public abstract class Attraction
{
    public int ID { get; set; }
    public string name { get; set; }
    public int fearLevel { get; set; }
    public DateTime constructionDate { get; set; }
    public int likeCount { get; set; }
    public List<Guest> userLikes { get; set; }

}