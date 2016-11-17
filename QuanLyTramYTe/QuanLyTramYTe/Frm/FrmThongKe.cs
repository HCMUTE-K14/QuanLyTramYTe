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
    public partial class FrmThongKe : Form
    {
        UserModel um;
        HoaDonDAO hdDAO;
        public FrmThongKe(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            hdDAO=new HoaDonDAO(um.getDataSource(), um.getUid(), um.getPwd());
        }
        DateTime Ngay1, Ngay2;
        double _DoanhThu;
        DataTable dt;

        private void FrmThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            _DoanhThu=0;
            txtDoanhThu.ResetText();

            Ngay1=DateTime.Parse(dateBD.Text);
            Ngay2=DateTime.Parse(dateKT.Text);
            //if (Ngay1==Ngay2)
            //    Ngay2=Ngay2.AddHours(12);
            if (Ngay1>Ngay2)
            {
                MessageBox.Show("Chọn lại ngày !!!!");
                return;
            }
            dt=hdDAO.ThongKe(Ngay1, Ngay2).Tables[0];
            if (dt.Rows.Count<=0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            dgvDuLieu.DataSource=dt;
            dgvDuLieu.AutoResizeRows();
            dgvDuLieu.AutoResizeColumns();

            for (int i = 0; i<dgvDuLieu.Rows.Count-1; i++)
                _DoanhThu=_DoanhThu+Double.Parse(dgvDuLieu.Rows[i].Cells[1].Value.ToString());

            txtDoanhThu.Text=_DoanhThu.ToString();

        }
    }
}
