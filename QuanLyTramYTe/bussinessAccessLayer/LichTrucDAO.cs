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
    public class LichTrucDAO
    {
        dataAccess da;
        public LichTrucDAO(string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(uid, pwd);
        }

        public bool ThemLichTruc(string MaNV,string NgayDiTruc,string CongViecTruc)
        {
            return da.executeNonQuery("spThemLichTruc",CommandType.StoredProcedure,
                new SqlParameter("@MaNV",MaNV),
                new SqlParameter("@NgayDiTruc",NgayDiTruc),
                new SqlParameter("@CongViecTruc",CongViecTruc));
        }

        public bool SuaLichTruc(string MaNV, string NgayDiTruc, string CongViecTruc)
        {
            return da.executeNonQuery("spThemLichTruc", CommandType.StoredProcedure,
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@NgayDiTruc", NgayDiTruc),
                new SqlParameter("@CongViecTruc", CongViecTruc));
        }
        public bool XoaLichTruc(string MaNV, string NgayDiTruc)
        {
            return da.executeNonQuery("spXoaLichTruc", CommandType.StoredProcedure,
                 new SqlParameter("@MaNV", MaNV),
                 new SqlParameter("@NgayDiTruc", NgayDiTruc));
        }


    }//end class
}
