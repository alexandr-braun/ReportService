using System;
using NUnit.Framework;
using ReportService.Domain;

namespace ReportService.Tests.Domain
{
    [TestFixture]
    public class ReportTitleTests
    {
        [Test]
        [TestCase(1, 2017, ExpectedResult = "Январь 2017")]
        [TestCase(2, 2017, ExpectedResult = "Февраль 2017")]
        [TestCase(3, 2017, ExpectedResult = "Март 2017")]
        [TestCase(4, 2017, ExpectedResult = "Апрель 2017")]
        [TestCase(5, 2017, ExpectedResult = "Май 2017")]
        [TestCase(6, 2017, ExpectedResult = "Июнь 2017")]
        [TestCase(7, 2017, ExpectedResult = "Июль 2017")]
        [TestCase(8, 2017, ExpectedResult = "Август 2017")]
        [TestCase(9, 2017, ExpectedResult = "Сентябрь 2017")]
        [TestCase(10, 2017, ExpectedResult = "Октябрь 2017")]
        [TestCase(11, 2017, ExpectedResult = "Ноябрь 2017")]
        [TestCase(12, 2017, ExpectedResult = "Декабрь 2017")]
        public string ReportTitleConstructor_CorrectMonthNumberPassed_SetCorrectValue(int monthNumber, int year)
        {
            var reportTitle = new ReportTitle(monthNumber, year);
            
            return reportTitle.Value;
        }
        
        [TestCase(-10, 2020)]
        [TestCase(0, 2020)]
        [TestCase(25, 2020)]
        public void ReportTitleConstructor_InvalidMonthPassed_ThrowsArgumentException(int month, int year)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ReportTitle(month, year));
        }
    }
}