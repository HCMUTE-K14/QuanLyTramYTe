using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
namespace bussinessAccessLayer
{

    public class DangNhapBAL
    {
        dataAccess dao;

        private bool isLogined = false;
        private string uid;
        private string pwd;

        public string ISLOGINED()
        {
            return isLogined ?"yes":"no";
        }
        public DangNhapBAL(string uid, string pwd)
        {
            dao=new dataAccess();

            this.uid=uid;
            this.pwd=pwd;

            isLogined=CheckLogin(uid, pwd);

           
        
        }

        public string getMaNV_DN(string uid)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt=dao.executeQueryDataSet(string.Format("select [dbo].[f_getMaNV_TheoLogin]('{0}')", uid)).Tables[0];

            return dt.Rows[0][0].ToString();
        }

        public bool CheckLogin(string uid, string pwd)
        {
            return dao.OpenConnect(uid, pwd);
        }
    }
}
