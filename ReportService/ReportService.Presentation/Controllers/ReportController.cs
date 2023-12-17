using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.Queries.GetReportData;
using ReportService.Presentation.Converters;

namespace ReportService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly GetReportDataQueryHandler _getReportDataQueryHandler;

        public ReportController(GetReportDataQueryHandler getReportDataQueryHandler)
        {
            _getReportDataQueryHandler = getReportDataQueryHandler;
        }

        [HttpGet]
        [Route("{year}/{month}")]
        public async Task<IActionResult> Download(int year, int month)
        {
            var getReportDataQuery = new GetReportDataQuery(year, month);
            var reportData = await _getReportDataQueryHandler.Handle(getReportDataQuery, CancellationToken.None);

            var reportFile = ReportFileConverter.FromStringContent(reportData);
            return reportFile;
        }
    }
}