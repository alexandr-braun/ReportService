using System.Collections.Generic;
using NUnit.Framework;
using ReportService.Domain;

namespace ReportService.Tests.Domain
{
    [TestFixture]
    public class DepartmentTests
    {
        [Test]
        public void CalculateSalaries_WithTwoEmployees_CalculatedCorrectly()
        {
            var department = new Department("IT", new List<Employee>
            {
                new("Андрей Сергеевич Бубнов", 70000m),
                new("Григорий Евсеевич Зиновьев", 65000m)
            });

            var totalAmount = department.CalculateSalaries();

            Assert.AreEqual(135000m, totalAmount);
        }

    }
}