using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class DanhGia
{
    public int DanhGiaId { get; set; }

    public int? CaKoiId { get; set; }

    public int? Diem { get; set; }

    public string? NoiDung { get; set; }

    public virtual CaKoi? CaKoi { get; set; }

}

