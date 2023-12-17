using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ReportService.Application.Queries.GetReportData;
using ReportService.Infrastructure.HttpClients.AccountingService;
using ReportService.Infrastructure.Repositories.Department;
using ReportService.Infrastructure.Repositories.Employee;

namespace ReportService.Tests.Application.Queries.GetReportData
{
    [TestFixture]
    public class GetReportDataQueryHandlerTests
    {
        private GetReportDataFixture _fixture;
        
        private Mock<IAccountingServiceHttpClient> _mockAccountingServiceHttpClient;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private Mock<IDepartmentRepository> _mockDepartmentRepository;
        private GetReportDataQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _fixture = new GetReportDataFixture();
            
            _mockAccountingServiceHttpClient = new Mock<IAccountingServiceHttpClient>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockDepartmentRepository = new Mock<IDepartmentRepository>();

            _handler = new GetReportDataQueryHandler(_mockAccountingServiceHttpClient.Object, _mockEmployeeRepository.Object, _mockDepartmentRepository.Object);
        }

        [Test]
        public async Task Handle_CorrectQueryPassed_ReturnsCorrectReport()
        {
            _mockDepartmentRepository.Setup(repo => repo.GetAll())
                .ReturnsAsync(_fixture.Departments);

            _mockEmployeeRepository.Setup(repo => repo.GetAll())
                .ReturnsAsync(_fixture.Employees);

            _mockAccountingServiceHttpClient.Setup(client => client.GetEmployeeSalary(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string inn, CancellationToken _) => _fixture.Salaries[int.Parse(inn)]);

            var query = new GetReportDataQuery(2017, 1);

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("Январь 2017"));

            Assert.IsTrue(result.Contains("ФинОтдел"));
            Assert.IsTrue(result.Contains("Андрей Сергеевич Бубнов\t\t70000р"));
            Assert.IsTrue(result.Contains("Григорий Евсеевич Зиновьев\t\t65000р"));
            Assert.IsTrue(result.Contains("Яков Михайлович Свердлов\t\t80000р"));
            Assert.IsTrue(result.Contains("Алексей Иванович Рыков\t\t90000р"));
            Assert.IsTrue(result.Contains("Всего по отделу\t\t305000р"));

            Assert.IsTrue(result.Contains("Бухгалтерия"));
            Assert.IsTrue(result.Contains("Василий Васильевич Кузнецов\t\t50000р"));
            Assert.IsTrue(result.Contains("Демьян Сергеевич Коротченко\t\t55000р"));
            Assert.IsTrue(result.Contains("Михаил Андреевич Суслов\t\t35000р"));
            Assert.IsTrue(result.Contains("Всего по отделу\t\t140000р"));

            Assert.IsTrue(result.Contains("ИТ"));
            Assert.IsTrue(result.Contains("Фрол Романович Козлов\t\t90000р"));
            Assert.IsTrue(result.Contains("Дмитрий Степанович Полянски\t\t120000р"));
            Assert.IsTrue(result.Contains("Андрей Павлович Кириленко\t\t110000р"));
            Assert.IsTrue(result.Contains("Арвид Янович Пельше\t\t120000р"));
            Assert.IsTrue(result.Contains("Всего по отделу\t\t440000р"));

            Assert.IsTrue(result.Contains("Всего по предприятию\t\t885000р"));
        }
    }
}