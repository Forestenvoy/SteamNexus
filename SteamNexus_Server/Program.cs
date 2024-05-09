using Microsoft.EntityFrameworkCore;
using SteamNexus_Server.Data;
using SteamNexus_Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �[�J CORS ����
string MyAllowSpecificOrigins = "AllowAny";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy => policy.WithOrigins("*").WithMethods("*").WithHeaders("*")
    );
});

// DataBase Connection String
var SteamNexusConnectionString = builder.Configuration.GetConnectionString("SteamNexus");
// Add SteamNexusDbContext
builder.Services.AddDbContext<SteamNexusDbContext>(options => options.UseSqlServer(SteamNexusConnectionString));

// Add CoolPCWebScrabing Service
builder.Services.AddTransient<CoolPCWebScraping>();

var app = builder.Build();

// �ҥ� wwwroot
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// �M�Φ۩w�q CORS �]�w
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();