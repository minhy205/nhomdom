using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class KyGui
{
    public int KyGuiId { get; set; }

    public string TenSanPham { get; set; } = null!;

    public int? Tuoi { get; set; }

    public string? GioiTinh { get; set; }

    public string? NguonGoc { get; set; }

    public string? ChuanLoai { get; set; }

    public string? TinhCach { get; set; }

    public decimal? LuongThucAnNgay { get; set; }

    public int? SoLuong { get; set; }

    public string? UrlhinhAnh { get; set; }

    public DateOnly? NgayKyGui { get; set; }

    public virtual LichSuKyGui KyGuiNavigation { get; set; } = null!;
}
