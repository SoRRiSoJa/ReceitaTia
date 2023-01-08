
using authentication.Infra.Config;
using authentication.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDapperSqlServer(builder.Configuration["ConnectionStrings:Receita"]);
builder.Services.AddDbSession();
builder.Services.AddRepositories();
builder.Services.AddMediatRApi();
builder.Services.AddMappers();
RegisterMapping.Register();
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
