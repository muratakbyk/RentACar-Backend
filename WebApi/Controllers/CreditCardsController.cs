using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {

        ICreditCardService _CreditCardService;
        public CreditCardsController(ICreditCardService creditCardService)
        {
            _CreditCardService = creditCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _CreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _CreditCardService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _CreditCardService.Add(creditCard);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _CreditCardService.Delete(creditCard);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getallbycustomerid")]
        public IActionResult GetAllByCustomerId(int customerId)
        {
            var result = _CreditCardService.GetAllByCustomerId(customerId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }


    }
}
