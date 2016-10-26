/*Table Bệnh nhân*/
/*
- Chỉnh sửa Table: 
	+Bảng Bệnh nhân: sửa CMND, SDT về nvarchar(50)
	+Bảng Hoá Đơn: xoá 2 khoá ngoại trên column MaLichHen, MaKhachHang
-Trigger: thêm 2 trigger
	+Tg_ThemBN
	+Tg_XoaBN
-S.p:Thêm 3 sp
	+spThemBenhNhan
	+spCapNhatBenhNhan
	+spXoaBenhNhan
-Function:
	+f_ThongTinBenhNhan (return table)
	+f_TongTienBenhNhan (return float)
	+f_LichTaiKhamMoiNhat (return table)
*/
/*Tg_ThemBN*/
if(exists(select * From sysobjects where name='Tg_ThemBN' and type='TR'))
Drop trigger Tg_ThemBN
go
create trigger Tg_ThemBN on BenhNhan
for insert,update
as
begin
	declare @TenKhachHang nvarchar(50),@QuenQuan nvarchar(50),@CMND nvarchar(50),@NgaySinh date,@SDT nvarchar(50)

	select @TenKhachHang=i.TenKhachHang,@QuenQuan=i.QueQuan,@CMND=i.CMND,@NgaySinh=i.NgaySinh,@SDT=i.SDT
	from inserted i

	if(Len(@TenKhachHang)=0)
		begin
			print N'Tên Khách Hàng không được bỏ trống'
			rollback
			return;
		end

	if(Len(@CMND)!=0)
		begin
			if(Len(@CMND)<9 or Len(@CMND)>10)
				begin
					print N'CMND có độ dài 9-10 số'
					rollback
					return;
				end
		end

	if ((select count(*) from BenhNhan where CMND=@CMND))>1
		begin
			print @CMND
			print N'Đã tồn tại CMND'
			rollback
			return;
		end
	

	if(@NgaySinh>getdate())
		begin
			print N'Ngày sinh không hợp lệ'
			rollback
			return;
		end

	if(Len(@SDT)!=0)
		begin
			if(Len(@SDT)<6 or Len(@SDT)>11)
				begin
					print N'SDT có độ dài 6 hoặc 11 số'
					rollback
					return;
				end
		end
end
go
----
/*spThemBenhNhan*/
if(exists(select * From sysobjects where name='spThemBenhNhan' and type='P'))
Drop Proc spThemBenhNhan
go

create proc spThemBenhNhan
	@TenKhachHang nvarchar(50),
	@QueQuan nvarchar(50),
	@CMND nvarchar(50),
	@NgaySinh date,
	@SDT nvarchar(50)
as
begin
	
	declare @i int
	set @i=1;
	declare @MaKH int

	declare curMaKH
	cursor for select MaKH from BenhNhan
	open curMaKH
	fetch next from curMaKH
	into @MaKH

	while(@@FETCH_STATUS=0)
		begin
			if(@i=@MaKH)
				begin
					set @i=@i+1
					fetch next from curMaKH
					into @MaKH
					continue
				end;
			else 
			break
		end

	close curMaKH
	deallocate curMaKH

	insert into BenhNhan values(@i,@TenKhachHang,@QueQuan,@CMND,@NgaySinh,@SDT)
end
go
--
/*spCapNhatBenhNhan*/
if(exists(select * From sysobjects where name='spCapNhatBenhNhan' and type='P'))
Drop Proc spCapNhatBenhNhan
go
create proc spCapNhatBenhNhan
	@MaKH int,
	@TenKhachHang nvarchar(50),
	@QueQuan nvarchar(50),
	@CMND	nvarchar(50),
	@NgaySinh nvarchar(50),
	@SDT nvarchar(50)
as
begin

	if not exists(select * from BenhNhan where MaKH=@MaKH)
		begin
			print N'Không tồn tại Bệnh nhân với mã '+ cast(@MaKH as nvarchar(1))
			return;
		end

		if(Len(@TenKhachHang)=0 )
			begin
				print N'Tên Khách Hàng không được bỏ trống'
				return;
			end
		update BenhNhan
		set TenKhachHang=@TenKhachHang,
			QueQuan=@QueQuan,
			CMND=@CMND,
			NgaySinh=@NgaySinh,
			SDT=@SDT
		where BenhNhan.MaKH=@MaKH
end
go
--
/*Tg_XoaBN*/
if(exists(select * From sysobjects where name='Tg_XoaBN' and type='TR'))
Drop trigger Tg_XoaBN
go
create trigger Tg_XoaBN on BenhNhan
for delete
as
begin

	declare @MaKH nvarchar(50)

	select @MaKH=deleted.MaKH
	from deleted

	delete from LichTaiKham where LichTaiKham.MaLichHen in (select MaLichHen 
	from HoaDon where HoaDon.MaKhachHang=@MaKH)

	update HoaDon
	set MaKhachHang=null
	where HoaDon.MaKhachHang=@MaKH

end
go
--
/*spXoaBenhNhan*/
if(exists(select * From sysobjects where name='spXoaBenhNhan' and type='P'))
Drop Proc spXoaBenhNhan
go

create proc spXoaBenhNhan
	@MaKH int
as
begin
	delete from BenhNhan where BenhNhan.MaKH=@MaKH
end
--
go
/*func f_ThongTinBenhNhan*/
if(exists(select * From sysobjects where name='f_ThongTinBenhNhan' ))
Drop function f_ThongTinBenhNhan
go
create function f_ThongTinBenhNhan
(@MaKH int)
returns table
as
	return (select * from BenhNhan where BenhNhan.MaKH=@MaKH);
go

----
go
/*func f_TongTienBenhNhan*/
if(exists(select * From sysobjects where name='f_TongTienBenhNhan' ))
Drop function f_TongTienBenhNhan
go
create function f_TongTienBenhNhan(@MaKH int)
returns float
as
begin
	declare @total float
	select @total= sum(HoaDon.SoTien)
	from HoaDon
	where HoaDon.MaKhachHang=@MaKH
	group by MaKhachHang
	return @total
end
go
---
/*f_LichTaiKhamMoiNhat*/
if(exists(select * From sysobjects where name='f_LichTaiKhamMoiNhat' ))
Drop function f_LichTaiKhamMoiNhat
go

create function f_LichTaiKhamMoiNhat(@MaKH int)
returns @rtnTable Table(MaHoaDon int not null, NgayTaiKham date not null, GhiChu nvarchar(100) not null)
as
begin
	

		insert into @rtnTable 
		select ltk.MaHoaDon,ltk.NgayTaiKham,ltk.GhiChu
		from LichTaiKham ltk
		where ltk.MaHoaDon = (
										select TOP 1 MaHoaDon 
										from HoaDon 
										where HoaDon.MaKhachHang=@MaKH
										order by HoaDOn.MaHoaDon desc ) and DATEDIFF(day,NgayTaiKham,getdate())>0
	return;		
end

----
--select *
--from [dbo].[f_LichTaiKhamMoiNhat](1)
-----------------------------------------------------------------------------------
/*Table ChiTietHoaDon*/
/*
	Trigger:2
	Sp:3
	Function:1 (hàm trả về bảng)
*/
go
if(exists(select * From sysobjects where name='Tg_ThemCTHDon' and type='TR'))
Drop trigger Tg_ThemCTHDon
go
create trigger Tg_ThemCTHDon on ChiTietHoaDon
for insert,update
as
begin
	declare @SoLuong int,@CachDung nvarchar(50)

	select @SoLuong=SoLuong, @CachDung=CachDung
	from inserted 

	if(@SoLuong<0)
		begin
			print N'Số lượng < 0'
			rollback
			return
		end
	if(Len(@CachDung)=0)
		begin
			print N'Chưa có cách dùng'
			rollback
			return
		end
end
go
if(exists(select * From sysobjects where name='spThemChiTietHoaDon' and type='P'))
Drop proc spThemChiTietHoaDon
go

create proc spThemChiTietHoaDon
	@MaHoaDon int,
	@MaThuoc int,
	@SoLuong int,
	@CachDung nvarchar(50),
	@MaDonVi int
as
begin
	insert into ChiTietHoaDon values(@MaHoaDon,@MaThuoc,@SoLuong,@CachDung,@MaDonVi)
end
go

if(exists(select * From sysobjects where name='spCapNhatChiTietHoaDon' and type='P'))
Drop proc spCapNhatChiTietHoaDon
go

create proc spCapNhatChiTietHoaDon
	@MaHoaDon int,
	@MaThuoc int,
	@SoLuong int,
	@CachDung nvarchar(50),
	@MaDonVi int
as
begin
	update ChiTietHoaDon 
	set SoLuong=@SoLuong,CachDung=@CachDung,MaDonVi=@MaDonVi
	where MaHoaDon=@MaHoaDon and MaThuoc=@MaThuoc
end
go
if(exists(select * From sysobjects where name='spXoaChiTietHoaDon' and type='P'))
Drop proc spXoaChiTietHoaDon
go
create proc spXoaChiTietHoaDon
	@MaHoaDon int,
	@MaThuoc int
as
begin
	delete from ChiTietHoaDon where MaHoaDon=@MaHoaDon and @MaThuoc=@MaThuoc
end
go

if(exists(select * From sysobjects where name='f_CacThuocTrong1HoaDon'))
Drop function f_CacThuocTrong1HoaDon
go
create function f_CacThuocTrong1HoaDon(@MaHoaDon int)
returns @reTable table (TenThuoc nvarchar(50) not null,SoLuong int not null,TenDonVi nvarchar(50) not null,CachDung nvarchar(50))
as
begin

	insert into @reTable 
		select TenThuoc,SoLuong,DonViTinh.TenDVT,CachDung
		from ChiTietHoaDon,Thuoc,DonViTinh
		where ChiTietHoaDon.MaHoaDon=@MaHoaDon and ChiTietHoaDon.MaThuoc=Thuoc.MaThuoc and ChiTietHoaDon.MaDonVi=DonViTinh.MaDVT

	return;
end
go

--------------------------------------------------------------------------------------
/*Table ChiTietHopDongCC*/
/*
	FUnctioin
*/
if(exists(select * From sysobjects where name='f_TinhSoLuongLe'))
Drop function f_TinhSoLuongLe
go
create function f_TinhSoLuongLe(@MaHDCC int,@MaThuoc int)
returns int
as
begin
	declare @t int

	select @t=(SoLuong*SoLe)
	from ChiTietHopDongCC
	where MaHDCC=@MaHDCC and MaThuoc=@MaThuoc

	return @t
end

if(exists(select * From sysobjects where name='f_TinhSoLuongLe'))
Drop function f_TinhSoLuongLe
go
create function f_TinhSoLuongLe(@MaHDCC int,@MaThuoc int)
returns int
as
begin
	declare @t int

	select @t=(SoLuong*SoLe)
	from ChiTietHopDongCC
	where MaHDCC=@MaHDCC and MaThuoc=@MaThuoc

	return @t
end
if(exists(select * From sysobjects where name='f_LayHanSuDung'))
Drop function f_LayHanSuDung
go
create function f_LayHanSuDung(@MaHDCC int,@MaThuoc int)
returns datetime
as
begin
	return (select HanSuDung from ChiTietHopDongCC where MaHDCC=@MaHDCC and MaThuoc=@MaThuoc);
end

if(exists(select * From sysobjects where name='f_LayHanSuDung'))
Drop function f_LayHanSuDung
go
create function f_ThuocHetHanSuDung(@MaThuoc int)
returns table
as

	return (select Thuoc.MaThuoc,TenThuoc,HanSuDung
			from ChiTietHopDongCC, Thuoc
			where ChiTietHopDongCC.MaThuoc=@MaThuoc and getdate()>HanSuDung and Thuoc.MaThuoc=ChiTietHopDongCC.MaThuoc);





			/*
--table HoaDon
--Table HDCC
--table LichTaiKham
--table Loaithuoc
--Table NhanVien
--Table TaiKhoan
--Table Thuoc
 Trigger:
 -Tg_xoaTaiKham: xóa những bệnh nhân đã quá hạn tái khám 1 tháng
 -Tg_Lichtruc: thêm nhân viên vào bảng lịch trực.
 -
 -
 -
 Store procedue
 -sp_themLoaithuoc add them loai thuoc moi vao voi dieu kien thuoc 
 nay khong trung voi cac loai thuoc đã có trước đó.
 -sp_themNhanVien điều kiện nhân viên được thêm phải có trình độ trên trung cấp.
 -
 -
 -
 function:
 5 func trả về giá trị
 -f_tongHD tính tổng số hóa đơn trong 1 tháng
 -f_tongTaiKham tính số bệnh nhân sẽ tái khám trong ngày hiện tại
 -f_tongGTHD tính tổng giá trị hóa đơn của 1 bệnh nhân
 -
 -
 5 function trả về bảng
 -f_thuoc danh mục thuốc có trong 1 loại thuốc nào đó
 -f_taiKham danh sách những bệnh nhân có lịch tái khám trong tháng nào đó
 -f_lichTruc danh sách người trực trạm y tế trong 1 ngày nào đó và công việc của họ
 -
 -
*/

--Tg_ThemThuoc
-- 
if(exists(select * From sysobjects where name='Tg_xoaTaiKham' and type='TR'))
Drop trigger Tg_xoaTaiKham
go
create trigger Tg_xoaTaiKham on LichTaiKham
for delete, update
as
begin
declare @MaLichHen nvarchar(50), @NgayTaiKham date

	select @MaLichHen=deleted.MaLichHen
	from deleted

	delete from LichTaiKham where LichTaiKham.MaLichHen in (select MaLichHen 
															from LichTaiKham 
															where LichTaiKham.NgayTaiKham=@NgayTaiKham 
																	and @NgayTaiKham<GETDATE())

	print N'Đã xóa thành công'
end
go
--delete from LichTaiKham where LichTaiKham.MaLichHen=1

--Tg_LichTruc

if(exists( select * from sysobjects where name='Tg_LichTruc'and type='TR'))
drop trigger Tg_LichTruc
go
create Trigger Tg_LichTruc on LichTruc
for insert, update
as
begin
	declare @MaNV int, @NgayDiTruc Date, @congViecTruc nvarchar(50)
	--
	--begin
		select @MaNV=i.MaNV, @NgayDiTruc=i.NgayDiTruc, @congViecTruc=i.CongViecTruc
		from inserted i

		if(Len(@MaNV)=0)
			begin
				print N'Ten Nhan Vien khong duoc bo trong'
				rollback
				return;
			end
		if(Len(@NgayDiTruc)=getdate())
			begin
				print N'Ngay dang ki truc khong hop le'
				rollback
				return;
			end
		if(Len(@congViecTruc)=Null)
			begin
				print N'Co the dien them cong viec truc'
				rollback
				return;
			end
		--end
	end
go

--sp_themThuoc
if(exists(select * From sysobjects where name='sp_themThuoc' and type='P'))
drop proc sp_themThuoc
go

create proc sp_themThuoc
@MaThuoc int, @TenThuoc nvarchar(50), @MaLoaiThuoc int, @MoTa nvarchar(100), @tinhTrang nvarchar(50)
as
begin
	if(@MaThuoc<>(select @MaThuoc from Thuoc where thuoc.MaThuoc=@MaThuoc))
	begin
		insert into Thuoc values(@MaThuoc,@TenThuoc,@MaLoaiThuoc,@MoTa,@tinhTrang)
	end
end
go
--sp_themNhanVien
if (exists (select * from sysobjects where name='sp_themNhanVien' and type= 'p'))
drop proc sp_themNhanVien
go

create proc sp_themNhanVien
@MaNV int, @HoTen nvarchar(50), 
@ngaysinh date, @Quequan nvarchar(50), @trinhdo nvarchar(50),
@luong float, @chucvu nvarchar(50), @Phai nvarchar (3)
as
begin
	if(@trinhdo='Dai hoc')
	begin
		insert into NhanVien values (@MaNV,@HoTen,@ngaysinh,@Quequan,@trinhdo,@luong,
									@chucvu,@Phai)
		return;
	end
end
go

--f_tongHD
if(exists(select * from sysobjects where name='f_tongHD'))
drop function f_tongHD
go

create function f_tongHD (@MaHoaDon int)
returns int
as
begin
	declare @t int

	select @t=sum(@MaHoaDon)
	from HoaDon
	where HoaDon.MaHoaDon=@MaHoaDon

	return @t
end

--f_tongTaiKham

if(exists(select * from sysobjects where name='f_tongTaiKham'))
drop function f_tongTaiKham
go

create function f_tongTaiKham (@NgayTaiKham date)
returns int
as
begin
	declare @t int
	select @t=sum(MaLichHen)
	from LichTaiKham
	where @NgayTaiKham = GETDATE()

	return @t;
end

--f_tongGTHD
if(exists(select * from sysobjects where name='f_tongGTHD'))
drop function f_tongGTHD
go

create function f_tongGTHD (@MaHoaDon int)
returns float
as
begin
	declare @gt float
	select @gt=sum(@MaHoaDon)
	from HoaDon
	return @gt
end

--f_thuoc

if(exists(select * from sysobjects where name='f_thuoc'))
drop function f_thuoc
go

create function f_thuoc (@MaLoaiThuoc int)
returns table
as
	return (select *
			from Thuoc
			where MaLoaiThuoc=@MaLoaiThuoc)

--f_taiKham

if(exists (select * from sysobjects where name ='f_taiKham'))
drop function f_taiKham
go

create function f_taiKham (@thang date)
returns table
as
	return ( select BenhNhan.TenKhachHang, BenhNhan.MaKH, HoaDon.CoBaoHiem
		from BenhNhan, LichTaiKham, HoaDon
		where BenhNhan.MaKH=HoaDon.MaKhachHang 
		and HoaDon.MaLichHen=LichTaiKham.MaLichHen and LichTaiKham.NgayTaiKham= @thang)

--f_LichTruc

if(exists (select * from sysobjects where name ='f_LichTruc'))
drop function f_LichTruc
go

create function f_LichTruc (@ngay date)
returns table
as
 return( select NhanVien.MaNV,NhanVien.HoTen
			from LichTruc,NhanVien
			where @ngay=GETDATE() and NhanVien.MaNV=LichTruc.MaNV)