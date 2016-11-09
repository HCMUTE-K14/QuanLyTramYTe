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
    public class ChiThuocThuocDAO
    {
        dataAccess da;
        public ChiThuocThuocDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }
        public DataSet getChiTietThuoc()
        {
            return da.executeQueryDataSet("select * from f_showChiTietThuoc()");
        }
        public bool ThemChiTietThuoc(string MaThuoc,double GiaBanLe,string MaDVT_le)
        {
            return da.executeNonQuery("spThemChiTietThuoc", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@MaThuoc", MaThuoc),
                 new System.Data.SqlClient.SqlParameter("@GiaBanLe", GiaBanLe),
                  new System.Data.SqlClient.SqlParameter("@MaDVT_le", MaDVT_le)
                );
        }
        public bool SuaChiTietThuoc(string MaThuoc,double GiaBanLe,string MaDVT_le)
        {
            return da.executeNonQuery("spCapNhatChiTietThuoc", CommandType.StoredProcedure,
               new System.Data.SqlClient.SqlParameter("@MaThuoc", MaThuoc),
                new System.Data.SqlClient.SqlParameter("@GiaBanLe", GiaBanLe),
                 new System.Data.SqlClient.SqlParameter("@MaDVT_le", MaDVT_le));

        }
        public bool XoaChiTietThuoc(string MaThuoc)
        {
            return da.executeNonQuery("spXoaChiTietThuoc", CommandType.StoredProcedure,
               new System.Data.SqlClient.SqlParameter("@MaThuoc", MaThuoc));
        }
    }//end class
}
