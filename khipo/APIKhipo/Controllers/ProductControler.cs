using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIKhipo.Models;
using APIKhipo.ViewModels;
using APIKhipo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIKhipo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsRepository ProductsRepository;
        public ProductsController(IProductsRepository _ProductsRepository)
        {
            ProductsRepository = _ProductsRepository;
        }        
        /// <summary>
        /// Listar todos.
        /// </summary>
        /// <returns>retorna todos os produtos da lista</returns>
        /// <response code="200">retorna todos os produtos da lista</response>
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var Productss = await ProductsRepository.GetProducts();
                if (Productss == null)
                {
                    return NotFound();
                }

                return Ok(Productss);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Listar Unico.
        /// </summary>
        /// <returns>retorna um produto na lista</returns>
        /// <response code="200">retorna um produto da lista através do ID</response>
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(long? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var Products = await ProductsRepository.GetProduct(Id);

                if (Products == null)
                {
                    return NotFound();
                }

                return Ok(Products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Adicionar.
        /// </summary>
        /// <returns>Adiciona um produto na lista</returns>
        /// <response code="200">Adiciona um produto na lista</response>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]Products model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ProductsId = await ProductsRepository.AddProduct(model);
                    if (ProductsId > 0)
                    {
                        return Ok(ProductsId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
        /// <summary>
        /// Deletar.
        /// </summary>
        /// <returns>Remove um produto da lista através do ID</returns>
        /// <response code="200">Remove um produto da lista através do ID</response>
        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(long? Id)
        {
            long result = 0;

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await ProductsRepository.DeleteProduct(Id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Products model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ProductsRepository.UpdateProduct(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}