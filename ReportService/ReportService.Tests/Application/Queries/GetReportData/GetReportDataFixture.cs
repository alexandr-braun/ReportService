using System.Collections.Generic;
using ReportService.Infrastructure.Repositories.Department;
using ReportService.Infrastructure.Repositories.Employee;

namespace ReportService.Tests.Application.Queries.GetReportData
{
    internal class GetReportDataFixture
    {
        internal DepartmentDbModel[] Departments { get; private set; }
        internal EmployeeDbModel[] Employees { get; private set; }
        internal Dictionary<int, decimal> Salaries { get; private set; }

        internal GetReportDataFixture()
        {
            Departments = new []
            {
                new DepartmentDbModel { Id = 1, Name = "ФинОтдел", Active = true },
                new DepartmentDbModel { Id = 2, Name = "Бухгалтерия", Active = true },
                new DepartmentDbModel { Id = 3, Name = "ИТ", Active = true }
            };

            Employees = new []
            {
                new EmployeeDbModel { Id = 1, Name = "Андрей Сергеевич Бубнов", DepartmentId = 1, Inn = "1" },
                new EmployeeDbModel { Id = 2, Name = "Григорий Евсеевич Зиновьев", DepartmentId = 1, Inn = "2" },
                new EmployeeDbModel { Id = 3, Name = "Яков Михайлович Свердлов", DepartmentId = 1, Inn = "3" },
                new EmployeeDbModel { Id = 4, Name = "Алексей Иванович Рыков", DepartmentId = 1, Inn = "4" },
                new EmployeeDbModel { Id = 5, Name = "Василий Васильевич Кузнецов", DepartmentId = 2, Inn = "5" },
                new EmployeeDbModel { Id = 6, Name = "Демьян Сергеевич Коротченко", DepartmentId = 2, Inn = "6" },
                new EmployeeDbModel { Id = 7, Name = "Михаил Андреевич Суслов", DepartmentId = 2, Inn = "7" },
                new EmployeeDbModel { Id = 8, Name = "Фрол Романович Козлов", DepartmentId = 3, Inn = "8" },
                new EmployeeDbModel { Id = 9, Name = "Дмитрий Степанович Полянски", DepartmentId = 3, Inn = "9" },
                new EmployeeDbModel { Id = 10, Name = "Андрей Павлович Кириленко", DepartmentId = 3, Inn = "10" },
                new EmployeeDbModel { Id = 11, Name = "Арвид Янович Пельше", DepartmentId = 3, Inn = "11" }
            };

            Salaries = new Dictionary<int, decimal>
            {
                { 1, 70000 },
                { 2, 65000 },
                { 3, 80000 },
                { 4, 90000 },
                { 5, 50000 },
                { 6, 55000 },
                { 7, 35000 },
                { 8, 90000 },
                { 9, 120000 },
                { 10, 110000 },
                { 11, 120000 }
            };
        }
    }
}