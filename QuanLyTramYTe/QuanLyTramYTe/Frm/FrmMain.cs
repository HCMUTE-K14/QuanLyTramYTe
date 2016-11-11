using QuanLyTramYTe.Classes;
using QuanLyTramYTe.Frm;
using QuanLyTramYTe.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTramYTe
{
    public partial class FrmMain : Form
    {
        UserModel um;
        public FrmMain(UserModel um)
        {
            this.um=um;

            InitializeComponent();

            new Classes.MoveFrame(this.panel1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label6.Text=um.getHoTen();
        }

        private void ucPanel31_Load(object sender, EventArgs e)
        {

        }

        private void btnKhamBenhClick(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(new ucBenhNhan(um));
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(new ucThuoc(um));
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();

            if(um.getChucvu()=="Trạm trưởng")
                this.panel2.Controls.Add(new ucNhanVien_tr(um));
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(new ucHoaDon(um));
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Frm.FrmLogin().ShowDialog();
            this.Close();
        }
    }
}
