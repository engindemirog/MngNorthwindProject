using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Business.CustomExceptions;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAllAsync().Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            try
            {
                _productService.Add(product);
                return Ok("Ürün eklendi");
            }
            catch (ProductNameException exception) //known
            {
                return BadRequest(exception.Message);
            }
            catch (CategoryForbiddenException exception) //known
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception) //unknown
            {
                //Loglama kodu yazılır
                return BadRequest("Bir hata oluştu");
            }

        }


    }
}
