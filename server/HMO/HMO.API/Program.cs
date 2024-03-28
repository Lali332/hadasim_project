using HMO.API.Mapping;
using HMO.Core.Mapping;
using HMO.Core.Repositories;
using HMO.Core.Services;
using HMO.Data;
using HMO.Data.Repositories;
using HMO.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<ICoronaDetailsRep, CoronaDetailsRep>();
builder.Services.AddScoped<IPersonalDetailsRep, PersonalDetailsRep>();
builder.Services.AddScoped<IPersonalDetailsService, PersonalDetailsService>();
builder.Services.AddScoped<ICoronaDetailsService, CoronaDetailsService>();
builder.Services.AddAutoMapper(typeof(ApiMappingProfile),typeof(CoreMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(p => p
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
