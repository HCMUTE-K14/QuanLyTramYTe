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

    public partial class FrmGiaThuoc : Form
    {

        ChiThuocThuocDAO ctthuocDAO;
        DonViTinhDAO dvtDAO;
        UserModel um;
        bool f;
        string currentMaThuoc;
        public FrmGiaThuoc(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            ctthuocDAO=new ChiThuocThuocDAO(um.getDataSource() ,um.getUid(), um.getPwd());
            dvtDAO=new DonViTinhDAO(um.getDataSource(),um.getUid(), um.getPwd());
        }

        private void LoadData()
        {

            btnHuy.Enabled=false;
            btnLuu.Enabled=false;
            btnSua.Enabled=true;
           
            btnReload.Enabled=true;


            comboBox1.DataSource=dvtDAO.getDVT().Tables[0];
            comboBox1.DisplayMember="TenDVT";
            comboBox1.ValueMember="MaDVT";


            txtTenThuoc.Enabled=false;
            comboBox1.Enabled=false;
            txtGiaBan.Enabled=false;


            dgvBangGia.DataSource=ctthuocDAO.getChiTietThuoc().Tables[0];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            f=true;
            //
            txtTenThuoc.Enabled=false;
            comboBox1.Enabled=true;
            txtGiaBan.Enabled=true;
         

            txtTenThuoc.ResetText();
            txtGiaBan.ResetText();
            comboBox1.SelectedIndex=0; 
           
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
        
            btnSua.Enabled=false;
            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            f=false;
            //
            txtTenThuoc.Enabled=false;
            comboBox1.Enabled=true;
            txtGiaBan.Enabled=true;
            //lấy hàng cần sửa
            int r = dgvBangGia.CurrentCell.RowIndex;
            currentMaThuoc=dgvBangGia.Rows[r].Cells[0].Value.ToString();
            txtTenThuoc.Text=dgvBangGia.Rows[r].Cells[1].Value.ToString();
            txtGiaBan.Text=dgvBangGia.Rows[r].Cells[3].Value.ToString();
            comboBox1.Text=dgvBangGia.Rows[r].Cells[2].Value.ToString();

            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnSua.Enabled=false;

            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgvBangGia.CurrentCell.RowIndex;
                //lấy mã khách hàng
                currentMaThuoc=dgvBangGia.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi=MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi==DialogResult.OK)
                {
                    bool trangthai = ctthuocDAO.XoaChiTietThuoc(currentMaThuoc);
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

                    bool trangthai = ctthuocDAO.ThemChiTietThuoc(currentMaThuoc, Double.Parse(txtGiaBan.Text), comboBox1.SelectedValue.ToString());
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
                    bool trangthai = ctthuocDAO.SuaChiTietThuoc
                        (currentMaThuoc,Double.Parse(txtGiaBan.Text), comboBox1.SelectedValue.ToString());

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

        private void dgvBangGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvBangGia.CurrentCell.RowIndex;
            currentMaThuoc=dgvBangGia.Rows[r].Cells[0].Value.ToString();
            txtTenThuoc.Text=dgvBangGia.Rows[r].Cells[1].Value.ToString();
            txtGiaBan.Text=dgvBangGia.Rows[r].Cells[3].Value.ToString();
            comboBox1.Text=dgvBangGia.Rows[r].Cells[2].Value.ToString();

        }

        private void FrmGiaThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
