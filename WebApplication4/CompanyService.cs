using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

public class CompanyService
{
    private readonly IConfiguration _configuration;

    public CompanyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetCompanyWithMostEmployees()
    {   
        var companies = _configuration.GetSection("Companies").Get<List<Company>>();

        if (companies == null || companies.Count == 0)
        {
            return "No companies found in configuration.";
        }

        var maxEmployees = companies.Max(c => c.Employees);
        var companyWithMostEmployees = companies.FirstOrDefault(c => c.Employees == maxEmployees);

        if (companyWithMostEmployees == null)
        {
            return "No company has the highest number of employees.";
        }

        return $"Company with the most employees: {companyWithMostEmployees.Name}";
    }
}

public class Company
{
    public string Name { get; set; }
    public int Employees { get; set; }
}