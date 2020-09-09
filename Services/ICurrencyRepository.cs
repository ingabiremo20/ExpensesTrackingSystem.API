using ExpensesTrackingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Services
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetCurrencies();
        Currency GetCurrency(int Id);
        bool CurrencyExists(int Id);
    }
}
