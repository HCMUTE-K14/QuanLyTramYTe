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
        public LichTrucDAO(string datasource,string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(datasource,uid, pwd);
        }
        public DataSet getLichTruc(string MaNV)
        {
            return da.executeQueryDataSet(string.Format("select * from f_showLichTruc('{0}')", MaNV));
        }
        public DataSet getLichTruc(string MaNV,DateTime ngaytruc)
        {
            return da.executeQueryDataSet(string.Format("select * from f_showLichTrucTheoThoiGian('{0}','{1}')", MaNV,ngaytruc.ToShortDateString()));
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
