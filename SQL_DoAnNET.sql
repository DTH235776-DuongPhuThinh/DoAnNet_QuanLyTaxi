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

-- MOCK DATA CHO TÀI XẾ
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

-- MOCK DATA CHO LOẠI XE
INSERT INTO loaixe (SoXe, SoCho, GiaTrenKM, TrangThai, MoTa) VALUES
('51A-12345', 4, 15000, 'Dang dung', 'Taxi 4 cho mau trang'),
('51B-67890', 7, 20000, 'Dang dung', 'Taxi 7 cho mau vang'),
('50C-11223', 4, 16000, 'Ngung dung', 'Xe dang bao tri may lanh'),
('59D-33445', 16, 30000, 'Dang dung', 'Xe limousine cao cap'),
('51F-55667', 7, 22000, 'Ngung dung', 'Xe su dung noi thanh');