using Microsoft.EntityFrameworkCore;
using SCapi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var appUrls = new List<string>
{
    builder.Configuration.GetSection("ProdURLs").GetSection("Prod").Value
};
if (builder.Environment.IsDevelopment())
{
    appUrls.Add(builder.Configuration.GetSection("DevURLs").GetSection("Dev").Value);
}
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", policy =>
    {
        policy
            .WithOrigins([.. appUrls])
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("ScDbConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<SongwriterCircleDbContext>(options => options.UseNpgsql(connectionString));


var app = builder.Build();

app.UseCors("Cors");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // only use in 'prod' mode
    app.UseHttpsRedirection();   
}

app.UseAuthorization();

app.MapControllers();

app.Run();