using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class GioHangCuaToi
{
    public int GioHangId { get; set; }

    public int? CaKoiId { get; set; }

    public int? SoLuong { get; set; }

    public virtual CaKoi? CaKoi { get; set; }
}
