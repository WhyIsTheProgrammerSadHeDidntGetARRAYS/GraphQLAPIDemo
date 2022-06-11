var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureGraphQL();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL("/");

app.Run();
