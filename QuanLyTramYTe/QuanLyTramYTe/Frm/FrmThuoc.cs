using QuanLyTramYTe.Classes;
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
using System.Data.SqlClient;

namespace QuanLyTramYTe.Frm
{
    public partial class FrmThuoc : Form
    {
        UserModel um;
        ThuocDAO thuocDao;
        DonViTinhDAO dvtDao;
        LoaiThuocDAO ltDao;
        ChiThuocThuocDAO cttDao;
        bool f;
        string currentMaThuoc;
        public FrmThuoc(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            thuocDao=new ThuocDAO(um.getUid(), um.getPwd());
            dvtDao=new DonViTinhDAO(um.getUid(), um.getPwd());
            ltDao=new LoaiThuocDAO(um.getUid(), um.getPwd());
            cttDao=new ChiThuocThuocDAO(um.getUid(), um.getPwd());

        }
        private void LoadData()
        {

            btnHuy.Enabled=false;
            btnLuu.Enabled=false;
            btnSua.Enabled=true;
            btnThem.Enabled=true;
            btnReload.Enabled=true;

            txtTenThuoc.Enabled=false;
            txtMoTa.Enabled=false;
            txtTinhTrang.Enabled=false;

            comBoxLoaiThuoc.Enabled=false;

            comBoxLoaiThuoc.DataSource=ltDao.getLoaiThuoc().Tables[0];
            comBoxLoaiThuoc.DisplayMember="TenLoaiThuoc";
            comBoxLoaiThuoc.ValueMember="MaLoaiThuoc";

            dgvThuoc.DataSource=thuocDao.getThuoc().Tables[0];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            f=true;
            //
            txtTenThuoc.Enabled=true;
            txtTinhTrang.Enabled=true;
            txtMoTa.Enabled=true;
            comBoxLoaiThuoc.Enabled=true;


            txtTenThuoc.ResetText();
            txtTinhTrang.ResetText();
            txtMoTa.ResetText();
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnThem.Enabled=false;
            btnSua.Enabled=false;
            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
            txtTenThuoc.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            f=false;
            //
            txtTenThuoc.Enabled=true;
            txtTinhTrang.Enabled=true;
            txtMoTa.Enabled=true;
            comBoxLoaiThuoc.Enabled=true;

            //lấy hàng cần sửa
            int r = dgvThuoc.CurrentCell.RowIndex;
            currentMaThuoc=dgvThuoc.Rows[r].Cells["MaThuoc"].Value.ToString();
            txtTenThuoc.Text=dgvThuoc.Rows[r].Cells["TenThuoc"].Value.ToString();
            txtMoTa.Text=dgvThuoc.Rows[r].Cells["MoTa"].Value.ToString();
            txtTinhTrang.Text=dgvThuoc.Rows[r].Cells["TinhTrang"].Value.ToString();
            comBoxLoaiThuoc.Text=dgvThuoc.Rows[r].Cells["TenLoaiThuoc"].Value.ToString();
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
                int r = dgvThuoc.CurrentCell.RowIndex;
                //lấy mã khách hàng
                currentMaThuoc=dgvThuoc.Rows[r].Cells["MaThuoc"].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi=MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi==DialogResult.OK)
                {
                    bool trangthai = thuocDao.XoaThuoc(currentMaThuoc);
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
                    bool trangthai = thuocDao.ThemThuoc(txtTenThuoc.Text, comBoxLoaiThuoc.SelectedValue.ToString(),
                        txtTinhTrang.Text, txtMoTa.Text);
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
                    bool trangthai = thuocDao.SuaThuoc(currentMaThuoc, txtTenThuoc.Text, comBoxLoaiThuoc.SelectedValue.ToString(), txtTinhTrang.Text, txtMoTa.Text);

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


        private void FrmThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy hàng cần sửa
            int r = dgvThuoc.CurrentCell.RowIndex;
            currentMaThuoc=dgvThuoc.Rows[r].Cells["MaThuoc"].Value.ToString();
            txtTenThuoc.Text=dgvThuoc.Rows[r].Cells["TenThuoc"].Value.ToString();
            txtMoTa.Text=dgvThuoc.Rows[r].Cells["MoTa"].Value.ToString();
            txtTinhTrang.Text=dgvThuoc.Rows[r].Cells["TinhTrang"].Value.ToString();

            comBoxLoaiThuoc.Text=dgvThuoc.Rows[r].Cells["TenLoaiThuoc"].Value.ToString();
        }
    }
}
