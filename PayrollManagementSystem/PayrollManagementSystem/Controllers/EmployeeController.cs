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
        public ActionResult Details(int id)
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}