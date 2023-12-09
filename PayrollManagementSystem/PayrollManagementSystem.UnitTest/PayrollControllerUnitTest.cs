using PayrollManagementSystem.Controllers;
using PayrollManagementSystem.Model.DatabaseContect;
using PayrollManagementSystem.Model.Models;

namespace PayrollManagementSystem.UnitTest
{
    [TestClass]
    public class PayrollControllerUnitTest
    {
        [TestMethod]
        public void TestForIndex()
        {
            var payrolls = new List<Payroll>();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var payrollController = new PayrollController(dbContext);

            // Act
            var viewResult = payrollController.Index();

            // Assert
            Assert.AreEqual<ICollection<Payroll>>(payrolls, payrolls);
        }

        [TestMethod]
        public void TestForCreate()
        {
            var payroll = new Payroll();

            // Arrange
            var dbContext = new PayrollManagementSystemContext();
            var payrollController = new PayrollController(dbContext);

            // Act
            var viewResult = payrollController.Create();

            // Assert
            Assert.AreEqual<Payroll>(payroll, payroll);
        }

        //[TestMethod]
        //public void TestForDetails()
        //{
        //    var payroll = new Payroll();

        //    // Arrange
        //    var dbContext = new PayrollManagementSystemContext();
        //    var payrollController = new PayrollController(dbContext);

        //    // Act
        //    var viewResult = payrollController.Details(1);

        //    // Assert
        //    Assert.AreEqual<Payroll>(payroll, payroll);
        //}

        //[TestMethod]
        //public void TestForDelete()
        //{
        //    var payroll = new Payroll();

        //    // Arrange
        //    var dbContext = new PayrollManagementSystemContext();
        //    var payrollController = new PayrollController(dbContext);

        //    // Act
        //    var viewResult = payrollController.Delete(1);

        //    // Assert
        //    Assert.AreEqual<Payroll>(payroll, payroll);
        //}
    }
}