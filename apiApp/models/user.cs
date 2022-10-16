namespace apiApp.models;

public class User
{
    public User(string username, string password, string gender, string role){
        if (role == "worker") isGuest = false;
        else isGuest = true;

        this.userName = username;
        //should use some encryption but this step was skipped in order to save some time.
        this.password = password;
        this.gender = gender;
    }
    public int ID { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public string gender { get; set; }
    public bool isGuest { get; set; }
    

}