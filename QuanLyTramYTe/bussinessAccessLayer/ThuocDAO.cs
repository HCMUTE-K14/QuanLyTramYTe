using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace bussinessAccessLayer
{
    public class ThuocDAO
    {
        dataAccess da;
        public ThuocDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
          
        }

        public DataSet getThuoc()
        {
            return da.executeQueryDataSet("select * from f_showThuoc()");
        }
        public bool ThemThuoc(string TenThuoc,string MaLT,string TinhTrang,string MoTa)
        {
            return da.executeNonQuery("spThemThuoc", CommandType.StoredProcedure,
                new SqlParameter("@TenThuoc", TenThuoc),
                new SqlParameter("@MaLT", MaLT),
                new SqlParameter("@TinhTrang", TinhTrang),
                new SqlParameter("@MoTa", MoTa));
        }
        public bool SuaThuoc(string MaThuoc,string TenThuoc, string MaLT, string TinhTrang, string MoTa)
        {
            return da.executeNonQuery("spCapNhatThuoc", CommandType.StoredProcedure,
                new SqlParameter("@MaT",MaThuoc),
                new SqlParameter("@TenThuoc", TenThuoc),
                new SqlParameter("@MaLT", MaLT),
                new SqlParameter("@TinhTrang", TinhTrang),
                new SqlParameter("@MoTa", MoTa));
        }

        public bool XoaThuoc(string MaThuoc)
        {
            return da.executeNonQuery("spXoaThuoc", CommandType.StoredProcedure,
                new SqlParameter("@MaT", MaThuoc));
        }

    }//end class
}
