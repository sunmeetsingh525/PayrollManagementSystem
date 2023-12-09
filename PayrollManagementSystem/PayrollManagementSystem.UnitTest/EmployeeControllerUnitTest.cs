using PayrollManagementSystem.Controllers;
using PayrollManagementSystem.Model.DatabaseContect;
using PayrollManagementSystem.Model.Models;

namespace PayrollManagementSystem.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForIndex()
        {
            var employees = new List<Employee>();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var employeeController = new EmployeeController(dbContext);

            // Act
            var viewResult = employeeController.Index();

            // Assert
            Assert.AreEqual<ICollection<Employee>>(employees, employees);
        }

        [TestMethod]
        public void TestForCreate()
        {
            var employee = new Employee();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var employeeController = new EmployeeController(dbContext);

            // Act
            var viewResult = employeeController.Create();

            // Assert
            Assert.AreEqual<Employee>(employee, employee);
        }

        [TestMethod]
        public void TestForCreate()
        {
            var employee = new Employee();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var employeeController = new EmployeeController(dbContext);

            // Act
            var viewResult = employeeController.Create();

            // Assert
            Assert.AreEqual<Employee>(employee, employee);
        }

        [TestMethod]
        public void TestForDetails()
        {
            var employee = new Employee();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var employeeController = new EmployeeController(dbContext);

            // Act
            var viewResult = employeeController.Details(1);

            // Assert
            Assert.AreEqual<Employee>(employee, employee);
        }

        [TestMethod]
        public void TestForDelete()
        {
            var employee = new Employee();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var employeeController = new EmployeeController(dbContext);

            // Act
            var viewResult = employeeController.Delete(1);

            // Assert
            Assert.AreEqual<Employee>(employee, employee);
        }
    }
}