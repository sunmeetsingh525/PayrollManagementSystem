using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Model.DatabaseContect;
using PayrollManagementSystem.Model.Models;
using PayrollManagementSystem.Model.ViewModels;

namespace PayrollManagementSystem.Controllers
{
    public class PayrollController : Controller
    {
        private readonly PayrollManagementSystemContext _dbContext;
        public PayrollController(PayrollManagementSystemContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<ICollection<Payroll>>> Index()
        {
            var payrolls = await _dbContext.Payrolls
                          .Include(p => p.Employee)
                          .ToArrayAsync();

            return View(payrolls);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await GetEmployee();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PayrollCreateModel payrollModel)
        {
            if (ModelState.IsValid)
            {
                var payroll = new Payroll
                {
                    EmployeeId = payrollModel.EmployeeId,
                    NumberOfDaysWorked = payrollModel.NumberOfDaysWorked,
                    Deductions = payrollModel.Deductions,
                    TotalPayment = payrollModel.TotalPayment
                };

                _dbContext.Payrolls.Add(payroll);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await GetEmployee();
            return View(payrollModel);
        }

        //[HttpGet]
        //public async Task<ActionResult<Employee>> Details(int id)
        //{
        //    if (id == 0)
        //        return BadRequest();

        //    var existPayroll = await _dbContext.Payrolls.Where(e => e.Id == id).FirstOrDefaultAsync();

        //    if (existPayroll is null)
        //        return BadRequest();

        //    await GetEmployee();
        //    return View(existPayroll);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Details(Payroll payrollModel)
        //{
        //    _dbContext.Payrolls.Update(payrollModel);
        //    await _dbContext.SaveChangesAsync();
        //    await GetEmployee();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id == 0)
        //        return BadRequest();

        //    var existPayroll = await _dbContext.Payrolls.Where(e => e.Id == id).FirstOrDefaultAsync();

        //    if (existPayroll is null)
        //        return BadRequest();

        //    _dbContext.Payrolls.Remove(existPayroll);
        //    await _dbContext.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

        private async Task GetEmployee()
        {
            ViewBag.Employess = await _dbContext.Employees.Select(s => new SelectListViewModel
            {
                Id = s.Id,
                Name = s.FirstName + " " + s.LastName
            }).ToListAsync();
        }
    }
}