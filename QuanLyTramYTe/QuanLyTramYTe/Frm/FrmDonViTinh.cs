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
    public partial class FrmDonViTinh : Form
    {
        public FrmDonViTinh(UserModel um)
        {
            InitializeComponent();

            this.um=um;

            dvtDAO=new DonViTinhDAO(um.getUid(), um.getPwd());
        }

        DonViTinhDAO dvtDAO;
        UserModel um;
        bool f;
        string currentMVT;
        private void LoadData()
        {
            btnHuy.Enabled=false;
            btnLuu.Enabled=false;
            btnSua.Enabled=true;
            btnThem.Enabled=true;
            btnReload.Enabled=true;
            txtLoaiThuoc.Enabled=false;

            dgvLoaiThuoc.DataSource=dvtDAO.getDVT().Tables[0];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            f=true;
            //
            txtLoaiThuoc.ResetText();
            txtLoaiThuoc.Enabled=true;
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnThem.Enabled=false;
            btnSua.Enabled=false;
            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
            txtLoaiThuoc.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            f=false;
            //
            txtLoaiThuoc.Enabled=true;
            //lấy hàng cần sửa
            int r = dgvLoaiThuoc.CurrentCell.RowIndex;
            currentMVT=dgvLoaiThuoc.Rows[r].Cells[0].Value.ToString();
            txtLoaiThuoc.Text=dgvLoaiThuoc.Rows[r].Cells[1].Value.ToString();
            //
            btnLuu.Enabled=true;
            btnHuy.Enabled=true;
            //
            btnThem.Enabled=false;
            btnSua.Enabled=false;

            btnXoa.Enabled=true;
            //đưa trỏ lên ô nhập liệu
            txtLoaiThuoc.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgvLoaiThuoc.CurrentCell.RowIndex;
                //lấy mã khách hàng
                currentMVT=dgvLoaiThuoc.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi=MessageBox.Show("Bạn có muốn xóa không?\nChú ý: Khi xóa loại thuốc thì tất cả các thông tin liên quan đến thuốc thuộc loại cũng bị xóa.\nHãy cân nhắc.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi==DialogResult.OK)
                {
                    bool trangthai = dvtDAO.XoaDVT(currentMVT);
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
                if (txtLoaiThuoc.Text.Trim()!="")
                {
                    if (f)
                    {
                        bool trangthai = dvtDAO.ThemDVT(txtLoaiThuoc.Text);
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
                        string err = "";
                        bool trangthai = dvtDAO.SuaDVT(currentMVT, txtLoaiThuoc.Text);
                        if (trangthai)
                        {


                            MessageBox.Show("Sữa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không sữa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập dữ liệu vào ô!", "Thông báo");
                }

            }
            catch (Exception)
            {

            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvLoaiThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLoaiThuoc.CurrentCell.RowIndex;
            txtLoaiThuoc.Text=dgvLoaiThuoc.Rows[r].Cells[1].Value.ToString();
        }

        private void FrmDonViTinh_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
