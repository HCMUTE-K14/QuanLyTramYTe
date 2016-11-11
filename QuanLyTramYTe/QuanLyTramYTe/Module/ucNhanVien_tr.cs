using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using bussinessAccessLayer;
using QuanLyTramYTe.Classes;
namespace QuanLyTramYTe.Module
{
    public partial class ucNhanVien_tr : UserControl
    {
        NhanVienDAO nvDAO;

        UserModel um;

        bool f;

        string currentMaNV;
        public ucNhanVien_tr(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            nvDAO=new NhanVienDAO(um.getUid(), um.getPwd());


        }

        private void LoadData()
        {
            btnHuy.Enabled=false;
            btnLuu.Enabled=false;
            btnSua.Enabled=true;
            btnThem.Enabled=true;
            btnReload.Enabled=true;

            txtHoTen.Enabled=false;
            txtLuong.Enabled=false;
            txtQueQuan.Enabled=false;
            cmbChucVu.Enabled=false;
            cmbTrinhDo.Enabled=false;
            cmbPhai.Enabled=false;
            dateTimePickerNS.Enabled=false;

            cmbTrinhDo.Items.Clear();
            cmbTrinhDo.Items.Add("Đại học");
            cmbTrinhDo.Items.Add("Cao Đẳng");
            cmbTrinhDo.Items.Add("Trung cấp nghề");
            cmbTrinhDo.SelectedIndex=0;

            cmbChucVu.Items.Clear();
            cmbChucVu.Items.Add("Bác sĩ");
            cmbChucVu.Items.Add("Quản lí thuốc");
            cmbChucVu.SelectedIndex=0;

            cmbPhai.Items.Clear();
            cmbPhai.Items.Add("Nam");
            cmbPhai.Items.Add("Nữ");
            cmbPhai.Items.Add("Khác");
            cmbPhai.SelectedIndex=0;

            dataGridView1.DataSource=nvDAO.getNhanVien().Tables[0];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            f=true;
            //

            txtHoTen.Enabled=true;
            txtLuong.Enabled=true;
            txtQueQuan.Enabled=true;
            cmbChucVu.Enabled=true;
            cmbTrinhDo.Enabled=true;
            cmbPhai.Enabled=true;
            dateTimePickerNS.Enabled=true;

            txtHoTen.ResetText();
            txtLuong.ResetText();
            txtQueQuan.ResetText();
            cmbPhai.SelectedIndex=0;
            cmbTrinhDo.SelectedIndex=0;
            cmbChucVu.SelectedIndex=0;
            dateTimePickerNS.ResetText();
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnThem.Enabled=false;
            btnSua.Enabled=false;
            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            f=false;
            //
            txtHoTen.Enabled=true;
            txtLuong.Enabled=true;
            txtQueQuan.Enabled=true;
            cmbChucVu.Enabled=true;
            cmbTrinhDo.Enabled=true;
            cmbPhai.Enabled=true;
            dateTimePickerNS.Enabled=true;
            //lấy hàng cần sửa
            int r = dataGridView1.CurrentCell.RowIndex;
            currentMaNV=dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtHoTen.Text=dataGridView1.Rows[r].Cells["HoTen"].Value.ToString();
            txtQueQuan.Text=dataGridView1.Rows[r].Cells["QueQuan"].Value.ToString();
            txtLuong.Text=dataGridView1.Rows[r].Cells["Luong"].Value.ToString();
            cmbChucVu.Text=dataGridView1.Rows[r].Cells["ChucVu"].Value.ToString();
            cmbTrinhDo.Text=dataGridView1.Rows[r].Cells["TrinhDo"].Value.ToString();
            cmbPhai.Text=dataGridView1.Rows[r].Cells["Phai"].Value.ToString();
            try
            {
                dateTimePickerNS.Value=DateTime.Parse(dataGridView1.Rows[r].Cells["NgaySinh"].Value.ToString());
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
                currentMaNV=dataGridView1.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi=MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi==DialogResult.OK)
                {
                    bool trangthai = nvDAO.XoaNhanVien(currentMaNV);
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
            catch (Exception)
            {

            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (f)
                {
                    
                    bool trangthai = nvDAO.ThemNhanVien(txtHoTen.Text,dateTimePickerNS.Value,txtQueQuan.Text
                        ,cmbTrinhDo.Text,Double.Parse(txtLuong.Text),cmbChucVu.Text,cmbPhai.Text);
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
                    bool trangthai = nvDAO.SuaNhanVien(currentMaNV,txtHoTen.Text, dateTimePickerNS.Value, txtQueQuan.Text
                        , cmbTrinhDo.Text, Double.Parse(txtLuong.Text), cmbChucVu.Text, cmbPhai.Text);
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
            catch (Exception) { }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ucNhanVien_tr_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnXepLich(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            currentMaNV=dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtHoTen.Text=dataGridView1.Rows[r].Cells["HoTen"].Value.ToString();
            txtQueQuan.Text=dataGridView1.Rows[r].Cells["QueQuan"].Value.ToString();
            txtLuong.Text=dataGridView1.Rows[r].Cells["Luong"].Value.ToString();
            cmbChucVu.Text=dataGridView1.Rows[r].Cells["ChucVu"].Value.ToString();
            cmbTrinhDo.Text=dataGridView1.Rows[r].Cells["TrinhDo"].Value.ToString();
            cmbPhai.Text=dataGridView1.Rows[r].Cells["Phai"].Value.ToString();
            try
            {
                dateTimePickerNS.Value=DateTime.Parse(dataGridView1.Rows[r].Cells["NgaySinh"].Value.ToString());
            }
            catch { }
        }
    }
}
