using CrowAttackTracker.Components.Models;

namespace CrowAttackTracker.Components.Service;

public class ReportService
{
    private readonly List<Report> _reports = new();

    public ReportService()
    {
        // Hardcoded sample data - Area 1: Oslo
        _reports.Add(new Report { Lat = 59.9127, Lng = 10.7461, Severity = 3, Description = "Attack near park" });
        _reports.Add(new Report { Lat = 59.9129, Lng = 10.7459, Severity = 2, Description = "Chased by crows" });
        _reports.Add(new Report { Lat = 59.9130, Lng = 10.7463, Severity = 4, Description = "Aggressive crow attack" });

        // Area 2: Bergen
        _reports.Add(new Report { Lat = 60.3925, Lng = 5.3236, Severity = 3, Description = "Crow dive-bombing people" });
        _reports.Add(new Report { Lat = 60.3927, Lng = 5.3238, Severity = 1, Description = "Noisy crow cluster" });
        _reports.Add(new Report { Lat = 60.3930, Lng = 5.3240, Severity = 2, Description = "Crow stole food" });

        // Add a few more for density
        for (int i = 0; i < 4; i++)
        {
            _reports.Add(new Report { Lat = 59.9125 + i * 0.0002, Lng = 10.7461 + i * 0.0002, Severity = 2, Description = "Repeated attack" });
            _reports.Add(new Report { Lat = 60.3925 + i * 0.0001, Lng = 5.3236 + i * 0.0001, Severity = 3, Description = "Crow squawk" });
        }
    }

    public IReadOnlyList<Report> GetReports() => _reports;

    public void AddReport(Report report)
    {
        _reports.Add(report);
    }

    public void Clear()
    {
        _reports.Clear();
    }
}