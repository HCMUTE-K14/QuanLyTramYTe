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
        public ThuocDAO(string datasource,string uid,string pwd)
        {
            da=new dataAccess();
            da.OpenConnect(datasource,uid, pwd);
          
        }

        public DataSet getThuoc()
        {
            return da.executeQueryDataSet("select * from f_showThuoc()");
        }
        public DataSet getThuocTheoMaLoaiThuoc(string MaLoaiThuoc)
        {
            return da.executeQueryDataSet(string.Format("select * from f_showThuocTheoMaLoaiThuoc({0})",MaLoaiThuoc));
           // return da.executeQueryDataSet("select * from f_showThuocTheoMaLoaiThuoc(2)");
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
        public double getGiaThuoc(string MaThuoc)
        {
            DataTable dt = new DataTable();
            double result = 0;

            dt=da.executeQueryDataSet(string.Format("select [dbo].[f_LayGiaTienTheoMaThuoc]('{0}')", MaThuoc)).Tables[0];

            result=Double.Parse(dt.Rows[0][0].ToString());

            return result;

        }
        public DataSet getDVT(string MaThuoc)
        {
           return da.executeQueryDataSet(string.Format("select * from [dbo].[f_LayDVTTheoMaThuoc]('{0}')", MaThuoc));

        }
    }//end class
}
