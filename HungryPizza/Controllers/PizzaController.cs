using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HungryPizza.Models;
using HungryPizzaDB;
using HungryPizzaServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Controllers
{
    /// <summary>
    /// Responsável por conter os métodos referentes as Pizzas que serão expostos na Api.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IPizzaServices _pizzaService;
        /// <summary>
        /// Cria uma instância da classe <see cref="PizzaController"/>.
        /// </summary>
        /// <param name="pizzaServices"></param>
        public PizzaController(IPizzaServices pizzaServices)
        {
            _pizzaService = pizzaServices;
        }


        // GET: api/GetAll
        /// <summary>  
        /// Lista todas as Pizzas
        /// </summary>  
        /// <response code="200">Sucesso com retorno das Pizzas</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Pizzas</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pizzaService.GetPizzas();

            if(!result.Any())
                return NotFound();

            return Ok(result);
        }

        // GET: api/GetById/1
        /// <summary>  
        /// Busca Pizza por Código
        /// </summary>  
        /// <param name="id">Código da Pizza</param>
        /// <response code="200">Sucesso com retorno da Pizza</response>
        /// <response code="400">Requisição não foi encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns>Pizza</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pizzaService.PizzaById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
    }
}