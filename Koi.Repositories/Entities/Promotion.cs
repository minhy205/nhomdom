﻿using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string? Name { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
