using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
namespace bussinessAccessLayer
{
    public class BenhNhanDAO
    {
        dataAccess da;
        public BenhNhanDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
           
        }
        public DataSet getBenhNhan()
        {
            return da.executeQueryDataSet("select * from f_showBenhNhan()");
        }
        public bool ThemBenhNhan(string TenKhachHang,string QueQuan,string CMND,DateTime NgaySinh,string SDT,string GioiTinh)
        {
            return da.executeNonQuery("spThemBenhNhan", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@TenKhachHang", TenKhachHang),
                 new System.Data.SqlClient.SqlParameter("@QueQuan", QueQuan),
                  new System.Data.SqlClient.SqlParameter("@CMND", CMND),
                   new System.Data.SqlClient.SqlParameter("@NgaySinh", NgaySinh),
                    new System.Data.SqlClient.SqlParameter("@SDT", SDT),
                      new System.Data.SqlClient.SqlParameter("@GioiTinh", GioiTinh)

                );
        }
        public bool SuaBenhNhan(string MaKhachHang,string TenKhachHang, string QueQuan, string CMND, DateTime NgaySinh, string SDT,string GioiTinh)
        {
            return da.executeNonQuery("spCapNhatBenhNhan", CommandType.StoredProcedure,
                 new System.Data.SqlClient.SqlParameter("@MaKH", MaKhachHang),
                new System.Data.SqlClient.SqlParameter("@TenKhachHang", TenKhachHang),
                 new System.Data.SqlClient.SqlParameter("@QueQuan", QueQuan),
                  new System.Data.SqlClient.SqlParameter("@CMND", CMND),
                   new System.Data.SqlClient.SqlParameter("@NgaySinh", NgaySinh),
                    new System.Data.SqlClient.SqlParameter("@SDT", SDT), 
                      new System.Data.SqlClient.SqlParameter("@GioiTinh", GioiTinh)
                );
        }
        public bool XoaBenhNhan(string MaKH)
        {
            return da.executeNonQuery("spXoaBenhNhan", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@MaKH", MaKH));
        }

        public DataSet InfomationBenhNhan(string MaKH)
        {
            string sql = string.Format("select * from [f_ThongTinBenhNhan]('{0}')", MaKH);
            return da.executeQueryDataSet(sql);
        }
    }
}
