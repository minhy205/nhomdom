CREATE TABLE CaKoi (
    CaKoiID INT PRIMARY KEY IDENTITY(1,1),    -- ID t? tang cho m?i c� koi
    Ten NVARCHAR(50) NOT NULL,                -- T�n c� koi
    Tuoi INT,                                 -- Tu?i c?a c� koi
    KichThuoc DECIMAL(5, 2),                  -- K�ch thu?c (cm)
    Gia DECIMAL(10, 2),                       -- Gi� (VND)
    NguonGoc NVARCHAR(50),                    -- Ngu?n g?c c?a c� koi
    Giong NVARCHAR(50),                       -- Gi?ng c� koi
    Anh NVARCHAR(255)                         -- �u?ng d?n ho?c t�n file ?nh
);
Go
CREATE TABLE DanhGia (
    DanhGiaID INT PRIMARY KEY IDENTITY(1,1),  -- ID duy nh?t cho m?i ?�nh gi�
    CaKoiID INT,                              -- Kh�a ngo?i tham chi?u ??n b?ng CaKoi
    Diem INT CHECK (Diem BETWEEN 1 AND 5),    -- ?i?m ?�nh gi� (1 ??n 5)
    NoiDung NVARCHAR(255),                    -- N?i dung ?�nh gi�
        FOREIGN KEY (CaKoiID) REFERENCES CaKoi(CaKoiID)  -- Tham chi?u ??n b?ng CaKoi d?a tr�n CaKoiID
);
Go
CREATE TABLE GioHangCuaToi (
    GioHangID INT PRIMARY KEY IDENTITY(1,1),  -- Kh�a ch�nh: ID duy nh?t cho m?i m?c trong gi? h�ng
    CaKoiID INT,                              -- Kh�a ngo?i tham chi?u ??n b?ng CaKoi
    SoLuong INT CHECK (SoLuong > 0),          -- S? l??ng c� koi
    FOREIGN KEY (CaKoiID) REFERENCES CaKoi(CaKoiID)  -- Tham chi?u ??n b?ng CaKoi d?a tr�n CaKoiID
);
Go
CREATE TABLE SanPham (
    SanPhamID INT PRIMARY KEY IDENTITY(1,1),  -- Kh�a ch�nh: ID duy nh?t cho m?i s?n ph?m
    TenSanPham NVARCHAR(50) NOT NULL,         -- T�n s?n ph?m (T�n c� koi)
    KichThuoc DECIMAL(5, 2),                  -- K�ch th??c s?n ph?m (Size, e.g., in cm)
    Gia DECIMAL(10, 2),                       -- Gi� s?n ph?m (Price, e.g., in VND)
    NguonGoc NVARCHAR(50),                    -- Ngu?n g?c s?n ph?m (Origin)
    Giong NVARCHAR(50),                       -- Gi?ng s?n ph?m (Breed)
    GioiTinh NVARCHAR(50),		      -- Gi?i T�nh
    Anh VARBINARY(MAX)                        -- ?nh s?n ph?m (Image)
);
CREATE TABLE LichSuMuaHang (
    MuaHangID INT PRIMARY KEY IDENTITY(1,1),  -- Kh�a ch�nh: ID duy nh?t cho m?i giao d?ch
    MaKhachHang INT,                          -- M� kh�ch h�ng (Foreign key from KhachHang table)
    SanPhamID INT,                            -- Kh�a ngo?i tham chi?u ??n b?ng SanPham
    SoLuong INT CHECK (SoLuong > 0),          -- S? l??ng s?n ph?m mua
    NgayMua DATE DEFAULT GETDATE(),          -- Ng�y mua h�ng, m?c ??nh l� ng�y hi?n t?i
    FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID)  -- Tham chi?u ??n b?ng SanPham
);
GO
CREATE TABLE Users (
    id INT PRIMARY KEY IDENTITY(1,1),               -- Kh�a ch�nh cho ng??i d�ng
    username NVARCHAR(50) NOT NULL UNIQUE,           -- T�n ??ng nh?p
    password NVARCHAR(255) NOT NULL,                 -- M?t kh?u
    role NVARCHAR(50) DEFAULT 'guest',               -- Vai tr� c?a ng??i d�ng
phone_number NVARCHAR(15),                       -- S? ?i?n tho?i
    email NVARCHAR(100)                              -- ??a ch? email
);

CREATE TABLE NguoiDung (
    KhachHangID INT PRIMARY KEY IDENTITY(1,1),       -- Kh�a ch�nh cho kh�ch h�ng
    TenKhachHang NVARCHAR(100) NOT NULL,             -- T�n kh�ch h�ng
    Email NVARCHAR(100),                             -- ??a ch? email
    SoDienThoai NVARCHAR(15),                        -- S? ?i?n tho?i
    DiaChi NVARCHAR(255),                            -- ??a ch?
    NgayTao DATE DEFAULT GETDATE(),                  -- Ng�y t?o t�i kho?n kh�ch h�ng
    UserID INT,                                      -- Kh�a ngo?i tham chi?u ??n b?ng Users
    FOREIGN KEY (UserID) REFERENCES Users(id)        -- Kh�a ngo?i li�n k?t v?i b?ng Users
);

GO
-- T?o b?ng LichSuKyGui tr??c
CREATE TABLE LichSuKyGui (
    LichSuKyGuiID INT PRIMARY KEY IDENTITY(1,1),    -- Kh�a ch�nh: ID duy nh?t cho m?i b?n ghi l?ch s? k� g?i
    KyGuiID INT,                                     -- ID c?a s?n ph?m k� g?i (Kh�a ngo?i tham chi?u ??n b?ng KyGui)
    NgayXacNhan DATE DEFAULT GETDATE(),              -- Ng�y x�c nh?n k� g?i (m?c ??nh l� ng�y hi?n t?i)
    ThaoTac NVARCHAR(255),                           -- H�nh ??ng ???c th?c hi?n (V� d?: K� g?i, Ho�n tr?, C?p nh?t)
    TrangThai NVARCHAR(50) DEFAULT '?ang k� g?i'     -- Tr?ng th�i hi?n t?i c?a s?n ph?m k� g?i (V� d?: ?ang k� g?i, ?� ho�n tr?)
);
 
-- Sau ?�, t?o b?ng KyGui v?i kh�a ngo?i tham chi?u ??n b?ng LichSuKyGui
CREATE TABLE KyGui (
    KyGuiID INT PRIMARY KEY IDENTITY(1,1),           -- Kh�a ch�nh: ID duy nh?t cho m?i s?n ph?m k� g?i
    TenSanPham NVARCHAR(100) NOT NULL,               -- T�n s?n ph?m k� g?i
    Tuoi INT,                                        -- Tu?i c?a s?n ph?m
    GioiTinh NVARCHAR(10),                           -- Gi?i t�nh c?a s?n ph?m
    NguonGoc NVARCHAR(100),                          -- Ngu?n g?c c?a s?n ph?m
    ChuanLoai NVARCHAR(100),                         -- Chu?n lo?i c?a s?n ph?m
    TinhCach NVARCHAR(255),                          -- T�nh c�ch c?a s?n ph?m
    LuongThucAnNgay DECIMAL(5, 2),                   -- L??ng th?c ?n/ng�y c?a s?n ph?m
    SoLuong INT,                                     -- S? l??ng s?n ph?m k� g?i
    URLHinhAnh NVARCHAR(255),                        -- ???ng d?n ??n h�nh ?nh s?n ph?m
    NgayKyGui DATE DEFAULT GETDATE(),                -- Ng�y k� g?i s?n ph?m
    FOREIGN KEY (KyGuiID) REFERENCES LichSuKyGui(LichSuKyGuiID)  -- Kh�a ngo?i tham chi?u ??n b?ng LichSuKyGui
);