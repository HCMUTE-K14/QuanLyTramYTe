using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ucLogin;
using bussinessAccessLayer;
using QuanLyTramYTe.Classes;

namespace QuanLyTramYTe.Frm
{
    
    public partial class FrmLogin : Form
    {

        DangNhapBAL login;
      
        public FrmLogin()
        {
            InitializeComponent();

            mLogin2.login+=new ucLogin.LoginHandler(loginMethod); 
        }
        UserModel um;
        private void loginMethod(ucLogin.mLogin sender, EventArgs e)
        {
            string username = "trtram";
            string password = "1234";
            string datasource = ".\\SQLEXPRESS";
            um= new UserModel(username,password);
            um.setDataSource(datasource);
            MessageBox.Show(username+password+datasource);
            login=new DangNhapBAL(um.getDataSource(),um.getUid(), um.getPwd());

            if (login.ISLOGINED().Equals("yes"))
            {
                this.Hide();
                new FrmMain(um).ShowDialog();
                this.Close();
                    
                return;
            }
            MessageBox.Show("failse");
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
