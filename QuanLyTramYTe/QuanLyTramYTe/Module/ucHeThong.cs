using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuanLyTramYTe.Classes;
using bussinessAccessLayer;
namespace QuanLyTramYTe.Module
{
    public partial class ucHeThong : UserControl
    {
        UserModel um;
        DangNhapBAL dnDAO;
        public ucHeThong(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            dnDAO=new DangNhapBAL(um.getUid(), um.getPwd());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

          
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                
                if (!dnDAO.Backup(fbd.RootFolder.ToString()))
                    return;

                MessageBox.Show("Sao lưu thành công:"+fbd.SelectedPath);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter="BAK files (*.bak)|*.bak";
            if (opf.ShowDialog()==DialogResult.OK)
            {
                
                if (!dnDAO.Restore(opf.FileName))
                    return;

                MessageBox.Show("Restore thành công");
            }


        }
    }
}
