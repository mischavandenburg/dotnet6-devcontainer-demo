var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseStaticFiles();


var version = Environment.Version;
Console.WriteLine($"The .NET version used by this project is: {version}");
app.MapGet("/", () => {
    var htmlContent = System.IO.File.ReadAllText("index.html");
    htmlContent = htmlContent.Replace("<!-- Version will go here -->", Environment.Version.ToString());
    return Results.Content(htmlContent, "text/html");
});


app.Run();
