using HungryPizzaServices.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Controllers
{
    /// <summary>
    /// Responsável por conter os métodos referentes aos Clientes que serão expostos na Api.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerServices _customerService;
        /// <summary>
        /// Cria uma instância da classe <see cref="CustomerController"/>.
        /// </summary>
        /// <param name="customerServices"></param>
        public CustomerController(ICustomerServices customerServices)
        {
            _customerService = customerServices;
        }


        // GET: api/GetAll
        /// <summary>  
        /// Lista todos Clientes
        /// </summary>  
        /// <response code="200">Sucesso com retorno dos Clientes</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Clientes</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetCustomers();

            if(!result.Any())
                return NotFound();

            return Ok(result);
        }


        // GET: api/GetById/2
        /// <summary>  
        /// Busca Cliente por Código
        /// </summary>  
        /// <param name="id">Código do Cliente</param>
        /// <response code="200">Sucesso com retorno do Cliente</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Cliente</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerService.GetCustomerById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
    }
}