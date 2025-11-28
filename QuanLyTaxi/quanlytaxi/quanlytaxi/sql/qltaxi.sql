-- ===============================
-- TẠO DATABASE QLTAXI
-- ===============================
DROP DATABASE IF EXISTS qltaxi;
CREATE DATABASE qltaxi;
USE qltaxi;

-- ===============================
-- BẢNG TÀI XẾ
-- ===============================
CREATE TABLE taixe (
    MaTaiXe INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    Dob DATE NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    GioiTinh ENUM('Nam', 'Nu', 'Khac') NOT NULL,
    Luong DECIMAL(18,2) NOT NULL,
    TrangThai ENUM('Dang lai', 'Khong lai') DEFAULT 'Khong lai'
);

-- MOCK DATA TÀI XẾ
INSERT INTO taixe (HoTen, Dob, SDT, GioiTinh, Luong, TrangThai) VALUES
('Nguyen Van A', '1985-03-14', '0912345678', 'Nam', 12000000, 'Dang lai'),
('Tran Thi B', '1990-07-22', '0987654321', 'Nu', 10000000, 'Khong lai'),
('Le Van C', '1982-11-10', '0901122334', 'Nam', 13000000, 'Dang lai'),
('Pham Minh D', '1989-01-05', '0933555777', 'Nam', 9000000, 'Khong lai'),
('Hoang My E', '1995-06-18', '0977445533', 'Nu', 11000000, 'Dang lai');

-- ===============================
-- BẢNG LOẠI XE
-- ===============================
CREATE TABLE loaixe (
    MaXe INT AUTO_INCREMENT PRIMARY KEY,
    SoXe VARCHAR(20) NOT NULL UNIQUE,
    SoCho INT NOT NULL,
    GiaTrenKM DECIMAL(18,2) NOT NULL,
    TrangThai ENUM('Dang dung', 'Ngung dung') DEFAULT 'Ngung dung',
    MoTa TEXT
);

-- MOCK DATA LOẠI XE
INSERT INTO loaixe (SoXe, SoCho, GiaTrenKM, TrangThai, MoTa) VALUES
('51A-12345', 4, 15000, 'Dang dung', 'Taxi 4 cho mau trang'),
('51B-67890', 7, 20000, 'Dang dung', 'Taxi 7 cho mau vang'),
('50C-11223', 4, 16000, 'Ngung dung', 'Xe dang bao tri may lanh'),
('59D-33445', 16, 30000, 'Dang dung', 'Xe limousine cao cap'),
('51F-55667', 7, 22000, 'Ngung dung', 'Xe su dung noi thanh');

-- ===============================
-- BẢNG KHÁCH HÀNG
-- ===============================
CREATE TABLE khachhang (
    MaKH INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    Email VARCHAR(100),
    GioiTinh ENUM('Nam', 'Nu', 'Khac') DEFAULT 'Nam',
    CCCD VARCHAR(20) UNIQUE
);

-- MOCK DATA KHÁCH HÀNG
INSERT INTO khachhang (HoTen, SDT, Email, GioiTinh, CCCD) VALUES
('Pham Tuan', '0911111111', 'tuan.pham@gmail.com', 'Nam', '079200123456'),
('Le Ha', '0922222222', 'ha.le@yahoo.com', 'Nu', '079200654321'),
('Nguyen Minh', '0933333333', 'minh.nguyen@gmail.com', 'Nam', '079200987654'),
('Tran Thu', '0944444444', 'thu.tran@gmail.com', 'Nu', '079200111222'),
('Vo Anh', '0955555555', 'anh.vo@gmail.com', 'Nam', '079200333444');

-- ===============================
-- BẢNG ĐẶT XE
-- ===============================
CREATE TABLE datxe (
    MaDatXe INT AUTO_INCREMENT PRIMARY KEY,
    MaKH INT NOT NULL,
    MaXe INT NOT NULL,
    MaTaiXe INT NOT NULL,
    DiemDon VARCHAR(255) NOT NULL,
    DiemDen VARCHAR(255) NOT NULL,
    SoCho INT NOT NULL,
    NgayDat DATETIME DEFAULT NOW(),
    FOREIGN KEY (MaKH) REFERENCES khachhang(MaKH),
    FOREIGN KEY (MaXe) REFERENCES loaixe(MaXe),
    FOREIGN KEY (MaTaiXe) REFERENCES taixe(MaTaiXe)
);

-- MOCK DATA ĐẶT XE
INSERT INTO datxe (MaKH, MaXe, MaTaiXe, DiemDon, DiemDen, SoCho) VALUES
(1, 1, 1, 'Quan 1', 'San bay Tan Son Nhat', 4),
(2, 2, 2, 'Quan Binh Thanh', 'Quan 7', 7),
(3, 3, 3, 'Thu Duc', 'Quan 3', 4),
(4, 4, 4, 'Quan 2', 'Vung Tau', 16),
(5, 1, 5, 'Quan 5', 'Ben xe Mien Tay', 4);

-- ===============================
-- BẢNG THỐNG KÊ TÀI XẾ
-- ===============================
CREATE TABLE thongke (
    MaTaiXe INT PRIMARY KEY,
    SoChuyen INT DEFAULT 0,
    DoanhThu DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (MaTaiXe) REFERENCES taixe(MaTaiXe)
);

-- ===============================
-- MOCK DATA BẢNG THỐNG KÊ
-- ===============================
INSERT INTO thongke (MaTaiXe, SoChuyen, DoanhThu) VALUES
(1, 1, 150000),   
(2, 1, 200000),   
(3, 1, 160000),   
(4, 1, 480000),   
(5, 1, 120000);   

