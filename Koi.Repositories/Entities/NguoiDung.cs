using System;
using System.Collections.Generic;

namespace Koi.Repositories.Entities;

public partial class NguoiDung
{
    public int KhachHangId { get; set; }

    public string TenKhachHang { get; set; } = null!;

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayTao { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
