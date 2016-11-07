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
using System.Data.SqlClient;

namespace QuanLyTramYTe.Module
{
    public partial class ucBenhNhan : UserControl
    {
        BenhNhanDAO bn;
        bool f = true;
        string curMaBN;
        public ucBenhNhan(UserModel um)
        {
            InitializeComponent();

            bn=new BenhNhanDAO(um.getUid(), um.getPwd());
        }

        private void LoadData()
        {

            btnHuy.Enabled=false;
            btnLuu.Enabled=false;
            btnSua.Enabled=true;
            btnThem.Enabled=true;
            btnReload.Enabled=true;

            txtTenBenhNhan.Enabled=false;
            txtCMND.Enabled=false;
            txtQueQuan.Enabled=false;
            dateTimePicker1.Enabled=false;
            txtSDT.Enabled=false;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            comboBox1.Items.Add("Khác");
            comboBox1.SelectedIndex=0;

            dataGridView1.DataSource=bn.getBenhNhan().Tables[0];
        }

        private void ucBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            f=true;
            //
            txtTenBenhNhan.Enabled=true;
            txtSDT.Enabled=true;
            txtQueQuan.Enabled=true;
            txtCMND.Enabled=true;

            txtTenBenhNhan.ResetText();
            txtSDT.ResetText();
            txtQueQuan.ResetText();
            txtCMND.ResetText();
            dateTimePicker1.Enabled=true;
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnThem.Enabled=false;
            btnSua.Enabled=false;
            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
            txtTenBenhNhan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            f=false;
            //
            txtTenBenhNhan.Enabled=true;
            txtSDT.Enabled=true;
            txtQueQuan.Enabled=true;
            txtCMND.Enabled=true;
            dateTimePicker1.Enabled=true;
            //lấy hàng cần sửa
            int r = dataGridView1.CurrentCell.RowIndex;
            curMaBN=dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtTenBenhNhan.Text=dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtQueQuan.Text=dataGridView1.Rows[r].Cells[2].Value.ToString();
            txtCMND.Text=dataGridView1.Rows[r].Cells[3].Value.ToString();
            txtSDT.Text=dataGridView1.Rows[r].Cells[5].Value.ToString();
            try
            {

                dateTimePicker1.Value=DateTime.Parse(dataGridView1.Rows[r].Cells[4].Value.ToString());
            }
            catch { }
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnThem.Enabled=false;
            btnSua.Enabled=false;
           
            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dataGridView1.CurrentCell.RowIndex;
                //lấy mã khách hàng
                curMaBN=dataGridView1.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi=MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi==DialogResult.OK)
                {
                    bool trangthai = bn.XoaBenhNhan(curMaBN);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (f)
                {
                    string tenbn = txtTenBenhNhan.Text;
                    string qq = txtQueQuan.Text;
                    string cmnd = txtCMND.Text;
                    string ns = dateTimePicker1.Value.ToShortDateString();
                    string sdt = txtSDT.Text;
                    string gt = comboBox1.Text;
                    MessageBox.Show(gt);
                    bool trangthai = bn.ThemBenhNhan(tenbn,qq,cmnd,ns,sdt,gt);
                    if (trangthai)
                    {

                        MessageBox.Show("Thêm dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Không thêm được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool trangthai = bn.SuaBenhNhan(curMaBN, txtTenBenhNhan.Text, txtQueQuan.Text, txtCMND.Text, dateTimePicker1.Value.ToShortDateString(), txtSDT.Text, comboBox1.Text);
                    if (trangthai)
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Không cập nhật được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException) { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            curMaBN=dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtTenBenhNhan.Text=dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtQueQuan.Text=dataGridView1.Rows[r].Cells[2].Value.ToString();
            txtCMND.Text=dataGridView1.Rows[r].Cells[3].Value.ToString();
            txtSDT.Text=dataGridView1.Rows[r].Cells[5].Value.ToString();
            try
            {
                dateTimePicker1.Value=DateTime.Parse(dataGridView1.Rows[r].Cells[4].Value.ToString());
            }
            catch { }
        }
    }
}
