namespace ApiAspNet.Sever;

public static class Controllerr
{
    public static async Task Show(HttpContext context)
    {
        var Response = context.Response;
        var Request = context.Request;
        Response.ContentType = "text/html; charset=utf-8";
        await Response.SendFileAsync("Html/index.html");

    }

    public static async Task E404(HttpContext context)
    {
        var Response = context.Response;
        var Request = context.Request;
        Response.ContentType = "text/html; charset=utf-8";
        await Response.SendFileAsync("Html/404.html");
    }

    public static async Task Register(HttpContext context)
    {
       var Response = context.Response;
        Response.ContentType = "text/html; charset=utf-8";
        await Response.SendFileAsync("html/Register.html");
    }

    public static User registerUser(HttpContext context)
    {
        var email = context.Request.Form["email"];
        var password = context.Request.Form["password"];
        var repeat = context.Request.Form["repeat"];
        Console.WriteLine($"Email {email} password {password} repeat {repeat}");
        context.Response.Redirect("/");
        return new User() { Email = email, Password = password, Repeat = repeat };
    }

    public static bool LoginUser(HttpContext context,User user)
    {
        var email = context.Request.Form["email"];
        var password = context.Request.Form["password"];
        if (user.Email != email || user.Password != password)
        {
            return false;
        }
        return true;
    }
}