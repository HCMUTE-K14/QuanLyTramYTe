using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bussinessAccessLayer;
namespace QuanLyTramYTe.Classes
{
    public class UserModel
    {
        private string uid;
        private string pwd;
        private string chucvu;
        private string manv;
        private string hoten;
        NhanVienDAO nvDAO;
        DangNhapBAL dn;
        public UserModel(string uid, string pwd)
        {
            this.uid=uid;
            this.pwd=pwd;

            nvDAO=new NhanVienDAO(uid, pwd);
            dn=new DangNhapBAL(uid,pwd);

            System.Data.DataTable dt = new System.Data.DataTable();


            dt=nvDAO.getNhanVien(dn.getMaNV_DN(uid)).Tables[0];

            this.manv=dt.Rows[0]["MaNV"].ToString();
            this.chucvu=dt.Rows[0]["ChucVu"].ToString();
            this.hoten=dt.Rows[0]["HoTen"].ToString();

        }
        public string getHoTen()
        {
            return hoten;
        }
        public string getUid()
        {
            return uid;
        }
        public string getPwd()
        {
            return pwd;
        }
        public string getChucvu()
        {
            return chucvu;
        }
        public string getManv()
        {
            return manv;
        }
    }
}
