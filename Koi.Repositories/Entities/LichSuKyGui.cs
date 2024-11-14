using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class LichSuKyGui
{
    public int LichSuKyGuiId { get; set; }

    public int? KyGuiId { get; set; }

    public DateOnly? NgayXacNhan { get; set; }

    public string? ThaoTac { get; set; }

    public string? TrangThai { get; set; }

    public virtual KyGui? KyGui { get; set; }
}
