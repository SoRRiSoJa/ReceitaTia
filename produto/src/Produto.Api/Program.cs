using Produto.Application.Mappers;
using Produtos.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDapperSqlServer(builder.Configuration["ConnectionStrings:Receita"]);
builder.Services.AddUoW();
builder.Services.AddRepositories();
builder.Services.AddMediatRApi();
builder.Services.AddValidators();
builder.Services.AddAutoMapperApi(typeof(MarcaMapper));
builder.Services.AddAutoMapperApi(typeof(ProdutoMapper));
builder.Services.AddAutoMapperApi(typeof(PrePreparoMapper));
builder.Services.AddRedisCache(builder.Configuration["ConnectionStrings:Redis:Host"], builder.Configuration["ConnectionStrings:Redis:Instance"]);

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
