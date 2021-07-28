using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Models;
using DataBase.Services;

namespace DataBase.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    public class MainController : Controller
    {
        protected IMainControllerService service;
        public MainController(IMainControllerService logic)
        {
            service = logic;
        }

        [HttpGet("startwithc/")]
        public IActionResult FirstQuery()
        {
            try
            {
                return Ok(service.StartingWithC());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("cheapestproduct/")]
        public IActionResult SecondQuery()
        {
            try
            {
                return Ok(service.SelectCheapestProduct());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("fromusa/")]
        public IActionResult ThirdQuery()
        {
            try 
            {
                return Ok(service.CostAllFromUSA());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("condiments/")]
        public IActionResult fourthQuery()
        {
            try
            {
                return Ok(service.CondimentsSuppliers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("add/")]
        public IActionResult Add([FromBody] AddDTO data)
        {
            try
            {
                service.Adder(data.SupplierName,
                        data.SupplierCity,
                        data.SupplierCountry,
                        data.ProductName,
                        data.ProductPrice,
                        data.CategoryName,
                        data.CategoryDescription);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
