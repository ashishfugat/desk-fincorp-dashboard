using firefinancebackend.Models;
using firefinancebackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace firefinancebackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly JsonFileService _jsonService;

        public FinanceController(JsonFileService jsonService)
        {
            _jsonService = jsonService;
        }

        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            var incomes = _jsonService.ReadData<Income>("Data/income.json");
            return Ok(incomes);
        }

        [HttpGet("expenses")]
        public IActionResult GetExpenses()
        {
            var expenses = _jsonService.ReadData<Expense>("Data/expense.json");
            return Ok(expenses);
        }

        [HttpPost("incomes")]
        public IActionResult AddIncome([FromBody] Income income)
        {
            _jsonService.AppendData("Data/incomes.json", income);
            return Ok(income);
        }

        [HttpPost("expenses")]
        public IActionResult AddExpense([FromBody] Expense expense)
        {
            _jsonService.AppendData("Data/expenses.json", expense);
            return Ok(expense);
        }
    }
}
