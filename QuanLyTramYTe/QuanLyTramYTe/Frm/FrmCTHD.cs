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
    public partial class FrmCTHD : Form
    {
        ChiTietHoaDonDAO cthdDAO;
        HoaDonDAO hdDAO;
        UserModel um;

        string currentMaHD;
        public FrmCTHD(UserModel um,string currentMaHD)
        {
            InitializeComponent();

            this.um=um;

            this.currentMaHD=currentMaHD;

            cthdDAO=new ChiTietHoaDonDAO(um.getDataSource(),um.getUid(), um.getPwd());
            hdDAO=new HoaDonDAO(um.getDataSource(), um.getUid(), um.getPwd());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            try
            {
                txtMaHD.Text=dataGridView1.Rows[r].Cells["MaHoaDon"].Value.ToString();
                txtTenThuoc.Text=dataGridView1.Rows[r].Cells["TenThuoc"].Value.ToString();
                txtSoLuong.Text=dataGridView1.Rows[r].Cells["SoLuong"].Value.ToString();
                txtGiaBan.Text=dataGridView1.Rows[r].Cells["GiaBanLe"].Value.ToString();
            }
            catch { }
        }

        private void FrmCTHD_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=cthdDAO.getChiTietHoaDon(currentMaHD).Tables[0];

            label6.Text=hdDAO.TongTienHoaDon(currentMaHD).ToString();
        }
    }
}
