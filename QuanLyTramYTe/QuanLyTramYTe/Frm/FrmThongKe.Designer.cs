namespace QuanLyTramYTe.Frm
{
    partial class FrmThongKe
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.btnLocDuLieu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateKT = new System.Windows.Forms.DateTimePicker();
            this.dateBD = new System.Windows.Forms.DateTimePicker();
            this.dgvDuLieu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 24);
            this.label4.TabIndex = 85;
            this.label4.Text = "DOANH THU ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 353);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 84;
            this.label3.Text = "Tổng Doanh Thu";
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Enabled = false;
            this.txtDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoanhThu.Location = new System.Drawing.Point(31, 373);
            this.txtDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(235, 22);
            this.txtDoanhThu.TabIndex = 83;
            this.txtDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLocDuLieu
            // 
            this.btnLocDuLieu.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLocDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLocDuLieu.Location = new System.Drawing.Point(79, 117);
            this.btnLocDuLieu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocDuLieu.Name = "btnLocDuLieu";
            this.btnLocDuLieu.Size = new System.Drawing.Size(131, 34);
            this.btnLocDuLieu.TabIndex = 82;
            this.btnLocDuLieu.Text = "Lọc Dữ Liệu";
            this.btnLocDuLieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLocDuLieu.UseVisualStyleBackColor = false;
            this.btnLocDuLieu.Click += new System.EventHandler(this.btnLocDuLieu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 80;
            this.label1.Text = "Từ ngày:";
            // 
            // dateKT
            // 
            this.dateKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateKT.Location = new System.Drawing.Point(130, 87);
            this.dateKT.Margin = new System.Windows.Forms.Padding(4);
            this.dateKT.Name = "dateKT";
            this.dateKT.Size = new System.Drawing.Size(129, 22);
            this.dateKT.TabIndex = 79;
            // 
            // dateBD
            // 
            this.dateBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBD.Location = new System.Drawing.Point(130, 48);
            this.dateBD.Margin = new System.Windows.Forms.Padding(4);
            this.dateBD.Name = "dateBD";
            this.dateBD.Size = new System.Drawing.Size(129, 22);
            this.dateBD.TabIndex = 78;
            // 
            // dgvDuLieu
            // 
            this.dgvDuLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuLieu.Location = new System.Drawing.Point(26, 159);
            this.dgvDuLieu.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDuLieu.Name = "dgvDuLieu";
            this.dgvDuLieu.Size = new System.Drawing.Size(243, 173);
            this.dgvDuLieu.TabIndex = 77;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 416);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.btnLocDuLieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateKT);
            this.Controls.Add(this.dateBD);
            this.Controls.Add(this.dgvDuLieu);
            this.Name = "FrmThongKe";
            this.Text = "FrmThongKe";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.Button btnLocDuLieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateKT;
        private System.Windows.Forms.DateTimePicker dateBD;
        private System.Windows.Forms.DataGridView dgvDuLieu;
    }
}