using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

public class FilterPeopleFrom
{
    public static string FilterPeopleFromXml(string xmlData)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(xmlData))
                throw new ArgumentException("XML verisi boş veya null olamaz.");

            var people = ParsePeople(xmlData);
            var filtered = FilterValidPeople(people);

            if (!filtered.Any())
            {
                return JsonSerializer.Serialize(new ResultObject
                {
                    ErrorMessage = "Filtre kriterlerine uygun kişi bulunamadı."
                });
            }

            return SerializeResult(filtered);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new ResultObject
            {
                ErrorMessage = $"Hata: {ex.Message}"
            });
        }
    }

    private static List<Person> ParsePeople(string xmlData)
    {
        if (string.IsNullOrWhiteSpace(xmlData))
            throw new ArgumentException("XML verisi boş veya null olamaz.");

        var doc = XDocument.Parse(xmlData);

        return doc.Descendants("Person")
            .Select(p => new Person
            {
                Name = (string?)p.Element("Name") ?? "",
                Age = (int?)p.Element("Age") ?? 0,
                Department = (string?)p.Element("Department") ?? "",
                Salary = (double?)p.Element("Salary") ?? 0,
                HireDate = DateTime.TryParse((string?)p.Element("HireDate"), out var date) ? date : DateTime.MinValue
            })
            .ToList();
    }

    private static List<Person> FilterValidPeople(List<Person> people) =>
        people.Where(p => p.Age > 30 && p.Department == "IT" && p.Salary > 5000 && p.HireDate.Year < 2019).ToList();

    private static string SerializeResult(List<Person> filtered)
    {
        var result = new ResultObject
        {
            Names = filtered.Select(p => p.Name).OrderBy(n => n).ToList(),
            TotalSalary = filtered.Sum(p => p.Salary),
            AverageSalary = filtered.Average(p => p.Salary),
            MaxSalary = filtered.Max(p => p.Salary),
            Count = filtered.Count
        };

        return JsonSerializer.Serialize(result);
    }

    private class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Department { get; set; } = "";
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class ResultObject
    {
        public List<string> Names { get; set; } = new List<string>();
        public double TotalSalary { get; set; }
        public double AverageSalary { get; set; }
        public double MaxSalary { get; set; }
        public int Count { get; set; }
        public string? ErrorMessage { get; set; } = null;
    }
}
