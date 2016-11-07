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

        }

        private void ucPanel31_Load(object sender, EventArgs e)
        {

        }

        private void btnKhamBenhClick(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(new ucBenhNhan(um));
        }
    }
}
