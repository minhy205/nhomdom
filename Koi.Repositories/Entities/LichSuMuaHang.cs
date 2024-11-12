using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class LichSuMuaHang
{
    public int MuaHangId { get; set; }

    public int? MaKhachHang { get; set; }

    public int? SanPhamId { get; set; }

    public int? SoLuong { get; set; }

    public DateOnly? NgayMua { get; set; }

    public virtual SanPham? SanPham { get; set; }
}
