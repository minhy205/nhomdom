using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class CaKoi
{
    public int CaKoiId { get; set; }

    public string Ten { get; set; } = null!;

    public int? Tuoi { get; set; }

    public decimal? KichThuoc { get; set; }

    public decimal? Gia { get; set; }

    public string? NguonGoc { get; set; }

    public string? Giong { get; set; }

    public byte[]? Anh { get; set; }

    public virtual ICollection<DanhGia> DanhGia { get; set; } = new List<DanhGia>();

    public virtual ICollection<GioHangCuaToi> GioHangCuaTois { get; set; } = new List<GioHangCuaToi>();
}
