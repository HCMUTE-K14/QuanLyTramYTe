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
    public partial class ucKhamBenh : UserControl
    {
        UserModel um;

        BenhNhanDAO bnDAO;
        ThuocDAO tDAO;
        HoaDonDAO hdDAO;
        ChiTietHoaDonDAO cthdDAO;
        LoaiThuocDAO ltDAO;
       
        public ucKhamBenh(UserModel um)
        {
            InitializeComponent();

            this.um=um;
            bnDAO=new BenhNhanDAO(um.getDataSource(), um.getUid(), um.getPwd());
            ltDAO=new LoaiThuocDAO(um.getDataSource(), um.getUid(), um.getPwd());
            tDAO=new ThuocDAO(um.getDataSource(), um.getUid(), um.getPwd());

            cmbBenhNhan.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
            cmbBenhNhan.AutoCompleteSource=AutoCompleteSource.ListItems;

            cmbLoaiThuoc.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
            cmbLoaiThuoc.AutoCompleteSource=AutoCompleteSource.ListItems;

          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        DataTable dtBN = new DataTable();
        DataTable dtLoaiThuoc = new DataTable();
      


        string currentMaLoaiThuoc;
        private void LoadData()
        {
            dtBN=bnDAO.getBenhNhan().Tables[0];
            if (dtBN.Rows.Count<=0)
                return;

            cmbBenhNhan.Items.Clear();
            cmbBenhNhan.DataSource=dtBN;
            cmbBenhNhan.DisplayMember="TenKhachHang";
            cmbBenhNhan.ValueMember="MaKH";

            dtLoaiThuoc=ltDAO.getLoaiThuoc().Tables[0];

            cmbLoaiThuoc.Items.Clear();
            cmbLoaiThuoc.DataSource=dtLoaiThuoc;
            cmbLoaiThuoc.ValueMember="MaLoaiThuoc";
            cmbLoaiThuoc.DisplayMember="TenLoaiThuoc";
           
        }
        private void ucKhamBenh_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void cmbBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGT.Text=dtBN.Rows[cmbBenhNhan.SelectedIndex]["GioiTinh"].ToString();
            txtNamSinh.Text=DateTime.Parse(dtBN.Rows[cmbBenhNhan.SelectedIndex]["NgaySinh"].ToString()).ToShortDateString();
            txtQueQuan.Text=dtBN.Rows[cmbBenhNhan.SelectedIndex]["QueQuan"].ToString();
            txtCMND.Text=dtBN.Rows[cmbBenhNhan.SelectedIndex]["CMND"].ToString();
            txtSDT.Text=dtBN.Rows[cmbBenhNhan.SelectedIndex]["SDT"].ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Parent.Controls.Add(new ucBenhNhan(um));
        }

        private void cmbLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMaLoaiThuoc=cmbLoaiThuoc.SelectedValue.ToString();

            try
            {
                DataTable dt = new DataTable();

                dt=tDAO.getThuocTheoMaLoaiThuoc(currentMaLoaiThuoc).Tables[0];

                cmbThuoc.DataSource=dt;
                cmbThuoc.DisplayMember="TenThuoc";
                cmbThuoc.ValueMember="MaThuoc";

            }
            catch { }
        }
    }
}
