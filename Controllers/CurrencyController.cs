using ExpensesTrackingSystem.API.Entities;
using ExpensesTrackingSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Controllers
{
    [ApiController]
    [Route("api/currency")]
    public class CurrencyController : ControllerBase
    {

        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository ?? 
                throw new ArgumentNullException(nameof(currencyRepository));
        }

        [HttpGet()]
        public IActionResult GetCurrencies()
        {
            var currencyList  = _currencyRepository.GetCurrencies();
            return Ok(currencyList);
           
        }
        [HttpGet("{Id}")]
        public IActionResult GetCurrency(int Id)
        {
            var GetSingleCurrency = _currencyRepository.GetCurrency(Id);
            
            if (GetSingleCurrency==null)
            { 
                return NotFound();
            }
            var singleCurrency = _currencyRepository.GetCurrency(Id);
            return Ok(singleCurrency);
        }
    }
}
