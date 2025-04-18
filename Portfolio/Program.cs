using Microsoft.EntityFrameworkCore;
using Portfolio.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DbPortfolioContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("PortfolioConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("PortfolioConnection"))
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
