using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Model.DatabaseContect;
using PayrollManagementSystem.Model.Models;
using PayrollManagementSystem.Model.ViewModels;

namespace PayrollManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PayrollManagementSystemContext _dbContext;
        public EmployeeController(PayrollManagementSystemContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<ICollection<Employee>>> Index()
        {
            var employee = await _dbContext.Employees
                          .Include(e => e.Gender)
                          .Include(E => E.PaymentMethod)
                          .ToArrayAsync();

            return View(employee);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeCreateViewModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Code = employeeModel.Code,
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    PhoneNumber = employeeModel.PhoneNumber,
                    RelationshipStatus = employeeModel.RelationshipStatus,
                    GenderId = employeeModel.GenderId,
                    Age = employeeModel.Age,
                    DailyRate = employeeModel.DailyRate,
                    PaymentMethodId = employeeModel.PaymentMethodId,
                };

                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employeeModel);
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> Details(int id)
        {
            if (id == 0)
                return BadRequest();

            var existEmployee = await _dbContext.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existEmployee is null)
                return BadRequest();

            return View(existEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Employee employeeModel)
        {
            _dbContext.Employees.Update(employeeModel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var existEmployee = await _dbContext.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existEmployee is null)
                return BadRequest();

            _dbContext.Employees.Remove(existEmployee);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}