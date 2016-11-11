using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTramYTe.Classes;

namespace QuanLyTramYTe.Module
{
    public partial class ucThuoc : UserControl
    {
        UserModel um;
        public ucThuoc(UserModel um)
        {
            InitializeComponent();

            this.um=um;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Frm.FrmLoaiThuoc(this.um).ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Frm.FrmThuoc(this.um).ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Frm.FrmGiaThuoc(this.um).ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Frm.FrmDonViTinh(this.um).ShowDialog();
        }
    }
}
