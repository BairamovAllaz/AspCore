namespace ApiAspNet.Sever;

public class User
{
    public string Email { get; set; }
    public string Password  { get; set; }
    public string Repeat { get; set; }

    public User(User user)
    {
        this.Email = user.Email;
        this.Password = user.Password;
        this.Repeat = user.Repeat;
    }
    public User(){}
}