using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTramYTe.Classes;
using bussinessAccessLayer;
namespace QuanLyTramYTe.Frm
{
    public partial class FrmLichTaiKham : Form
    {
        UserModel um;
        string currentMaBN;
        string currentTenBN;
        LichTaiKhamDAO ltkDAO;
        public FrmLichTaiKham(UserModel um,string MaBN,string TenBN)
        {
            InitializeComponent();

            this.um=um;

            currentMaBN=MaBN;

            currentTenBN=TenBN;

            ltkDAO=new LichTaiKhamDAO(um.getUid(), um.getPwd());
        }

        private void FrmLichTaiKham_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            txtHoTen.Text=currentTenBN;

            dt=ltkDAO.LichTaiKhamMoiNhat(currentMaBN).Tables[0];
            if (dt.Rows.Count<=0)
                return;

            
            txtNgayTaiKham.Text=dt.Rows[0]["NgayTaiKham"].ToString();
            txtGhiChu.Text=dt.Rows[0]["GhiChu"].ToString();
        }
    }
}
