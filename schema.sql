USE [[DBMS]]Tramyte_Demo]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaKH] [int] NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[QueQuan] [nvarchar](50) NULL,
	[CMND] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [int] NOT NULL,
	[MaThuoc] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[CachDung] [nvarchar](50) NULL,
	[MaDonVi] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHopDongCC]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHopDongCC](
	[MaHDCC] [int] NOT NULL,
	[MaThuoc] [int] NOT NULL,
	[MaDVT_goc] [int] NULL,
	[SoLuong] [int] NULL,
	[SoLe] [int] NULL,
	[MaDonViLe] [int] NULL,
	[SoLuongLe] [int] NULL,
	[NgaySanXuat] [datetime] NULL,
	[HanSuDung] [datetime] NULL,
 CONSTRAINT [PK_ChiTietHopDongCC] PRIMARY KEY CLUSTERED 
(
	[MaHDCC] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietThuoc]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietThuoc](
	[MaThuoc] [int] NOT NULL,
	[GiaBanLe] [float] NULL,
	[MaDVT_le] [int] NULL,
 CONSTRAINT [PK_ChiTietThuoc] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[MaDVT] [int] NOT NULL,
	[TenDVT] [nvarchar](50) NULL,
 CONSTRAINT [PK_DonViTinh] PRIMARY KEY CLUSTERED 
(
	[MaDVT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] NOT NULL,
	[SoTien] [float] NULL,
	[MaLichHen] [int] NULL,
	[MaKhachHang] [int] NULL,
	[CoBaoHiem] [bit] NULL,
	[MaNV] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HopDongCC]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongCC](
	[MaHDCC] [int] NOT NULL,
	[SoTien] [nchar](10) NULL,
	[NgayLap] [date] NULL,
 CONSTRAINT [PK_HopDongCC] PRIMARY KEY CLUSTERED 
(
	[MaHDCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichTaiKham]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichTaiKham](
	[MaLichHen] [int] NOT NULL,
	[MaHoaDon] [int] NULL,
	[NgayTaiKham] [date] NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_LichTaiKham] PRIMARY KEY CLUSTERED 
(
	[MaLichHen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichTruc]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichTruc](
	[MaNV] [int] NOT NULL,
	[NgayDiTruc] [date] NOT NULL,
	[CongViecTruc] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[NgayDiTruc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiThuoc]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThuoc](
	[MaLoaiThuoc] [int] NOT NULL,
	[TenLoaiThuoc] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiThuoc] PRIMARY KEY CLUSTERED 
(
	[MaLoaiThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](50) NULL,
	[TrinhDo] [nvarchar](50) NULL,
	[Luong] [float] NULL,
	[ChucVu] [nvarchar](50) NULL,
	[Phai] [nchar](3) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Username] [int] NOT NULL,
	[Pass] [nchar](10) NOT NULL,
	[MaNV] [int] NOT NULL,
 CONSTRAINT [PK_Tài khoản] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Thuoc]    Script Date: 10/26/2016 9:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thuoc](
	[MaThuoc] [int] NOT NULL,
	[TenThuoc] [nvarchar](50) NULL,
	[MaLoaiThuoc] [int] NULL,
	[MoTa] [nvarchar](100) NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_Thuoc] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Thuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaThuoc])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Thuoc]
GO
ALTER TABLE [dbo].[ChiTietHopDongCC]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHopDongCC_DonViTinh] FOREIGN KEY([MaDVT_goc])
REFERENCES [dbo].[DonViTinh] ([MaDVT])
GO
ALTER TABLE [dbo].[ChiTietHopDongCC] CHECK CONSTRAINT [FK_ChiTietHopDongCC_DonViTinh]
GO
ALTER TABLE [dbo].[ChiTietHopDongCC]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHopDongCC_DonViTinh1] FOREIGN KEY([MaDonViLe])
REFERENCES [dbo].[DonViTinh] ([MaDVT])
GO
ALTER TABLE [dbo].[ChiTietHopDongCC] CHECK CONSTRAINT [FK_ChiTietHopDongCC_DonViTinh1]
GO
ALTER TABLE [dbo].[ChiTietHopDongCC]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHopDongCC_HopDongCC] FOREIGN KEY([MaHDCC])
REFERENCES [dbo].[HopDongCC] ([MaHDCC])
GO
ALTER TABLE [dbo].[ChiTietHopDongCC] CHECK CONSTRAINT [FK_ChiTietHopDongCC_HopDongCC]
GO
ALTER TABLE [dbo].[ChiTietHopDongCC]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHopDongCC_Thuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaThuoc])
GO
ALTER TABLE [dbo].[ChiTietHopDongCC] CHECK CONSTRAINT [FK_ChiTietHopDongCC_Thuoc]
GO
ALTER TABLE [dbo].[ChiTietThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThuoc_DonViTinh1] FOREIGN KEY([MaDVT_le])
REFERENCES [dbo].[DonViTinh] ([MaDVT])
GO
ALTER TABLE [dbo].[ChiTietThuoc] CHECK CONSTRAINT [FK_ChiTietThuoc_DonViTinh1]
GO
ALTER TABLE [dbo].[ChiTietThuoc]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThuoc_Thuoc] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaThuoc])
GO
ALTER TABLE [dbo].[ChiTietThuoc] CHECK CONSTRAINT [FK_ChiTietThuoc_Thuoc]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[LichTruc]  WITH CHECK ADD  CONSTRAINT [FK_LichTruc_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[LichTruc] CHECK CONSTRAINT [FK_LichTruc_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD  CONSTRAINT [FK_Thuoc_LoaiThuoc] FOREIGN KEY([MaLoaiThuoc])
REFERENCES [dbo].[LoaiThuoc] ([MaLoaiThuoc])
GO
ALTER TABLE [dbo].[Thuoc] CHECK CONSTRAINT [FK_Thuoc_LoaiThuoc]
GO
