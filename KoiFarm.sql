CREATE TABLE CaKoi (
    CaKoiID INT PRIMARY KEY IDENTITY(1,1),    -- ID t? tang cho m?i cá koi
    Ten NVARCHAR(50) NOT NULL,                -- Tên cá koi
    Tuoi INT,                                 -- Tu?i c?a cá koi
    KichThuoc DECIMAL(5, 2),                  -- Kích thu?c (cm)
    Gia DECIMAL(10, 2),                       -- Giá (VND)
    NguonGoc NVARCHAR(50),                    -- Ngu?n g?c c?a cá koi
    Giong NVARCHAR(50),                       -- Gi?ng cá koi
    Anh NVARCHAR(255)                         -- Ðu?ng d?n ho?c tên file ?nh
);
Go
CREATE TABLE DanhGia (
    DanhGiaID INT PRIMARY KEY IDENTITY(1,1),  -- ID duy nh?t cho m?i ?ánh giá
    CaKoiID INT,                              -- Khóa ngo?i tham chi?u ??n b?ng CaKoi
    Diem INT CHECK (Diem BETWEEN 1 AND 5),    -- ?i?m ?ánh giá (1 ??n 5)
    NoiDung NVARCHAR(255),                    -- N?i dung ?ánh giá
        FOREIGN KEY (CaKoiID) REFERENCES CaKoi(CaKoiID)  -- Tham chi?u ??n b?ng CaKoi d?a trên CaKoiID
);
Go
CREATE TABLE GioHangCuaToi (
    GioHangID INT PRIMARY KEY IDENTITY(1,1),  -- Khóa chính: ID duy nh?t cho m?i m?c trong gi? hàng
    CaKoiID INT,                              -- Khóa ngo?i tham chi?u ??n b?ng CaKoi
    SoLuong INT CHECK (SoLuong > 0),          -- S? l??ng cá koi
    FOREIGN KEY (CaKoiID) REFERENCES CaKoi(CaKoiID)  -- Tham chi?u ??n b?ng CaKoi d?a trên CaKoiID
);
Go
CREATE TABLE SanPham (
    SanPhamID INT PRIMARY KEY IDENTITY(1,1),  -- Khóa chính: ID duy nh?t cho m?i s?n ph?m
    TenSanPham NVARCHAR(50) NOT NULL,         -- Tên s?n ph?m (Tên cá koi)
    KichThuoc DECIMAL(5, 2),                  -- Kích th??c s?n ph?m (Size, e.g., in cm)
    Gia DECIMAL(10, 2),                       -- Giá s?n ph?m (Price, e.g., in VND)
    NguonGoc NVARCHAR(50),                    -- Ngu?n g?c s?n ph?m (Origin)
    Giong NVARCHAR(50),                       -- Gi?ng s?n ph?m (Breed)
    GioiTinh NVARCHAR(50),		      -- Gi?i Tính
    Anh VARBINARY(MAX)                        -- ?nh s?n ph?m (Image)
);
CREATE TABLE LichSuMuaHang (
    MuaHangID INT PRIMARY KEY IDENTITY(1,1),  -- Khóa chính: ID duy nh?t cho m?i giao d?ch
    MaKhachHang INT,                          -- Mã khách hàng (Foreign key from KhachHang table)
    SanPhamID INT,                            -- Khóa ngo?i tham chi?u ??n b?ng SanPham
    SoLuong INT CHECK (SoLuong > 0),          -- S? l??ng s?n ph?m mua
    NgayMua DATE DEFAULT GETDATE(),          -- Ngày mua hàng, m?c ??nh là ngày hi?n t?i
    FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID)  -- Tham chi?u ??n b?ng SanPham
);
GO
CREATE TABLE Users (
    id INT PRIMARY KEY IDENTITY(1,1),               -- Khóa chính cho ng??i dùng
    username NVARCHAR(50) NOT NULL UNIQUE,           -- Tên ??ng nh?p
    password NVARCHAR(255) NOT NULL,                 -- M?t kh?u
    role NVARCHAR(50) DEFAULT 'guest',               -- Vai trò c?a ng??i dùng
phone_number NVARCHAR(15),                       -- S? ?i?n tho?i
    email NVARCHAR(100)                              -- ??a ch? email
);

CREATE TABLE NguoiDung (
    KhachHangID INT PRIMARY KEY IDENTITY(1,1),       -- Khóa chính cho khách hàng
    TenKhachHang NVARCHAR(100) NOT NULL,             -- Tên khách hàng
    Email NVARCHAR(100),                             -- ??a ch? email
    SoDienThoai NVARCHAR(15),                        -- S? ?i?n tho?i
    DiaChi NVARCHAR(255),                            -- ??a ch?
    NgayTao DATE DEFAULT GETDATE(),                  -- Ngày t?o tài kho?n khách hàng
    UserID INT,                                      -- Khóa ngo?i tham chi?u ??n b?ng Users
    FOREIGN KEY (UserID) REFERENCES Users(id)        -- Khóa ngo?i liên k?t v?i b?ng Users
);

GO
-- T?o b?ng LichSuKyGui tr??c
CREATE TABLE LichSuKyGui (
    LichSuKyGuiID INT PRIMARY KEY IDENTITY(1,1),    -- Khóa chính: ID duy nh?t cho m?i b?n ghi l?ch s? ký g?i
    KyGuiID INT,                                     -- ID c?a s?n ph?m ký g?i (Khóa ngo?i tham chi?u ??n b?ng KyGui)
    NgayXacNhan DATE DEFAULT GETDATE(),              -- Ngày xác nh?n ký g?i (m?c ??nh là ngày hi?n t?i)
    ThaoTac NVARCHAR(255),                           -- Hành ??ng ???c th?c hi?n (Ví d?: Ký g?i, Hoàn tr?, C?p nh?t)
    TrangThai NVARCHAR(50) DEFAULT '?ang ký g?i'     -- Tr?ng thái hi?n t?i c?a s?n ph?m ký g?i (Ví d?: ?ang ký g?i, ?ã hoàn tr?)
);
 
-- Sau ?ó, t?o b?ng KyGui v?i khóa ngo?i tham chi?u ??n b?ng LichSuKyGui
CREATE TABLE KyGui (
    KyGuiID INT PRIMARY KEY IDENTITY(1,1),           -- Khóa chính: ID duy nh?t cho m?i s?n ph?m ký g?i
    TenSanPham NVARCHAR(100) NOT NULL,               -- Tên s?n ph?m ký g?i
    Tuoi INT,                                        -- Tu?i c?a s?n ph?m
    GioiTinh NVARCHAR(10),                           -- Gi?i tính c?a s?n ph?m
    NguonGoc NVARCHAR(100),                          -- Ngu?n g?c c?a s?n ph?m
    ChuanLoai NVARCHAR(100),                         -- Chu?n lo?i c?a s?n ph?m
    TinhCach NVARCHAR(255),                          -- Tính cách c?a s?n ph?m
    LuongThucAnNgay DECIMAL(5, 2),                   -- L??ng th?c ?n/ngày c?a s?n ph?m
    SoLuong INT,                                     -- S? l??ng s?n ph?m ký g?i
    URLHinhAnh NVARCHAR(255),                        -- ???ng d?n ??n hình ?nh s?n ph?m
    NgayKyGui DATE DEFAULT GETDATE(),                -- Ngày ký g?i s?n ph?m
    FOREIGN KEY (KyGuiID) REFERENCES LichSuKyGui(LichSuKyGuiID)  -- Khóa ngo?i tham chi?u ??n b?ng LichSuKyGui
);