using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bussinessAccessLayer;
using QuanLyTramYTe.Classes;
namespace QuanLyTramYTe.Module
{
    public partial class ucNhanVien_bt : UserControl
    {
        NhanVienDAO nvDAO;
        LichTrucDAO ltrDAO;
        UserModel um;
        public ucNhanVien_bt(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            nvDAO=new NhanVienDAO(um.getDataSource(), um.getUid(), um.getPwd());
            ltrDAO=new LichTrucDAO(um.getDataSource(), um.getUid(), um.getPwd());
        }
        private void LoadData()
        {
            DataTable dt = new DataTable();

            dt=nvDAO.getNhanVien(um.getManv()).Tables[0];
            if (dt.Rows.Count<=0)
                return;
            txtHoTen.Text=dt.Rows[0]["HoTen"].ToString();
            txtMaNhanVien.Text=dt.Rows[0]["MaNV"].ToString();
            dateTimePickerNS.Value=DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            txtQueQuan.Text=dt.Rows[0]["QueQuan"].ToString();
            txtPhai.Text=dt.Rows[0]["Phai"].ToString();
            txtLuong.Text=dt.Rows[0]["Luong"].ToString();
            txtTrinhDo.Text=dt.Rows[0]["TrinhDo"].ToString();
            txtChucVu.Text=dt.Rows[0]["ChucVU"].ToString();

            
        }

        private void ucNhanVien_bt_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
           
        }
    }
}
