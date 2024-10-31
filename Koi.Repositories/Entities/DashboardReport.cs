using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class DashboardReport
{
    public int ReportId { get; set; }

    public DateTime? ReportDate { get; set; }

    public decimal? TotalSales { get; set; }

    public int? TotalCustomers { get; set; }

    public int? TotalKoiSold { get; set; }
}
