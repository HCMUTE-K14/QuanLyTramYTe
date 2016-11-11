using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
namespace bussinessAccessLayer
{
    public class HoaDonDAO
    {
        dataAccess da;
        public HoaDonDAO(string uid, string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }
        public DataSet getHoaDon()
        {
            return da.executeQueryDataSet("select * from f_showHD()");
        }
        public DataSet getHoaDon(DateTime NgayLapHD)
        {
            return da.executeQueryDataSet(string.Format("select * from f_showHoaDonTheoNgay('{0}')", NgayLapHD));
        }
        public bool ThemHoaDon(float SoTien, string MaKhachHang, bool CoBaoHiem, string MaNV)
        {
            return da.executeNonQuery("spThemBenhNhan", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@SoTien", SoTien),
                 new System.Data.SqlClient.SqlParameter("@MaKhachHang", MaKhachHang),
                  new System.Data.SqlClient.SqlParameter("@CoBaoHiem", CoBaoHiem),
                   new System.Data.SqlClient.SqlParameter("@MaNV", MaNV)
                   
                );
        }
        //public bool SuaHoaDon(string MaKhachHang, string TenKhachHang, string QueQuan, string CMND, string NgaySinh, string SDT)
        //{
        //    return da.executeNonQuery("spCapNhatBenhNhan", CommandType.StoredProcedure,
        //         new System.Data.SqlClient.SqlParameter("@MaKH", MaKhachHang),
        //        new System.Data.SqlClient.SqlParameter("@TenKhachHang", TenKhachHang),
        //         new System.Data.SqlClient.SqlParameter("@QueQuan", QueQuan),
        //          new System.Data.SqlClient.SqlParameter("@CMND", CMND),
        //           new System.Data.SqlClient.SqlParameter("@NgaySinh", NgaySinh),
        //            new System.Data.SqlClient.SqlParameter("@SDT", SDT)
        //        );
        //}
        public bool XoaHoaDon(string MaHoaDon)
        {
            return da.executeNonQuery("spXoaHoaDon", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@MaHoaDon", MaHoaDon));
        }
        public double TongTienHoaDon(string MaHoaDon)
        {
            DataTable dt = new DataTable();
            double result=0;

            dt=da.executeQueryDataSet(string.Format("select [dbo].[f_tongTienHoaDon]('{0}')", MaHoaDon)).Tables[0];

            result=Double.Parse(dt.Rows[0][0].ToString());

            return result;

        }
        public DataSet ThongKe(DateTime ngay1,DateTime ngay2)
        {
            return da.executeQueryDataSet(string.Format("select * from f_tinhDoanhThu('{0}','{1}')", ngay1, ngay2));
        }
    }
}
