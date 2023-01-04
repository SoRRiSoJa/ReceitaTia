using Microsoft.AspNetCore.Mvc;
using Produtos.Domain.Entities;
using Produtos.Domain.Enums;
using Produtos.Domain.Repositories;

namespace Produtos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMarcaRepository _marcaRepository;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IProdutoRepository _produtoRepository, IMarcaRepository _marcaRepository)
    {
        
        this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
        this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
        _logger = logger;
    }
    

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        //Produto prod = new Produto() { Nome="Sprite lata",Descricao="Refrigerante Sprite Lata 320ml",CEST= "03.011.00",NCM= "2202.10.00", QtdItensContidos=1,CodigoBarras= "7894900010015", Tipo=ETipoProduto.MERCADORIA,MarcaId=new Guid("749b0477-379e-476c-86a7-b4f2e5db7ec3") };
        //var id=await _produtoRepository.Inserir(prod);
        var teste=await _produtoRepository.ObterTodos(null);
        var marcas =await  _marcaRepository.ObterTodos();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        
    }
}
