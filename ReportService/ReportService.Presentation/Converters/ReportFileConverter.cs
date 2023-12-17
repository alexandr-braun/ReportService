using Microsoft.AspNetCore.Mvc;

namespace ReportService.Presentation.Converters
{
    internal static class ReportFileConverter
    {
        internal static FileContentResult FromStringContent(string reportContent)
        {
            var contentBytes = System.Text.Encoding.UTF8.GetBytes(reportContent);
            var contentType = "text/plain";
            return new FileContentResult(contentBytes, contentType) { FileDownloadName = "report.txt" };
        }
    }
}