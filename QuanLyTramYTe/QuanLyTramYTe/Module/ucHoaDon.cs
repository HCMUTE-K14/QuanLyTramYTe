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
    public partial class ucHoaDon : UserControl
    {

        UserModel um;
        HoaDonDAO hdDAO;
        ChiTietHoaDonDAO cthdDAO;
        public ucHoaDon(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            hdDAO=new HoaDonDAO(um.getDataSource(), um.getUid(), um.getPwd());

            cthdDAO=new ChiTietHoaDonDAO(um.getDataSource(), um.getUid(), um.getPwd());

        }

        private void LoadData()
        {
            DataTable hd = new DataTable();

            //dataGridView1.DataSource=hdDAO.getHoaDon().Tables[0];


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Frm.FrmHoaDon(um).ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Frm.FrmThongKe(um).ShowDialog();
        }
    }
}
