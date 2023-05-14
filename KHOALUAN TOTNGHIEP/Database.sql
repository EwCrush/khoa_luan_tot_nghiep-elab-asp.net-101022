create database elab

use elab

create table DonVi
(
	MaDV int identity not null primary key,
	TenDV nvarchar(max)
)

create table ChucVu
(
	MaCV int identity not null primary key,
	TenCV nvarchar(max)
)

create table PhongLab
(
	MaPL int identity not null primary key,
	TenPL nvarchar(max) not null,
	DiaChi nvarchar(max)
)

create table NhaSanXuat 
(
	MaNSX int identity not null primary key,
	TenNSX nvarchar(max) not null,
	SDT varchar(20),
	Email varchar(100),
	DiaChi nvarchar(max)
)

create table NhaCungCap
(
	MaNCC int identity not null primary key,
	TenNCC nvarchar(max) not null,
	SDT varchar(100),
	Email varchar(100),
	DiaChi nvarchar(max)
)

create table NhanVien
(
	MaNV int identity not null primary key,
	TenNV nvarchar(max) not null,
	GioiTinh nvarchar(10),
	NgaySinh date,
	SDT varchar(20),
	DiaChi nvarchar(max),
	TaiKhoan varchar(20) unique,
	MatKhau varchar(20),
	MaDV int not null,
	MaCV int not null,
	constraint NhanVien_MaDV foreign key (MaDV) references DonVi (MaDV),
	constraint NhanVien_MaCV foreign key (MaCV) references ChucVu (MaCV)
)

create table HoaChat
(
	MaHC int identity not null primary key,
	TenHC nvarchar (max),
	CTHH nvarchar(max), --cong thuc hoa hoc
	MaNSX int,
	MaNCC int,
	NgayNhap date check (NgayNhap<=getdate()),
	SoLuongNhap int check (SoLuongNhap >=0),
	SoLuongXuat int check (SoLuongXuat >=0),
	SoLuongTon int check (SoLuongTon >=0),
	DVT nvarchar(200),
	HanSuDung date,
	GhiChu nvarchar (max)
	constraint HoaChat_MaNSX foreign key (MaNSX) references NhaSanXuat (MaNSX),
	constraint HoaChat_MaNCC foreign key (MaNCC) references NhaCungCap (MaNCC),
)

create table HoaChatKhoa
(
	MaHC int not null ,
	MaDV int not null,
	NgayNhap date,
	SoLuongTon int check(SoLuongTon>=0),
	constraint HoaChatKhoa_primarykey primary key (MaHC, MaDV),
	constraint HoaChatKhoa_MaHC foreign key (MaHC) references HoaChat (MaHC),
	constraint HoaChatKhoa_MaDV foreign key (MaDV) references DonVi (MaDV)
)

create table ThietBi
(
	MaTB int identity not null primary key,
	TenThietBi nvarchar(max),
	MaNSX int,
	MaNCC int,
	NgayNhap date check (NgayNhap<=getdate()),
	SoLuongNhap int check (SoLuongNhap >=0),
	SoLuongXuat int check (SoLuongXuat >=0),
	SoLuongTon int check (SoLuongTon >=0),
	DVT nvarchar(200),
	NgayBaoDuong date,
	TrangThai nvarchar(max) default N'Bình thường',
	constraint ThietBi_MaNSX foreign key (MaNSX) references NhaSanXuat (MaNSX),
	constraint ThietBi_MaNCC foreign key (MaNCC) references NhaCungCap (MaNCC),
)

create table LichSuSuDungThietBi
(
	MaLS int identity not null primary key,
	MaDV int not null,
	MaPL int not null,
	NgayNhan date,
	NgayTra date,
	MaTB int not null,
	constraint LSSDTB_MaTB foreign key (MaTB) references ThietBi (MaTB),
	constraint LSSDTB_MaDV foreign key (MaDV) references DonVi (MaDV),
	constraint LSSDTB_PhongLab_MaPL foreign key (MaPL) references PhongLab (MaPL)
)

create table ThongSoThietBi
(
	MaTS int identity not null primary key, 
	ThongSo nvarchar(max) not null,
	MaTB int not null,
	constraint ThongSoThietBi_MaTB foreign key (MaTB) references ThietBi (MaTB),
)

create table ThietBiKhoa
(
	MaTB int not null,
	MaDV int not null,
	MaPL int not null,
	NgayNhap date check (NgayNhap<=getdate()),
	SoLuongTon int check (SoLuongTon >=0 ),
	constraint ThietBiKhoa_pk primary key (MaTB, MaDV, MaPL),
	constraint ThietBiKhoa_MaTB foreign key (MaTB) references ThietBi (MaTB),
	constraint ThietBiKhoa_MaDV foreign key (MaDV) references DonVi (MaDV),
	constraint ThietBiKhoa_PhongLab_MaPL foreign key (MaPL) references PhongLab (MaPL)
)

create table DungCu
(
	MaDC int identity not null primary key,
	TenDC nvarchar(max),
	MaNSX int,
	MaNCC int,
	NgayNhap date check (NgayNhap<=getdate()),
	SoLuongNhap int check (SoLuongNhap >=0),
	SoLuongXuat int check (SoLuongXuat >=0),
	SoLuongTon int check (SoLuongTon >=0),
	DVT nvarchar(200),
	constraint DungCu_MaNSX foreign key (MaNSX) references NhaSanXuat (MaNSX),
	constraint DungCu_MaNCC foreign key (MaNCC) references NhaCungCap (MaNCC),
)

create table DungCuKhoa
(
	MaDC int not null,
	MaDV int not null,
	NgayNhap date check (NgayNhap<=getdate()),
	SoLuongTon int check (SoLuongTon >=0)
	constraint DungCuKhoa_pk primary key (MaDC, MaDV),
	constraint DungCuKhoa_MaDC foreign key (MaDC) references DungCu (MaDC),
	constraint DungCuKhoa_MaDV foreign key (MaDV) references DonVi (MaDV)
)

create table PhieuXuat
(
	MaPX int identity not null primary key,
	NgayLap date default getdate() check (NgayLap <= getdate()),
	NVLap int not null,
	NVDuyet int,
	MaDV int not null,
	TrangThai nvarchar(200) default N'Đang chờ duyệt',
	constraint PhieuXuat_MaNVLap foreign key (NVduyet) references NhanVien (MaNV),
	constraint PhieuXuat_MaNVDuyet foreign key (NVLap) references NhanVien (MaNV),
	constraint PhieuXuat_MaDV foreign key (MaDV) references DonVi (MaDV)
)

create table ChiTietPhieuXuat_HoaChat
(
	MaPX int not null,
	MaHC int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuXuat_MaPX foreign key (MaPX) references PhieuXuat (MaPX),
	constraint ChiTietPhieuXuat_MaHC foreign key (MaHC) references HoaChat (MaHC),
	constraint ChiTietPhieuXuat_pk primary key (MaPX, MaHC)
)

create table ChiTietPhieuXuat_ThietBi
(
	MaPX int not null,
	MaTB int not null,
	MaPL int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuXuat_pk_tb primary key (MaPX, MaTB, MaPL),
	constraint ChiTietPhieuXuat_MaPX_tb foreign key (MaPX) references PhieuXuat (MaPX),
	constraint ChiTietPhieuXuat_MaTB_tb foreign key (MaTB) references ThietBi (MaTB),
	constraint ChiTietPhieuXuat_MaPL_tb foreign key (MaPL) references PhongLab (MaPL)
)

create table ChiTietPhieuXuat_DungCu
(
	MaPX int not null,
	MaDC int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuXuat_MaPX_dc foreign key (MaPX) references PhieuXuat (MaPX),
	constraint ChiTietPhieuXuat_MaDC_dc foreign key (MaDC) references DungCu (MaDC),
	constraint ChiTietPhieuXuat_pk_dc primary key (MaPX, MaDC)
)

create table PhieuNhap
(
	MaPN int identity not null primary key,
	NgayLap date default getdate() check (NgayLap <= getdate()),
	MaNV int not null,
	TrangThai nvarchar(200) default N'Đang xác nhận',
	constraint PhieuNhap_MaNV foreign key (MaNV) references NhanVien (MaNV),
)


create table ChiTietPhieuNhap_HoaChat
(
	MaPN int not null,
	MaHC int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuNhap_MaPN_hc foreign key (MaPN) references PhieuNhap (MaPN),
	constraint ChiTietPhieuNhap_MaHC_hc foreign key (MaHC) references HoaChat (MaHC),
	constraint ChiTietPhieuNhap_pk_hc primary key (MaPN, MaHC)
)

create table ChiTietPhieuNhap_ThietBi
(
	MaPN int not null,
	MaTB int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuNhap_MaPN_tb foreign key (MaPN) references PhieuNhap (MaPN),
	constraint ChiTietPhieuNhap_MaTB_tb foreign key (MaTB) references ThietBi (MaTB),
	constraint ChiTietPhieuNhap_pk_tb primary key (MaPN, MaTB)
)

create table ChiTietPhieuNhap_DungCu
(
	MaPN int not null,
	MaDC int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuNhap_MaPN_dc foreign key (MaPN) references PhieuNhap (MaPN),
	constraint ChiTietPhieuNhap_MaDC_dc foreign key (MaDC) references DungCu (MaDC),
	constraint ChiTietPhieuNhap_pk_dc primary key (MaPN, MaDC)
)

--========================================================KHOA========================================================--

--create table PhieuNhapKhoa
--(
--	MaPNK int identity not null primary key,
--	NgayLap date default getdate() check (NgayLap <= getdate()),
--	MaNV int not null,
--	TrangThai nvarchar(max) default N'Đang chờ duyệt',
--	constraint PhieuNhapKhoa_MaNV foreign key (MaNV) references NhanVien (MaNV)
--)

--create table ChiTietPhieuNhapKhoa_HoaChat
--(
--	MaPNK int not null,
--	MaHC int not null,
--	SoLuong int check (SoLuong >=0),
--	constraint ChiTietPhieuNhapKhoa_MaPNK_hc foreign key (MaPNK) references PhieuNhapKhoa (MaPNK),
--	constraint ChiTietPhieuNhapKhoa_MaHC_hc foreign key (MaHC) references HoaChat (MaHC),
--	constraint ChiTietPhieuNhapKhoa_pk_hc primary key (MaPNK, MaHC)
--)

--create table ChiTietPhieuNhapKhoa_ThietBi
--(
--	MaPNK int not null,
--	MaTB int not null,
--	SoLuong int check (SoLuong >=0),
--	constraint ChiTietPhieuNhapKhoa_MaPNK_tb foreign key (MaPNK) references PhieuNhapKhoa (MaPNK),
--	constraint ChiTietPhieuNhapKhoa_MaTB_tb foreign key (MaTB) references ThietBi (MaTB),
--	constraint ChiTietPhieuNhapKhoa_pk_tb primary key (MaPNK, MaTB)
--)

--create table ChiTietPhieuNhapKhoa_DungCu
--(
--	MaPNK int not null,
--	MaDC int not null,
--	SoLuong int check (SoLuong >=0),
--	constraint ChiTietPhieuNhapKhoa_MaPNK_dc foreign key (MaPNK) references PhieuNhapKhoa (MaPNK),
--	constraint ChiTietPhieuNhapKhoa_MaDC_dc foreign key (MaDC) references DungCu (MaDC),
--	constraint ChiTietPhieuNhapKhoa_pk_dc primary key (MaPNK, MaDC)
--)

create table PhieuXuatKhoa 
(
	MaPXK int identity not null primary key,
	NgayLap date default getdate() check (NgayLap <= getdate()),
	MaNV int not null,
	TrangThai nvarchar(max) default N'Đang xác nhận',
	MaDV int not null,
	constraint PhieuXuatKhoa_MaNV foreign key (MaNV) references NhanVien (MaNV),
	constraint PhieuXuatKhoa_MaDV foreign key (MaDV) references DonVi (MaDV)
)


create table ChiTietPhieuXuatKhoa_HoaChat
(
	MaPXK int not null,
	MaHC int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuXuatKhoa_MaPXK_hc foreign key (MaPXK) references PhieuXuatKhoa (MaPXK),
	constraint ChiTietPhieuXuatKhoa_MaHC_hc foreign key (MaHC) references HoaChat (MaHC),
	constraint ChiTietPhieuXuatKhoa_pk_hc primary key (MaPXK, MaHC)
)

create table ChiTietPhieuXuatKhoa_ThietBi
(
	MaPXK int not null,
	MaTB int not null,
	MaPL int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuXuatKhoa_MaPXK_tb foreign key (MaPXK) references PhieuXuatKhoa (MaPXK),
	constraint ChiTietPhieuXuatKhoa_MaTB_tb foreign key (MaTB) references ThietBi (MaTB),
	constraint ChiTietPhieuXuatKhoa_MaPL_pl foreign key (MaPL) references PhongLab (MaPL),
	constraint ChiTietPhieuXuatKhoa_pk_tb primary key (MaPXK, MaTB, MaPL)
)

create table ChiTietPhieuXuatKhoa_DungCu
(
	MaPXK int not null,
	MaDC int not null,
	SoLuong int check (SoLuong >=0),
	constraint ChiTietPhieuXuatKhoa_MaPXK_dc foreign key (MaPXK) references PhieuXuatKhoa (MaPXK),
	constraint ChiTietPhieuXuatKhoa_MaDC_dc foreign key (MaDC) references DungCu (MaDC),
	constraint ChiTietPhieuXuatKhoa_pk_dc primary key (MaPXK, MaDC)
)

create table LichSuHoatDong
(
	MaLSHD int identity not null primary key,
	MaNV int not null,
	TrangThai nvarchar(max),
	ThoiGian date default getdate(),
	constraint LSHD_MaNV foreign key (MaNV) references NhanVien (MaNV)
)


set dateformat dmy

insert into DonVi values
(N'Trung Tâm Thí Nghiệm Thực Hành'),
(N'Khoa Công Nghệ Hóa Học'),
(N'Khoa Công Nghệ Sinh Học')

insert into ChucVu values
(N'Giám đốc'),
(N'Trưởng khoa'),
(N'Nhân viên')

Insert PhongLab values
(N'Phòng Đo Lường Thử Nghiệm',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Xét nghiệm, Chẩn đoán hình ảnh, Thăm dò chức năng',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Thử Nghiệm Hóa',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Thử Nghiệm NDT Vật Liệu',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Thử Nghiệm Môi Trường',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Kiểm Tra Chất Lượng Sản Phẩm',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Thử Nghiệm Nông Nghiệp',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Phân Tích Chất Lượng Thực Phẩm và Dinh Dưỡng Thủy Sản',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Kỹ Thuật An Toàn',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Đo Lường và Hiệu Chuẩn',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Kiểm Nghiệm',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Quan trắc - Phân tích',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM'),
(N'Phòng Thí Nghiệm Casumina',N'93 Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, TP. HCM')

Insert NhaSanXuat values 
(N'SKC','01-724-941-9701','skcorder@skcinc.com',N'863 Valley View Road, Eighty Four, PA 15330, U.S.A.'),
(N'COLE-PARMER','800-323-4340','sales@coleparmer.com',N'625 Bunker Ct, Vernon Hills, IL 60061, Hoa Kỳ'),
(N'LD-DIDACTIC','2233604-0','info@ld-didactic.de',N'LD DIDACTIC, GmbH Leyboldstraße 1, D–50354 Huerth, Germany'),
(N'SH Scientific','448665172','samheung@samheung21.com',N'92, Jangukjin-ro, Yeondong-myeon, Sejong, Korea'),
(N'Công Ty Cổ Phần DR.Americo Group','0907336201','sale@dramericofactory.com',N'50 Trần Khắc Chân, Phường Tân Định, Quận 1, TP.HCM'),
(N'Công Ty TNHH Biolabs Việt Nam','02438716918' ,'sales@thietbilabs.com',N'VP 202, Rice City Sông Hồng, Lô đất A1- 5/NO1, Phường Thượng Thanh, Quận Long Biên, Thành phố Hà Nội.'),
(N'Công TY BCE VietNam','0435690878','infors@bcevietnam.com.vn',N'Tầng 10, tòa nhà Licogi 13, số 164 Khuất Duy Tiến, Quận Thanh Xuân, Hà Nội'),
(N'Công Ty TNHH Hamesco Việt Nam','02466867486',' info@hamesco.com',N'Số 25 liền kề 6B, làng Việt kiều châu Âu, Mỗ Lao, Hà Đông, Hà Nội'),
(N'Công ty Cổ phần Thiết bị SISC Việt Nam','0437472258','info@sisc.com.vn',N'D11/D6 đường Trần Thái Tông – Q.Cầu Giấy – Hà Nội'),
(N'Công Ty TNHH Xuất Nhập Khẩu Đức Tường','0854319277',' info@tegent.com.vn',N'71 đường số 6 KDC Trung Sơn, Bình Hưng, H. Bình Chánh'),
(N'Công Ty CP Hóa chất Thiết bị PTN và Công Nghệ Labotech','0437832672',' labotech@hn.vnn.vn',N'Số 13 Lô 1B, Trung Yên 7, Trung Hoà, Cầu Giấy, Hà Nội'),
(N'Công Ty Cổ phần Tư vấn Công nghệ và Thiết bị Phan Lê','0462811208','info@phanleco.com',N'Phòng 207, nhà 24T2, khu Đô thị Trung Hòa-Nhân chính, Cầu Giấy, Hà Nội'),
(N'Công Ty CP Phân phối và Thương hiệu Thành An','0436463492','info@thanhantd.com',N'Số 32 ngõ 126/30, phố Vĩnh Hưng, P304 K11, KĐT Việt Hưng, Long Biên, Hà Nội'),
(N'Công Ty TNHH Thiết bị Vật Tư Khoa học kỹ thuật Việt Khoa','0838625215','vkscientificvn@hcm.fpt.vn',N'P.3.7, 76-78 Bạch Đằng,Tp. Đà Nẵng'),
(N'Công ty TNHH Thiết Bị Khoa học và Kỹ thuật Hóa Sinh','0862905308',' info@biotechem.com.vn',N'180-182 (Tầng 6, Phòng 601) Toà Nhà Vina Giầy Lý Chính Thắng, P. 9, Q. 3, TP.HCM'),
(N'Công ty TNHH Máy & Thiết Bị Công Nghiệp Thanh Bình Minh','0833620333' ,'thanhbinhminh@gmail.com',N'30 Đường Số 4, Phường 10, Quận Tân Bình, TP Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH SECOVINA','0835594432','secovina@secovina.vn',N'221/18 Vườn Lài, P. Phú Thọ Hòa, Q. Tân Phú, TP. HCM'),
(N'Công ty TNHH TM DV KT T.S.T','0838418502','thile@tstvn.com',N'372 Lê Quang Định, P. 11, Q. Bình Thạnh,Tp. Hồ Chí Minh (TPHCM)'),
(N'Công Ty TNHH YUIN','0310904100583','yuin@vnn.vn',N'Khu Quán đá, Thôn Đồng lý, Xã Mỹ đồng, Huyện Thuỷ Nguyên,Tp. Hải Phòng')

Insert NhaCungCap values
(N'Công Ty TNHH Thương Mại Ngân Châu Lab','02866862449','sales01nclab@gmail.com',N'65/13 Phan Sào Nam, phường 11, quận Tân Bình, Hồ Chí Minh, Việt Nam'),
(N'Công Ty TNHH Biolabs Việt Nam','02438716918' ,'sales@thietbilabs.com',N'VP 202, Rice City Sông Hồng, Lô đất A1- 5/NO1, Phường Thượng Thanh, Quận Long Biên, Thành phố Hà Nội.'),
(N'Công ty TNHH Thiết bị Khoa học Việt Anh','02437831852' ,'info@vietanhco.com.vn',N'Lô 3A, Số 2, Khu đô thị Nam Trung Yên, Cầu Giấy, Hà Nội 10000'),
(N'Công ty Hóa chất Nam Quang','0903925576' ,'trung@naquaco.com',N'553/19A Nguyễn Kiệm, Q.Phú Nhuận TPHCM (TPHCM)'),
(N'Công ty TNHH Thương Mại Dịch Vụ Kỹ Thuật Châu Hoàng Long','0935123385','sales@chauhoanglong.com',N'119/20 Nguyễn Văn Lượng, Khu Phố 9, Phường 17, Quận Gò Vấp, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Thương Mại YourTech', '0903344140' ,'director@yourtech.com',N'L5 - 36 OT05 - Tòa Nhà Landmark 5, Vinhomes Central Park Tại 720A Điện Biên Phủ, Phường 22, Q. Bình Thạnh, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Máy & Thiết Bị Công Nghiệp Thanh Bình Minh','0833620333' ,'thanhbinhminh@gmail.com',N'30 Đường Số 4, Phường 10, Quận Tân Bình, TP Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH MTV Trang Thiết Bị Trường Học Thành Phát ','0903956873','thanhphat.co@gmail.com',N'81/1A Đường XTT 4-3, Ấp 4, X.Xuân Thới Thượng, H.Hóc Môn, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Khoa Học Kỹ Thuật TPS ','0389215668' ,'info@hoachatthietbi.com',N'A0901, tòa nhà Carina Plaza, số 1790 Võ Văn Kiệt, Phường 16, Quận 8, Tp Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Thương Mại Dịch Vụ Kỹ Thuật Tiến Minh ','02837106697','huongle@tienminhvn.com',N'73/7 Đường Xuân Thới 3, Ấp Xuân Thới Đông 2, X. Xuân Thới Đông, H. Hóc Môn, TP. Hồ Chí Minh (TP.HCM)'),
(N'Công ty TNHH Nguyên Anh ','02838421850' ,'info@nguyenanhvn.com',N'8/6 - 8/8 Thích Minh Nguyệt, Phường 2, Q. Tân Bình, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Quốc Tế Cát Dương ','02854273968','catduong@catduong.com',N' 27/8S Phan Huy Ích, Phường 12, Quận Gò Vấp, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty Cổ Phần Công Nghệ Hiển Long ', '0918509782','info@hiltekvn.com',N'B40 KDC Kim Sơn, Nguyễn Hữu Thọ, Phường Tân Phong, Quận 7, TP. Hồ Chí Minh (TPHCM)'),
(N'Trung Tâm Kỹ Thuật Tiêu Chuẩn Đo Lường Chất Lượng 3 ','0988571588','nt-thanhhai@quatest3.com.vn',N'49 Pasteur, Quận 1, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty Cổ Phần Đầu Tư Thương Mại Dịch Vụ Tin Cậy ','0903908671','tincaygroup@gmail.com',N' Số 4, Đường 3, KĐT Vạn Phúc, P. Hiệp Bình Phước, Q. Thủ Đức,TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Điện Máy Ngọc Ân ','02839716497','anta318@yahoo.com',N'753 Lý Thường Kiệt, P. 11, Q. Tân Bình, Tp. Hồ Chí Minh (TPHCM)'),
(N'Công ty Cổ Phần Thiết Bị Thi Việt','0903728381','thiviet@thiviet.com',N'38/5A Trần Khắc Chân, Tân Định, Quận 1, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Thiết Bị Khoa Học Kỹ Thuật Mỹ Thành ','02838646051','mtse@mythanh.com',N'445 Tô Hiến Thành , Phường 14 , Quận 10, TP. Hồ Chí Minh (TPHCM)'),
(N'Công ty TNHH Khoa Học Và Kỹ Thuật RECO ','0903166704','info@reecotech.com.vn',N' Phòng 109, Nhà A, Khu Công Nghệ Phần Mềm, Đường Nội Bộ Đại H, Phường Linh Trung, Quận Thủ, TP. Hồ Chí Minh (TPHCM)')

Insert NhanVien values
(N'Trần Công Bằng',N'Nam','25/10/1999','0910251035','TPHCM','bang123','123',2,2),
(N'Trần Thị Như',N'Nữ','06/09/2000','0953681039','TPHCM','nhuu','123',2,3),
(N'Nguyễn Văn Trung',N'Nam','25/08/1998','0911584388',N'Hà Nội','trungg','123',2,3),
(N'Cao Văn Khang',N'Nam','30/10/1997','0258468958',N'Đà Nẵng','khangg','123',2,3),
(N'Nguyễn Bảo Trang',N'Nữ','05/08/2001','0358469852',N'Quảng Trị','trangg','123',2,3),
(N'Nguyễn Thành Văn',N'Nam','19/07/2001','0383633081',N'Long An','admin','123',1,1),
(N'Lê Văn Nhân',N'Nam','30/10/1997','0258468958',N'Đà Nẵng','khanggg','123',3,2),
(N'Trần Thanh Sang',N'Nam','30/10/1997','0258468521',N'Quảng Nam','sangg','123',3,3),
(N'Nguyễn Thành Danh',N'Nam','25/08/2000','0358946851',N'Bình Định','danhh','123',3,3),
(N'Hồ Văn Tùng',N'Nam','10/10/1997','0158425639',N'TPHCM','tungg','123',3,3),
(N'Cao Viết Tài',N'Nam','03/08/2000','0351245684',N'Phú Yên','taii','123',3,3),
(N'Lý Thanh Nhã',N'Nam','31/01/1997','0325684215',N'Hà Tiên','nhaa','123',3,3),
(N'Nguyễn Thị Anh Thư',N'Nữ','19/10/1997','0987456254',N'Tiền Giang','thuu','123',3,3),
(N'Trần Khánh Băng',N'Nữ','06/09/2000','0912365841',N'Cà Mau','bangg69','123',3,3),
(N'Hứa Hiền Vinh',N'Nam','24/01/2001','0905842462',N'TPHCM','vinhh','123',1,3),
(N'Nguyễn Quốc Trung',N'Nam','05/08/2001','0958341251',N'Biên Hòa','trung02','123',3,3),
(N'Lê Xuân Bắc',N'Nam','30/11/1997','0258468451',N'Huế','bacc','123',1,3),
(N'Lê Thị Hiền',N'Nữ','30/10/1998','0258468958',N'Hậu Giang','hienn','123',2,3),
(N'Nguyễn Bá Hân',N'Nam','24/10/1997','0254875461',N'Cần Thơ','hann','123',3,3),
(N'Lê Tấn Tài',N'Nam','30/12/1997','0312568450',N'An Giang','taii02','123',2,3),
(N'Nguyễn Thị Trang',N'Nữ','25/11/1995','0254875693',N'Điện Biên','trangg02','123',3,3),
(N'Phan Thị Nguyệt Cầm',N'Nữ','10/10/1997','0584754510',N'TPHCM','camm','123',2,3),
(N'Huỳnh Nhã Như',N'Nữ','31/12/2000','0258461254',N'Bình Phước','nhuuu','123',3,3),
(N'Trần Thị Thanh Tuyền',N'Nữ','24/05/1997','0684584512',N'Bình Dương','tuyennn','123',3,3),
(N'Võ Hồng Nam',N'Nam','08/09/1998','0684594512',N'Hà Nội','namm','123',1,3),
(N'Lý Thanh Tuyền',N'Nữ','02/01/1997','0389456841',N'Hậu Giang','tuyenn','123',2,3),
(N'Lê Văn Lộc',N'Nam','30/07/1997','0684958745',N'TPHCM','locc','123',3,3),
(N'Lê Viết Cát Tường',N'Nữ','20/08/1997','0358497562',N'Ninh Thuận','tuongg','123',1,3),
(N'Nguyễn Văn Quý',N'Nam','30/09/2000','0359845621',N'Bình Thuận','quyy','123',3,3),
(N'Lê Thanh Nhân',N'Nam','10/10/1997','0358944562',N'TPHCM','nhannn','123',2,3),
(N'Võ Hùng Thuận',N'Nam','30/06/1997','0689545621',N'Bình Dương','thuann','123',2,3),
(N'Nguyễn Thị Mộng',N'Nữ','17/10/2000','09092548456',N'TPHCM','mongg','123',2,3),
(N'Nguyễn Thị Kiều Nga',N'Nữ','16/02/2000','0909845682',N'Cần Thơ','ngaa','123',1,3),
(N'Lê Ánh Hồng',N'Nữ','28/04/1997','0458745625',N'TPHCM','hongg','123',3,3),
(N'Nguyễn Thị Trúc Ly',N'Nữ','30/10/2001','0588468542',N'TPHCM','lyy','123',1,3),
(N'Hạ Mây',N'Nữ','26/10/1993','0258468452',N'Sóc Trăng','mayy','123',2,3)

set dateformat dmy
insert HoaChat values
('Axit Nitric','HNO3',2,3,'27/09/2022',100,80,20,N'Lọ 500ml','27/03/2023',N'Axit mạnh'),
('Axit Sunfuric','H2SO4',5,3,'27/09/2022',100,60,40,N'Lọ 500ml','27/03/2023',N'Axit mạnh'),
('Axit Clohidric','HCl',2,3,'27/09/2022',100,80,20,N'Lọ 250ml','27/03/2023',N'Axit mạnh'),
('Axit Clonic','HClO3',4,3,'27/09/2022',100,80,20,N'Lọ 100ml','27/03/2023',N'Axit yếu'),
('Phenolphtalein','C20H14O4',9,7,'08/10/2022',100,80,20,N'Lọ 500ml','08/04/2023',N'Chất thử'),
('Sucrose(Saccazoza)','C12H22O11',9,7,'08/10/2022',100,80,20,N'Lọ 100ml','08/04/2023',N'Chất thủy phân thành glucozo và fructozo'),
('Ethylene glycol','C2H6O2',10,5,'11/09/2022',100,80,20,N'Lọ 250g','11/03/2023',N'Nguyên liệu sản xuất polyester'),
('Phenoxyethanol','C6H5OC2H4OH',8,6,'12/11/2022',100,90,10,N'Lọ 500ml','12/05/2023',N'Chất bảo quản'),
('Photpho','P',10,3,'27/09/2022',50,30,20,N'Lọ 500g','27/03/2023',N'Chất tạo ra lửa'),
('Butyl acetate','C6H12O2',9,7,'08/10/2022',50,20,30,N'Lọ 500ml','08/04/2023',N'Chất pha loãng hóa chất'),
('Amoni Nitrat','NH4NO3',7,6,'20/08/2022',80,30,50,N'Lọ 250g','20/02/2023',N'Chất sản xuất phân bón và thuốc nổ'),
(N'Bạc Nitrat','AgNO3',4,10,'20/09/2022',60,20,40,N'Lọ 250g','20/03/2023',N'Tan tốt trong nước'),
('Natri Hidroxit 99%','NaOH',2,3,'27/09/2022',80,50,30,N'Lọ 500ml','27/03/2023',N'Chất khử trùng, tẩy rửa'),
('Acetone','(CH3)2CO',6,5,'11/09/2022',30,10,200,N'Lọ 250ml','11/03/2023',N'Dễ cháy, dễ bay hơi'),
('Potassium Hydroxide 90%','KOH',2,3,'27/09/2022',60,30,30,N'Lọ 500g','27/03/2023',N'Có tính ăn mòn')

insert into HoaChatKhoa values
(1,2,'28/09/2022',10),
(3,2,'28/09/2022',5),
(5,2,'09/10/2022',7),
(4,2,'28/09/2022',10),
(15,2,'28/09/2022',15),
(8,2,'09/10/2022',6),
(7,2,'12/09/2022',17),
(8,3,'13/11/2022',10),
(9,2,'28/09/2022',9),
(9,3,'28/09/2022',10),
(10,3,'09/10/2022',9),
(11,3,'21/09/2022',9),
(2,3,'15/12/2021',10)

insert into ThietBi (TenThietBi, MaNSX, MaNCC, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT, NgayBaoDuong) values 
(N'Bàn thí nghiệm trung tâm',4,10,'21/12/2021',5,5,0,N'Cái','21/06/2023'),
(N'Tủ an toàn sinh học',4,10,'21/12/2021',5,5,0,N'Cái','21/06/2023'),
(N'Tủ chống cháy',4,5,'21/12/2021',5,5,0,N'Cái','21/06/2023'),
(N'Máy so màu',4,7,'21/01/2019',5,5,10,N'Cái','21/07/2013'),
(N'Máy phân tích dầu và béo',3,6,'17/01/2021',5,5,0,N'Cái','17/07/2023'),
(N'Máy phân tích độ ẩm',5,5,'21/10/2020',5,5,0,N'Cái','21/04/2023'),
(N'Máy phân tích đạm',4,7,'01/12/2020',5,5,0,N'Cái','01/06/2023'),
(N'Máy đo oxi',4,4,'21/12/2021',5,5,0,N'Cái','21/06/2023'),
(N'Bếp gia nhiệt',2,8,'11/10/2021',5,5,0,N'Cái','11/04/2023'),
(N'Kính hiển vi',1,7,'21/12/2021',5,5,0,N'Cái','21/06/2023')

insert into ThongSoThietBi values
(N'4200x1500x800(1500)mm DxRxC',1),
(N'Tỉ lệ khí hồi lưu/ xả: 70%/ 30 %',2),
(N'Tốc độ dòng khí tại cửa làm việc:  0.4 ~ 0.5 m/ giây',2),
(N'Kích thước: 1,2m',2),
(N'Chất liệu cửa trượt : Kính cường lực',2),
(N'Dung tích : 15 lít',3),
(N'Cửa đơn, 1 khay đỡ',3),
(N'Kích thước : 560 x 430 x430 CxRxD',3),
(N'Hệ thống quang học: 45°/0',4),
(N'Hệ thống quang phổ gồm 256 diode array',4),
(N'Phạm vi khe đo: 31.8mm/ 25.4mm',4),
(N'Bước sóng: 400 – 700nm',4),
(N'Độ phân giải bước sóng: 10nm',4),
(N'Nguồn sáng: Đèn Pulsed Xenon',4),
(N'Phân tích đồng thời cùng lúc 3 mẫu',5),
(N'Có bộ phận gia nhiệt làm ấm đến 37°C',5),
(N'Bộ nhớ bên trong lưu kết quả phân tích',5),
(N'Màn hình hiển thị cảm ứng',5),
(N'Có cổng USB để kết nối đến máy tính',5),
(N'Hoạt động bằng pin Lithium',5),
(N'Kích thước RxDxC: 15 x 22 x 8.3cm',5),
(N' Kích thước : 13 in (R) x 23 in (D) x 14.5 in (C) 33 cm (R) x 58.4 (D) x 36.8 cm (C))',6),
(N'Trọng lượng: 26kg',6),
(N'Khoảng đo độ ẩm/chất rắn: 0 tới 99.99% hoặc 0.01% độ phân giải',6),
(N'Khả năng cân : 50g',6),
(N'Màn hình cảm ứng HD LED điện dung thủy tinh màu đầy đủ (800 x 480)',6),
(N'Yêu cầu nguồn điện : 220/240V ± 10%, 50Hz, 10 Amps',6),
(N'Thang chưng cất đạm: 0.1 đến 225 mgN',7),
(N'Tỷ lệ thu hồi: > 99,5 %',7),
(N'Độ lập lại (RSD) : < 0.75%',7),
(N'Tốc độ chưng cất: 40mL/phút tại 230V',7),
(N'Nhiệt độ hoạt động: 5 đến 40°C, với độ ẩm 80%',7),
(N'Kích thước máy: 430 x 700 x 330mm',7),
(N'Trọng lượng: 30kg',7),
(N'Trọng lượng: 194g',8),
(N'Kích thước: 40 x 40 x 180mm',8),
(N'Lấy mẫu: 1 lần / giây',8),
(N'Độ phân giải: 0,1%',8),
(N'Độ chính xác: +/- 0,2%',8),
(N'Phạm vi đo lường: 0 - 30%',8),
(N'Kích thước (WxDxH) 104x800x53mm',9),
(N'Công suất gia nhiệt: 350W',9),
(N'Khối lượng máy: 2.8kg',9),
(N'Nguồn điện sử dụng: 220V/50Hz',9),
(N'Độ Phóng đại : 2.0x-270x [SZ61]*1',10),
(N'Tỷ lệ phóng : 6.7 (0.67x-4.5x) [SZ61]',10),
(N'Ống quan sát: Ba mắt',10),
(N'Lấy nét: Đứng',10),
(N'Kích thước: 194(W)x253(D)x368(H)mm',10),
(N'Trọng lượng: 3.5kg',10)

insert into ThietBiKhoa values
(1,2,1,'25/12/2021',1),
(2,3,5,'25/12/2021',1),
(1,3,1,'15/12/2021',10),
(3,2,6,'25/12/2021',1),
(3,3,2,'25/12/2021',1),
(4,3,3,'25/01/2019',1),
(5,2,5,'20/01/2021',1),
(6,3,10,'5/12/2021',1),
(7,2,9,'5/12/2021',1),
(8,2,8,'25/12/2021',1),
(8,3,7,'25/12/2021',1),
(9,2,9,'15/10/2021',1),
(10,3,1,'25/12/2021',1)

insert into DungCu values
(N'Cốc đốt thủy tinh',5,5,'12/12/2021',100,60,40,N'Cái'),
(N'Phễu thủy tinh',6,7,'12/01/2022',100,60,40,N'Cái'),
(N'Ống nghiệm thủy tinh',8,5,'12/12/2021',100,80,20,N'Cái'),
(N'Đèn cồn',9,6,'12/02/2022',50,30,200,N'Cái'),
(N'Vít kẹp',7,8,'10/02/2022',100,60,40,N'Cái'),
(N'Kẹp gắp',8,10,'12/02/2022',100,60,40,N'Cái'),
(N'Bình cầu đáy tròn',8,8,'20/07/2022',80,50,30,N'Cái'),
(N'Ống nhỏ giọt có chia độ',6,8,'27/06/2022',100,60,40,N'Cái'),
(N'Bình phun tia',8,6,'27/06/2022',50,40,10,N'Cái'),
(N'Bình tách lỏng',6,6,'10/09/2022',50,30,20,N'Cái'),
(N'Chổi rửa ống nghiệm',9,9,'10/08/2022',100,60,40,N'Cái'),
(N'Bình định mức',10,8,'12/10/2022',80,60,20,N'Cái')

insert into DungCuKhoa values
(1,2,'15/12/2021',10),
(1,3,'15/12/2021',10),
(2,2,'15/01/2022',5),
(2,3,'15/02/2022',8),
(3,2,'15/02/2022',7),
(3,3,'15/02/2022',5),
(4,2,'15/02/2021',10),
(5,2,'15/02/2022',15),
(5,3,'15/02/2022',15),
(6,2,'15/02/2021',10),
(6,3,'15/02/2021',5),
(7,2,'30/07/2022',8),
(8,2,'30/06/2022',9),
(8,3,'30/06/2022',6),
(9,2,'30/06/2022',8),
(9,3,'30/06/2022',7),
(10,2,'11/08/2022',6),
(11,2,'11/08/2022',7),
(12,2,'15/10/2022',10)

insert into PhieuXuat values  
('20/09/2022',1,6,2,N'Đã duyệt'),
('20/10/2022',2,15,2,N'Đã duyệt'),
('17/07/2022',3,17,2,N'Đã duyệt'),
('20/08/2022',4,25,2,N'Đã duyệt'),
('20/06/2022',5,25,3,N'Đã duyệt'),
('10/09/2022',5,28,3,N'Bị từ chối'),
('12/09/2022',5,33,3,N'Đã duyệt'),
('09/09/2022',3,33,2,N'Đã duyệt'),
('08/09/2022',2,15,3,N'Bị từ chối'),
('01/09/2022',1,6,2, N'Đã duyệt'),
('18/07/2022',2,null,3,N'Đang chờ duyệt'),
('20/05/2022',34,null,3,N'Đang chờ duyệt'),
('21/07/2022',30,null,3,N'Đang chờ duyệt'),
('06/09/2022',27,null,2,N'Đang chờ duyệt'),
('28/08/2022',23,null,2,N'Đang chờ duyệt')

insert into ChiTietPhieuXuat_HoaChat values
(1,1,20),
(2,2,30),
(3,4,50),
(4,5,20),
(5,3,30),
(6,7,25),
(7,6,30),
(8,10,30),
(9,8,25),
(10,9,25),
(11,12,15),
(12,14,25),
(13,15,26),
(14,13,30),
(15,11,20)

insert into ChiTietPhieuXuat_ThietBi values
(1,1,2,1),
(2,2,1,1),
(3,4,1,1),
(4,5,1,1),
(5,3,1,2),
(6,7,2,2),
(7,6,3,1),
(8,10,2,1),
(9,8,3,1),
(10,9,1,1),
(11,6,1,1),
(12,4,3,1),
(13,5,2,1),
(14,3,1,1),
(15,1,2,1)

insert into ChiTietPhieuXuat_DungCu values
(1,1,20),
(2,2,30),
(3,4,10),
(4,5,15),
(5,3,25),
(6,7,30),
(7,6,30),
(8,10,20),
(9,8,30),
(10,9,10),
(11,12,25),
(12,4,30),
(13,5,25),
(14,3,15),
(15,1,20)


insert into PhieuNhap (NgayLap, MaNV,TrangThai) values 
('01/05/2022',6,N'Đã xác nhận'),
('10/04/2022',17,N'Đang xác nhận'),
('01/04/2022',15,N'Đã xác nhận'),
('01/07/2022',25,N'Đang xác nhận'),
('12/03/2022',33,N'Đã xác nhận'),
('12/06/2022',28,N'Đã xác nhận'),
('18/05/2022',35,N'Đang xác nhận'),
('10/05/2022',33,N'Đang xác nhận'),
('17/03/2022',17,N'Đã xác nhận'),
('12/02/2022',15,N'Đang xác nhận'),
('19/07/2022',6,N'Đã xác nhận'),
('15/05/2022',6,N'Đang xác nhận'),
('12/06/2022',28,N'Đang xác nhận'),
('12/08/2022',25,N'Đã xác nhận'),
('19/03/2022',15,N'Đang xác nhận')

insert into ChiTietPhieuNhap_HoaChat values
(1,1,100),
(2,2,100),
(3,3,100),
(4,4,100),
(5,5,100),
(6,6,100),
(7,7,100),
(8,8,100),
(9,9,100),
(10,10,100),
(11,11,100),
(12,12,100),
(13,13,100),
(14,14,100),
(15,15,100)

insert into ChiTietPhieuNhap_ThietBi values
(1,1,5),
(2,2,5),
(3,3,5),
(4,5,5),
(5,4,5),
(6,6,5),
(7,7,5),
(8,8,50),
(9,9,5),
(10,10,5)
insert into ChiTietPhieuNhap_DungCu values
(1,1,30),
(2,2,20),
(3,3,20),
(4,5,30),
(5,4,25),
(6,6,35),
(7,7,50),
(8,8,40),
(9,9,30),
(10,10,35),
(11,11,50),
(12,12,50)

--insert into PhieuNhapKhoa (NgayLap, MaNV) values 
--('01/10/2022',3),
--('05/10/2022',11),
--('03/10/2022',8),
--('10/10/2022',1),
--('15/10/2022',14),
--('17/10/2022',16),
--('12/09/2022',20),
--('10/11/2022',21),
--('21/09/2022',18),
--('22/10/2022',9),
--('28/10/2022',2),
--('26/09/2022',7),
--('15/11/2022',11),
--('14/11/2022',13),
--('11/10/2022',22),
--('20/10/2022',26)

--insert into ChiTietPhieuNhapKhoa_HoaChat values
--(1,1,20),
--(2,2,30),
--(3,4,50),
--(4,5,20),
--(5,3,30),
--(6,7,25),
--(7,6,30),
--(8,10,30),
--(9,8,25),
--(10,9,25),
--(11,12,15),
--(12,14,25),
--(13,15,26),
--(14,13,30),
--(15,11,20)

--insert into ChiTietPhieuNhapKhoa_ThietBi values
--(1,1,2),
--(2,2,1),
--(3,4,1),
--(4,5,1),
--(5,3,1),
--(6,7,2),
--(7,6,3),
--(8,10,2),
--(9,8,3),
--(10,9,1),
--(11,2,1),
--(12,4,3),
--(13,5,2),
--(14,3,1),
--(15,10,2)

--insert into ChiTietPhieuNhapKhoa_DungCu values --Phiếu nhập của khoa là phiếu xuất của trung tâm thí nghiệm thực hành
--(1,1,20),
--(2,2,30),
--(3,4,10),
--(4,5,15),
--(5,3,25),
--(6,7,30),
--(7,6,30),
--(8,10,20),
--(9,8,30),
--(10,9,10),
--(11,12,25),
--(12,4,30),
--(13,5,25),
--(14,3,15),
--(15,11,20)

set dateformat dmy
insert into LichSuSuDungThietBi values
(2,1,'25/12/2021',null,1),
(3,5,'25/12/2021',null,2),
(2,6,'25/12/2021',null,3),
(3,3,'25/01/2019',null,4),
(2,5,'20/01/2021',null,5),
(3,10,'5/12/2021',null,6),
(2,9,'5/12/2021',null,7),
(2,8,'25/12/2021',null,8),
(2,9,'15/10/2021',null,9),
(3,1,'25/12/2021',null,10),
(3,2,'25/12/2021', null, 3),
(3,7,'25/12/2021', null, 8)

insert into PhieuXuatKhoa values  
('11/11/2022',13,N'Đang xác nhận',3),
('20/10/2022',10,N'Đã xuất',3),
('25/10/2022',5,N'Đang xác nhận',2),
('30/10/2022',8,N'Đã xuất',3),
('30/10/2022',4,N'Đã xuất',2),
('21/11/2022',6,N'Đang xác nhận',3),
('12/11/2022',2,N'Đang xác nhận',2),
('26/11/2022',11,N'Đang xác nhận',3),
('25/10/2022',18,N'Đã xuất',2),
('22/11/2022',16,N'Đã xuất',3),
('26/11/2022',26,N'Đang xác nhận',2),
('26/11/2022',19,N'Đã xuất',3),
('26/11/2022',12,N'Đã xuất',2),
('24/11/2022',10,N'Đang xác nhận',3),
('25/10/2022',14,N'Đang xác nhận',3),
('20/11/2022',22,N'Đang xác nhận',2)

insert into ChiTietPhieuXuatKhoa_HoaChat values
(1,2,10),
(2,5,20),
(3,3,15),
(4,4,10),
(5,7,15),
(6,6,20),
(7,8,10),
(8,10,20),
(9,9,10),
(10,15,5),
(11,11,10),
(12,12,15),
(13,14,12),
(14,1,17),
(15,13,6)

insert into ChiTietPhieuXuatKhoa_ThietBi values
(1,1,1,1), 
(2,2,5,1), 
(3,4,3,1),
(4,5,2,1),
(5,3,6,1),
(6,7,4,1),
(7,6,4,1),
(8,10,1,1),
(9,8,8,1),
(10,9,2,1),
(11,2,4,1),
(12,4,3,1),
(13,5,5,1),
(14,3,1,1),
(15,10,1,1)

insert into ChiTietPhieuXuatKhoa_DungCu values
(1,1,11),
(2,2,15),
(3,4,4),
(4,5,5),
(5,3,15),
(6,7,12),
(7,6,18),
(8,10,10),
(9,8,8),
(10,9,3),
(11,12,5),
(12,4,10),
(13,5,14),
(14,3,7),
(15,11,6)











select * from PhieuNhap where MaPN =11

select madv from NhanVien, PhieuNhap where NhanVien.MaNV=PhieuNhap.MaNV

update phieunhap set TrangThai = N'Đã xác nhận' where mapn>10

select * from ChiTietPhieuNhap_DungCu where MaPN = 11
select * from ChiTietPhieuNhap_ThietBi where MaPN = 11
select * from ChiTietPhieuNhap_HoaChat where MaPN = 11

select * from LichSuSuDungThietBi

--UPDATE DU LIEU

--update so luong xuat = tong so luong ton trong hoa chat khoa
update HoaChat set SoLuongXuat = (select sum(SoLuongTon) from HoaChatKhoa where HoaChat.MaHC = HoaChatKhoa.MaHC)
update HoaChat set SoLuongXuat = 0 where SoLuongXuat IS NULL

update DungCu set SoLuongXuat = (select sum(SoLuongTon) from DungCuKhoa where DungCu.MaDC = DungCuKhoa.MaDC)
update DungCu set SoLuongXuat = 0 where SoLuongXuat IS NULL

update ThietBi set SoLuongXuat = (select sum(SoLuongTon) from ThietBiKhoa where ThietBi.MaTB = ThietBiKhoa.MaTB)
update ThietBi set SoLuongXuat = 0 where SoLuongXuat IS NULL

--update so luong nhap = so luong xuat + so luong ton
update HoaChat set SoLuongNhap = (SoLuongXuat+SoLuongTon)
update DungCu set SoLuongNhap = (SoLuongXuat+SoLuongTon)
update ThietBi set SoLuongNhap = (SoLuongXuat+SoLuongTon)

--update thanh tien = so luong * don gia
--update ChiTietPhieuNhap_DungCu set ThanhTien = (SoLuong*DonGia)
--update ChiTietPhieuNhap_ThietBi set ThanhTien = (SoLuong*DonGia)
--update ChiTietPhieuNhap_HoaChat set ThanhTien = (SoLuong*DonGia)

--update tong tien = sum tong thanh tien
--update PhieuNhap set TongTien = ((select sum(thanhtien) from ChiTietPhieuNhap_DungCu where ChiTietPhieuNhap_DungCu.MaPN = PhieuNhap.MaPN and ThanhTien !=null)+(select sum(thanhtien) from ChiTietPhieuNhap_ThietBi where ChiTietPhieuNhap_ThietBi.MaPN = PhieuNhap.MaPN and ThanhTien !=null)+(select sum(thanhtien) from ChiTietPhieuNhap_HoaChat where ChiTietPhieuNhap_HoaChat.MaPN = PhieuNhap.MaPN and ThanhTien !=null))
--select TenDV from DonVi, PhieuNhap, NhanVien where DonVi.MaDV = NhanVien.MaDV and PhieuNhap.MaNV = NhanVien.MaNV

--update HoaChat set SoLuongTon = soluongton + (select soluong from ChiTietPhieuNhap_HoaChat where ChiTietPhieuNhap_HoaChat.MaHC = HoaChat.MaHC and MaPN = 11) where MaHC = (select mahc from ChiTietPhieuNhap_HoaChat where MaPN =11)

select * from PhieuXuat


