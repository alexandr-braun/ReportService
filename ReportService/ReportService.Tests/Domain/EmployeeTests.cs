using System;
using NUnit.Framework;
using ReportService.Domain;

namespace ReportService.Tests.Domain
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void EmployeeConstructor_WithFullNameAndSalary_CreatedCorrectly()
        {
            var fullName = "Андрей Сергеевич Бубнов";
            var salary = 50000m;

            var employee = new Employee(fullName, salary);

            Assert.AreEqual(fullName, employee.FullName);
            Assert.AreEqual(salary, employee.Salary);
        }
        
        [Test]
        public void EmployeeConstructor_WithEmptyName_ThrowsArgumentException()
        {
            var fullName = string.Empty;
            var salary = 50000m;

            Assert.Throws<ArgumentNullException>(() => new Employee(fullName, salary)); 
        }
    }
}