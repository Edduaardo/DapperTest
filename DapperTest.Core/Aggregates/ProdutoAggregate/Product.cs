using System.ComponentModel.DataAnnotations;

namespace DapperTest.Core.Aggregates.ProdutoAggregate
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required]
        public decimal Preco { get; set; }
    }
}
