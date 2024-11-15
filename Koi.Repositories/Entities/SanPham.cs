using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class SanPham
{
    public int SanPhamId { get; set; } // Đảm bảo tên này khớp với thuộc tính trong entity

    public string TenSanPham { get; set; }
    public decimal? KichThuoc { get; set; }
    public decimal? Gia { get; set; }
    public string NguonGoc { get; set; }
    public string Giong { get; set; }
    public string GioiTinh { get; set; }
    public byte[] Anh { get; set; }

    public virtual ICollection<LichSuMuaHang> LichSuMuaHangs { get; set; } = new List<LichSuMuaHang>();
}
