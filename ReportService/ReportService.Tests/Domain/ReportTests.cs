using System.Collections.Generic;
using NUnit.Framework;
using ReportService.Domain;

namespace ReportService.Tests.Domain
{
    [TestFixture]
    public class ReportTests
    {
        [Test]
        public void CalculateSalaries_WithTwoDepartments_CalculatedCorrectly()
        {
            var report = new Report(new ReportTitle(1, 2017), new List<Department>
            {
                new("Бухгалтерия", new List<Employee>
                {
                    new("Василий Васильевич Кузнецов", 50000m),
                    new("Демьян Сергеевич Коротченко", 55000m)
                }),
                new("ИТ", new List<Employee>
                {
                    new("Фрол Романович Козлов", 90000m)
                })
            });

            var totalAmount = report.CalculateSalaries();

            Assert.AreEqual(195000m, totalAmount);
        }
    }
}