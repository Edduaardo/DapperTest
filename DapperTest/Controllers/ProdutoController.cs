using DapperTest.Core.Aggregates.ProdutoAggregate;
using DapperTest.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository<Product> _produtoRepository;

        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(
            ILogger<ProdutoController> logger,
            IProdutoRepository<Product> produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _produtoRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetAsync(id);

                if (produto is null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product produto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                await _produtoRepository.AddAsync(produto);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _produtoRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> FindId(int id)
        //{
        //    try
        //    {
        //        var product = await _produtoRepository.FindByIdAsync(id);

        //        if (product is null)
        //            return NotFound();

        //        return Ok(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}