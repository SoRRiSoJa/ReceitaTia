namespace Produtos.Domain.Abstractions
{
    public abstract class Entity
    {
        public bool Excluido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
