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
        public ActionResult<IEnumerable<ExpenseDto>> GetAllUserExpenses(int userId)
        {
            if (!_expensesRepository.UserExists(userId))
            {
                return NotFound();
            }
            var allUserExpenses = _expensesRepository.GetAllUserExpenses(userId);
            return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(allUserExpenses));
        }
        [HttpGet("{expenseId}", Name = "GetSingleUserExpense")]
        public ActionResult<IEnumerable<ExpenseDto>> GetSingleUserExpense(int userId, int expenseId)
        {
            if (!_expensesRepository.UserExists(userId))
            {
                return NotFound();
            }
            if (!_expensesRepository.ExpenseExists(expenseId))
            {
                return NotFound();
            }
            var singleUserExpense = _expensesRepository.GetSingleUserExpense(userId, expenseId);
            return Ok(_mapper.Map<ExpenseDto>(singleUserExpense));
        }

        [HttpPost]
        public ActionResult<IEnumerable<ExpenseDto>> CreateExpenseForUser(int userId, IEnumerable<CreateExpenseDto> expenseCollection)
        {
            if (!_expensesRepository.UserExists(userId))
            {
                return NotFound();
            }
            var expenseEntities = _mapper.Map<IEnumerable<Entities.Expenses>>(expenseCollection);
            foreach(var expense in expenseEntities)
            {
                _expensesRepository.AddExpense(userId, expense);
            }
           
            _expensesRepository.Save();
            var expenseToReturn = _mapper.Map<IEnumerable <ExpenseDto>>(expenseEntities);
              return CreatedAtRoute("GetSingleUserExpense", 
              new { userId = userId, expenseId = expenseToReturn.Select(a=>a.Id) }, expenseToReturn);
            
        }
    }
}
