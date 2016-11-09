namespace QuanLyTramYTe.Frm
{
    partial class FrmLoaiThuoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing&&(components!=null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLoaiThuoc = new System.Windows.Forms.DataGridView();
            this.txtLoaiThuoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MaLoaiThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiThuoc)).BeginInit();
            this.btnReload.SuspendLayout();
            this.btnHuy.SuspendLayout();
            this.btnLuu.SuspendLayout();
            this.btnXoa.SuspendLayout();
            this.btnSua.SuspendLayout();
            this.btnThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoaiThuoc
            // 
            this.dgvLoaiThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiThuoc,
            this.TenLoaiThuoc});
            this.dgvLoaiThuoc.Location = new System.Drawing.Point(16, 67);
            this.dgvLoaiThuoc.Name = "dgvLoaiThuoc";
            this.dgvLoaiThuoc.Size = new System.Drawing.Size(312, 191);
            this.dgvLoaiThuoc.TabIndex = 80;
            this.dgvLoaiThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiThuoc_CellClick);
            // 
            // txtLoaiThuoc
            // 
            this.txtLoaiThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaiThuoc.Location = new System.Drawing.Point(57, 38);
            this.txtLoaiThuoc.Name = "txtLoaiThuoc";
            this.txtLoaiThuoc.Size = new System.Drawing.Size(221, 23);
            this.txtLoaiThuoc.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Tên Loại Thuốc";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnReload.Controls.Add(this.label12);
            this.btnReload.Controls.Add(this.pictureBox6);
            this.btnReload.Location = new System.Drawing.Point(16, 300);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(100, 33);
            this.btnReload.TabIndex = 82;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(38, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tải lại";
            this.label12.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnHuy.Controls.Add(this.label11);
            this.btnHuy.Controls.Add(this.pictureBox5);
            this.btnHuy.Location = new System.Drawing.Point(228, 300);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 33);
            this.btnHuy.TabIndex = 86;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(46, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Huỷ";
            this.label11.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnLuu.Controls.Add(this.label10);
            this.btnLuu.Controls.Add(this.pictureBox4);
            this.btnLuu.Location = new System.Drawing.Point(122, 300);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 33);
            this.btnLuu.TabIndex = 85;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(46, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Lưu";
            this.label10.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnXoa.Controls.Add(this.label9);
            this.btnXoa.Controls.Add(this.pictureBox3);
            this.btnXoa.Location = new System.Drawing.Point(228, 264);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 84;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(46, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Xoá";
            this.label9.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnSua.Controls.Add(this.label8);
            this.btnSua.Controls.Add(this.pictureBox2);
            this.btnSua.Location = new System.Drawing.Point(122, 264);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 83;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(46, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Sửa";
            this.label8.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnThem.Controls.Add(this.label1);
            this.btnThem.Controls.Add(this.pictureBox1);
            this.btnThem.Location = new System.Drawing.Point(16, 264);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 81;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thêm";
            this.label1.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // MaLoaiThuoc
            // 
            this.MaLoaiThuoc.DataPropertyName = "MaLoaiThuoc";
            this.MaLoaiThuoc.Frozen = true;
            this.MaLoaiThuoc.HeaderText = "Mã Loại Thuốc";
            this.MaLoaiThuoc.Name = "MaLoaiThuoc";
            this.MaLoaiThuoc.Width = 70;
            // 
            // TenLoaiThuoc
            // 
            this.TenLoaiThuoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLoaiThuoc.DataPropertyName = "TenLoaiThuoc";
            this.TenLoaiThuoc.HeaderText = "Tên Loại Thuốc";
            this.TenLoaiThuoc.Name = "TenLoaiThuoc";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.pictureBox6.ErrorImage = null;
            this.pictureBox6.Image = global::QuanLyTramYTe.Properties.Resources.reload;
            this.pictureBox6.Location = new System.Drawing.Point(3, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.pictureBox5.ErrorImage = null;
            this.pictureBox5.Image = global::QuanLyTramYTe.Properties.Resources.huy;
            this.pictureBox5.Location = new System.Drawing.Point(3, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.pictureBox4.ErrorImage = null;
            this.pictureBox4.Image = global::QuanLyTramYTe.Properties.Resources.luu;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = global::QuanLyTramYTe.Properties.Resources.xoa;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::QuanLyTramYTe.Properties.Resources.sua;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::QuanLyTramYTe.Properties.Resources.them;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLoaiThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 347);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvLoaiThuoc);
            this.Controls.Add(this.txtLoaiThuoc);
            this.Controls.Add(this.label2);
            this.Name = "FrmLoaiThuoc";
            this.Text = "FrmLoaiThuoc";
            this.Load += new System.EventHandler(this.FrmLoaiThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiThuoc)).EndInit();
            this.btnReload.ResumeLayout(false);
            this.btnReload.PerformLayout();
            this.btnHuy.ResumeLayout(false);
            this.btnHuy.PerformLayout();
            this.btnLuu.ResumeLayout(false);
            this.btnLuu.PerformLayout();
            this.btnXoa.ResumeLayout(false);
            this.btnXoa.PerformLayout();
            this.btnSua.ResumeLayout(false);
            this.btnSua.PerformLayout();
            this.btnThem.ResumeLayout(false);
            this.btnThem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiThuoc;
        private System.Windows.Forms.TextBox txtLoaiThuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel btnReload;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel btnHuy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel btnLuu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel btnXoa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel btnSua;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiThuoc;
    }
}