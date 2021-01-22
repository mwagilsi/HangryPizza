using HungryPizza.Application.Models;
using HungryPizzaServices.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Controllers
{
    /// <summary>
    /// Responsável por conter os métodos referentes aos Pedidos que serão expostos na Api.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices _orderServices;
        /// <summary>
        /// Cria uma instância da classe <see cref="OrderController"/>.
        /// </summary>
        /// <param name="orderServices"></param>
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }


        // GET: api/GetByCustomers/2
        /// <summary>  
        /// Busca Histórico de Pedidos
        /// </summary>  
        /// <param name="id">Código do Cliente</param>
        /// <response code="200">Sucesso com retorno do Histórico de Pedido por Cliente</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Pedidos</returns>
        [HttpGet("GetByCustomers/{id}")]
        public async Task<IActionResult> GetByCustomers(int id)
        {
            var result = await _orderServices.GetOrdersByCustomer(id);

            if(!result.Any())
                return NotFound();

            return Ok(result);
        }


        // GET: api/GetById/2
        /// <summary>  
        /// Busca de Pedido
        /// </summary>  
        /// <param name="id">Código do Pedido</param>
        /// <response code="200">Sucesso com retorno da Busca do Pedido</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Pedido</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderServices.GetOrderById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // POST: api/Add
        /// <summary>  
        /// Inclui um Pedido
        /// </summary>  
        /// <response code="200">Sucesso com a inclusão do Pedido</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Pedido</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(OrderViewModel order)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var result = await _orderServices.AddOrder(order);

            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

    }
}