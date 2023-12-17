using System.Globalization;

namespace ReportService.Domain
{
    public struct ReportTitle
    {
        public string Value { get; }

        public ReportTitle(int monthNumber, int year)
        {
            var russianMonthName = GetRussianMonthName(monthNumber);

            Value = $"{(russianMonthName)} {year}";
        }

        private static string GetRussianMonthName(int month)
        {
            var russianCultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            var russianMonthName = russianCultureInfo.DateTimeFormat.GetMonthName(month);
            
            return ToCamelCase(russianCultureInfo, russianMonthName);
        }

        private static string ToCamelCase(CultureInfo cultureInfo, string russianMonthName)
        {
            return cultureInfo.TextInfo.ToTitleCase(russianMonthName);
        }

        public override string ToString() => Value;
    }
}