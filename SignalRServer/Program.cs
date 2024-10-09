using SignalRServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:7212")
        .AllowAnyHeader()
        .WithMethods("GET", "POST")
        .AllowCredentials();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
});
app.Run();