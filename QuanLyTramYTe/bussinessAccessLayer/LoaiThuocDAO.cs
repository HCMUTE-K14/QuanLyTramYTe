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
    public class LoaiThuocDAO
    {
        dataAccess da;
        public LoaiThuocDAO(string uid, string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }
        public DataSet getLoaiThuoc()
        {
            return da.executeQueryDataSet("select * from f_showLoaiThuoc()");
        }
        public bool ThemLoaiThuoc(string TenLoaiThuoc)
        {
            return da.executeNonQuery("spThemLoaiThuoc", CommandType.StoredProcedure, new SqlParameter("@TenLoaiThuoc", TenLoaiThuoc));
        }

        public bool SuaLoaiThuoc(string MaLoaiThuoc, string TenLoaiThuoc)
        {
            return da.executeNonQuery("spCapNhatLoaiThuoc", CommandType.StoredProcedure,
                new SqlParameter("@MaLT", MaLoaiThuoc),
                new SqlParameter("@TenLThuoc", TenLoaiThuoc));
        }
        public bool XoaLoaiThuoc(string MaLoaiThuoc)
        {
            return da.executeNonQuery("spXoaLoaiThuoc", CommandType.StoredProcedure,
                new SqlParameter("@MaLT", MaLoaiThuoc));
        }
    }//end class
}
