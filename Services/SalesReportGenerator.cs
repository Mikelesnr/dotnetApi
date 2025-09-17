using System.Text;

namespace ContosoPizza.Services
{
    public static class SalesReportGenerator
    {
        public static void GenerateSummary(string inputFilePath, string outputFilePath)
        {
            var lines = File.ReadAllLines(inputFilePath);
            decimal totalSales = 0;
            var report = new StringBuilder();

            report.AppendLine("Sales Summary Report");
            report.AppendLine("---------------------");

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var quantity = int.Parse(parts[1].Split(':')[1]);
                var price = decimal.Parse(parts[2].Split(':')[1]);
                var subtotal = quantity * price;
                totalSales += subtotal;

                report.AppendLine($"Pizza ID: {parts[0].Split(':')[1]}, Quantity: {quantity}, Subtotal: ${subtotal:F2}");
            }

            report.AppendLine("---------------------");
            report.AppendLine($"Total Sales: ${totalSales:F2}");

            File.WriteAllText(outputFilePath, report.ToString());
        }
    }
}
