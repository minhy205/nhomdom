using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class PaymentHistory
{
    public int PaymentId { get; set; }

    public int? CustomerId { get; set; }

    public decimal Amount { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }
}
