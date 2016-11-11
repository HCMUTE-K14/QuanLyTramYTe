using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bussinessAccessLayer;
using QuanLyTramYTe.Classes;
namespace QuanLyTramYTe.Frm
{
    public partial class FrmHoaDon : Form
    {

        HoaDonDAO hdDAO;
        UserModel um;
        string currentMaHD;
        public FrmHoaDon(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            hdDAO=new HoaDonDAO(um.getUid(), um.getPwd());


        }
        private void LoadData()
        {
            txtMaHD.ResetText();
            txtNgayLap.ResetText();
            txtNguoiTao.ResetText();
            txtTongTien.ResetText();

            dataGridView1.DataSource=hdDAO.getHoaDon().Tables[0];
        }
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=hdDAO.getHoaDon(dateTimePicker1.Value).Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            try
            {
                currentMaHD=dataGridView1.Rows[r].Cells["MaHoaDon"].Value.ToString();
                txtMaHD.Text=dataGridView1.Rows[r].Cells["MaHoaDon"].Value.ToString();
                txtNgayLap.Text=((DateTime)dataGridView1.Rows[r].Cells["NgayLapHoaDon"].Value).ToShortDateString();
                txtNguoiTao.Text=dataGridView1.Rows[r].Cells["HoTen"].Value.ToString();
                txtTongTien.Text=dataGridView1.Rows[r].Cells["SoTien"].Value.ToString();
            }
            catch { }
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new Frm.FrmCTHD(um, currentMaHD).ShowDialog();
        }
    }
}
