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
    public class DonViTinhDAO
    {
        dataAccess da;
        public DonViTinhDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }
        public DataSet getDVT()
        {
            return da.executeQueryDataSet("select * from f_showDVT()");
        }
        public bool ThemDVT(string TenDVT)
        {
            return da.executeNonQuery("spThemDVT", CommandType.StoredProcedure, new SqlParameter("@TenDVT", TenDVT));
        }

        public bool SuaDVT(string MaDVT,string TenDVT)
        {
            return da.executeNonQuery("spCapNhatDVT", CommandType.StoredProcedure,
                new SqlParameter("@MaDVT", MaDVT),
                new SqlParameter("@TenDVT",TenDVT)); 
        }
        public bool XoaDVT(string MaDVT)
        {
            return da.executeNonQuery("spXoaDVT", CommandType.StoredProcedure,
                new SqlParameter("@MaDVT", MaDVT));
        }
    }//end class
}
