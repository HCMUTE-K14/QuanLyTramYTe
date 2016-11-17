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
    public class LichTaiKhamDAO
    {
        dataAccess da;
        public LichTaiKhamDAO(string datasource,string uid, string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(datasource,uid, pwd);
        }

        public DataSet getLichTaiKham()
        {
            return da.executeQueryDataSet("select * from f_showLichTaiKham()");
        }

        public bool ThemLichTaiKham(string MaHD,string NgayTaiKham,string GhiChu)
        {
            return da.executeNonQuery("spThemLichTaiKham", CommandType.StoredProcedure,
                new SqlParameter("@MaHoaDon", MaHD),
                new SqlParameter("@NgayTaiKham", NgayTaiKham),
                new SqlParameter("@GhiChu", GhiChu));
        }

        public bool SuaLichTaiKham(string MaHD, string NgayTaiKham, string GhiChu)
        {
            return da.executeNonQuery("spCapNhatLichTaiKham", CommandType.StoredProcedure,
               new SqlParameter("@MaHoaDon", MaHD),
               new SqlParameter("@NgayTaiKham", NgayTaiKham),
               new SqlParameter("@GhiChu", GhiChu));
        }
        public bool XoaLichTaiKham(string MaLichHen)
        {
            return da.executeNonQuery("spXoaLichTaiKham", CommandType.StoredProcedure,
               new SqlParameter("@MaLichHen", MaLichHen));
        }

        public int SoTaiKhamTrongNgay(string NgayTaiKham)
        {
            return Convert.ToInt32(da.executeScalar(string.Format("select * from f_tongTaiKham('{0}')", NgayTaiKham), CommandType.Text, null));
        }

        public DataSet LichTaiKhamMoiNhat(string MaBN)
        {
            return da.executeQueryDataSet(string.Format("select * from f_LichTaiKhamMoiNhat('{0}')", MaBN));
        }
    }//end class
}
