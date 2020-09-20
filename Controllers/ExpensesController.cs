using AutoMapper;
using ExpensesTrackingSystem.API.Models;
using ExpensesTrackingSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Controllers
{
    [ApiController]
    [Route("api/users/{UserId}/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IMapper _mapper;
        public ExpensesController(IExpensesRepository expensesRepository,
            IMapper mapper)
        {
            _expensesRepository = expensesRepository ??
                throw new ArgumentNullException(nameof(expensesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseDto>> GetAllUserExpenses(int UserId)
        {
            if (!_expensesRepository.UserExists(UserId))
            {
                return NotFound();
            }
            var allUserExpenses = _expensesRepository.GetAllUserExpenses(UserId);
            return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(allUserExpenses));
        }
        [HttpGet("{ExpenseId}")]
        public ActionResult<IEnumerable<ExpenseDto>> GetSingleUserExpense(int UserId, int ExpenseId)
        {
            if (!_expensesRepository.UserExists(UserId))
            {
                return NotFound();
            }
            if (!_expensesRepository.ExpenseExists(ExpenseId))
            {
                return NotFound();
            }
            var singleUserExpense = _expensesRepository.GetSingleUserExpense(UserId, ExpenseId);
            return Ok(_mapper.Map<ExpenseDto>(singleUserExpense));
        }
    }
}
