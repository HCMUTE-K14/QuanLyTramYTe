using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using dataAccessLayer;
namespace bussinessAccessLayer
{
    public class NhanVienDAO
    {
        dataAccess da;
        public NhanVienDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }

        public DataSet getNhanVien()
        {
            return da.executeQueryDataSet("select * from f_showNhanVien()");
        }
        public DataSet getNhanVien(string MaNV)
        {
            string sql = string.Format("select * from f_showNhanVienTheoMa('{0}')", MaNV);
            return da.executeQueryDataSet(sql);
        }
        public bool ThemNhanVien(string HoTen,DateTime NgaySinh,string QueQuan,string TrinhDo,double Luong,string ChucVu,string Phai)
        {
            return da.executeNonQuery("spThemNV", CommandType.StoredProcedure,
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@QueQuan", QueQuan),
                new SqlParameter("@TrinhDo", TrinhDo),
                new SqlParameter("@Luong", Luong),
                new SqlParameter("@ChucVu", ChucVu),
                new SqlParameter("@Phai", Phai));

        }
        public bool SuaNhanVien(string MaNV,string HoTen, DateTime NgaySinh, string QueQuan, string TrinhDo, double Luong, string ChucVu, string Phai)
        {
            return da.executeNonQuery("spCapNhatNhanVien", CommandType.StoredProcedure,
                new SqlParameter("@MaNV",MaNV),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@QueQuan", QueQuan),
                new SqlParameter("@TrinhDo", TrinhDo),
                new SqlParameter("@Luong", Luong),
                new SqlParameter("@ChucVu", ChucVu),
                new SqlParameter("@Phai", Phai));

        }

        public bool XoaNhanVien(string MaNV)
        {
            return da.executeNonQuery("spXoaNhanVien", CommandType.StoredProcedure,
                new SqlParameter("@MaNV", MaNV));
        }
    }//end class
}
