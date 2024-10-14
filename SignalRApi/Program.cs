using SignalRApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.MapHub<MessageHub>("message-hub");
app.Run();
