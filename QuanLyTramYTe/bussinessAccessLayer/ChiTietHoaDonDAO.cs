using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data;
using System.Data
    .SqlClient;

namespace bussinessAccessLayer
{
    public class ChiTietHoaDonDAO
    {
        dataAccess da;

        public ChiTietHoaDonDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }
        public DataSet getChiTietHoaDon(string MaHD)
        {
            return da.executeQueryDataSet("select * from f_showCTHD('"+MaHD+"')");
        }

        public bool ThemChiTietHoaDon(string MaHoaDon,string MaThuoc,int SoLuong,string CachDung,int MaDonVi)
        {
            return da.executeNonQuery("spThemChiTietHoaDon", CommandType.StoredProcedure,
                new SqlParameter("@MaHoaDon", MaHoaDon),
                new SqlParameter("@MaThuoc", MaThuoc),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@CachDung", CachDung),
                new SqlParameter("@MaDonVi", MaDonVi));
        }
        public bool SuaChiTietHoaDon(string MaHoaDon, string MaThuoc, int SoLuong, string CachDung, int MaDonVi)
        {
            return da.executeNonQuery("spCapNhatChiTietHoaDon", CommandType.StoredProcedure,
                new SqlParameter("@MaHoaDon", MaHoaDon),
                new SqlParameter("@MaThuoc", MaThuoc),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@CachDung", CachDung),
                new SqlParameter("@MaDonVi", MaDonVi));
        }
        public bool XoaChiTietHoaDon(string MaHoaDon, string MaThuoc)
        {
            return da.executeNonQuery("spXoaChiTietHoaDon", CommandType.StoredProcedure,
                new SqlParameter("@MaHoaDon", MaHoaDon),
                new SqlParameter("@MaThuoc", MaThuoc));
              
        }
        public DataSet ThuocTrong1HoaDon(string MaHD)
        {
            string sql = string.Format("select * from f_CacThuocTrong1HoaDon('{0}'", MaHD);
            return da.executeQueryDataSet(sql);
        }

    }//end class
}
