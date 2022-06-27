using System.Runtime.CompilerServices;
using ApiAspNet.Sever;
using ApiAspNet.Sever.MiddleWare;

User user = null; //user
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.Run(async (context) =>
    {
        var Response = context.Response;
        var path = context.Request.Path;
      
        if (path == "/")
        {
            if (user == null)
            {
                Response.Redirect("/register");
            }
            else
            {
                Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("html/index.html");
            }
        }
        else if (path == "/registerUser")
        {
            User newuser = Controllerr.registerUser(context);
            user = new User(newuser);
        }
        else if(context.Request.Path == "/register")
        {
            await Controllerr.Register(context);
        }
        else if (path == "/LoginUser")
        {
            bool result = Controllerr.LoginUser(context, user);
            if (result)
            {
                Console.WriteLine("Welcome user!");
                context.Response.Redirect("/");
            }
            else
            {
                Console.WriteLine("User cant find!");
                await context.Response.WriteAsync("User cant find!");
            }
        }
        else if (context.Request.Path == "/login")
        {
            Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("html/Login.html");
        }
        else{
            Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("html/404.html");
        }
    });
app.Run();