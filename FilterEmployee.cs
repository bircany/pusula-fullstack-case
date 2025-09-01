using System.Text.Json;

public static class FilterEmployee
{
    public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        try
        {
            if (employees == null)
                throw new ArgumentNullException(nameof(employees), "Çalışan listesi null olamaz.");

            if (!employees.Any())
                throw new ArgumentException("Çalışan listesi boş olamaz.");

            var filtered = employees
                .Where(MeetsAllCriteria)
                .OrderByDescending(e => e.Name.Length)
                .ThenBy(e => e.Name)
                .ToList();

            return CreateResult(filtered);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new ResultObject
            {
                ErrorMessage = ex.Message
            });
        }
    }
    private static bool MeetsAllCriteria((string Name, int Age, string Department, decimal Salary, DateTime HireDate) e) =>
        !string.IsNullOrWhiteSpace(e.Name) &&
        e.Age is >= 25 and <= 40 &&
        (e.Department == "IT" || e.Department == "Finance") &&
        e.Salary is >= 5000 and <= 9000 &&
        e.HireDate.Year >= 2017;

    private static string CreateResult(List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        if (!employees.Any())
        {
            return JsonSerializer.Serialize(new ResultObject
            {
                Names = new List<string>(),
                TotalSalary = 0m,
                AverageSalary = 0m,
                MinSalary = 0m,
                MaxSalary = 0m,
                Count = 0
            });
        }

        var result = new ResultObject
        {
            Names = employees.Select(e => e.Name)
                             .OrderByDescending(n => n.Length)
                             .ThenBy(n => n)
                             .ToList(),

            TotalSalary = employees.Sum(e => e.Salary),
            AverageSalary = employees.Average(e => e.Salary),
            MinSalary = employees.Min(e => e.Salary),
            MaxSalary = employees.Max(e => e.Salary),
            Count = employees.Count
        };

        return JsonSerializer.Serialize(result);
    }
    public class ResultObject
    {
        public List<string> Names { get; set; } = new();
        public decimal TotalSalary { get; set; }
        public decimal AverageSalary { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public int Count { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
