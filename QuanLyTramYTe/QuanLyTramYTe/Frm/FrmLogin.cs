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

            mLogin1.login+=new ucLogin.LoginHandler(loginMethod); 
        }
        UserModel um;
        private void loginMethod(ucLogin.mLogin sender, EventArgs e)
        {
            string username = mLogin1.userid;
            string password = mLogin1.password;
            um= new UserModel(username,password);
            login=new DangNhapBAL(um.getUid(), um.getPwd());

            if (login.ISLOGINED().Equals("yes"))
            {
                this.Hide();
                new FrmMain(um).ShowDialog();
                this.Close();
                    
                return;
            }
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
