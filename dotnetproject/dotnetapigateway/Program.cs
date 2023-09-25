var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
/home/coder/project/workspace/dotnetproject/dotnetmicroserviceone
app.MapGet("/", () => "Hello World!");

app.Run();
