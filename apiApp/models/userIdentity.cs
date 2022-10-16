namespace apiApp.models;

public class UserIdentity
{
    public int? ID { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public bool isGuest { get; set; }
}