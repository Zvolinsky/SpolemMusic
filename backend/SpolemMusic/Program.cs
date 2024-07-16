global using SpolemMusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SpolemMusic.Server.Services;
using SpolemMusic.Server.Services.JoinTables;
using SpolemMusic.Server.Services.ProductDataServices;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
// Add services to the container.

builder.Services.AddControllers();

// Configure DBContext with SQL
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

// Configure the services
builder.Services.AddTransient<ArtistsService>();
builder.Services.AddTransient<CountriesService>();
builder.Services.AddTransient<FormatsService>();
builder.Services.AddTransient<GenresService>();
builder.Services.AddTransient<LabelsService>();
builder.Services.AddTransient<ReviewsService>();
builder.Services.AddTransient<TracksService>();
builder.Services.AddTransient<CartStatusesService>();
builder.Services.AddTransient<ClientsService>();
builder.Services.AddTransient<OrdersService>();
builder.Services.AddTransient<ProductsService>();
builder.Services.AddTransient<ArtistsTracksService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options.WithOrigins("http://localhost:5173")
.AllowAnyMethod()
.AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Media")),
    RequestPath = "/Media"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
