using Microsoft.EntityFrameworkCore;
using NZWalkAPI.CustomActionFilter;
using NZWalkAPI.Data;
using NZWalkAPI.Mappings;
using NZWalkAPI.Reposotiory;

var builder = WebApplication.CreateBuilder(args);


// registet SQLRegionRepository
builder.Services.AddScoped<IRegionRepository,SQLRegionRepository>(); 
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

// regis the automaper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// Add services to the container.
builder.Services.AddDbContext<NZWalksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Add custom action filter
builder.Services.AddControllers(option =>
{
    option.Filters.Add<ValidateModeAtribute>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
