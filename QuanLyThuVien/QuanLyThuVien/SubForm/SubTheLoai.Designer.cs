namespace QuanLyThuVien.SubForm
{
    partial class SubTheLoai
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubTheLoai));
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dtgvTheLoaiSach = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.txtTenTheLoai = new System.Windows.Forms.TextBox();
            this.pnTheLoaiSach = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnXoaTheLoai = new System.Windows.Forms.Button();
            this.btnSuaTheLoai = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnThemTheLoai = new System.Windows.Forms.Button();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTheLoaiSach)).BeginInit();
            this.pnTheLoaiSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 26);
            this.button1.Size = new System.Drawing.Size(99, 90);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(216)))), ((int)(((byte)(192)))));
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(2, 65);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 28);
            this.button7.TabIndex = 5;
            this.button7.Text = "Thể loại sách";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // dtgvTheLoaiSach
            // 
            this.dtgvTheLoaiSach.AllowUserToResizeColumns = false;
            this.dtgvTheLoaiSach.AllowUserToResizeRows = false;
            this.dtgvTheLoaiSach.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dtgvTheLoaiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTheLoaiSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dtgvTheLoaiSach.Location = new System.Drawing.Point(138, 2);
            this.dtgvTheLoaiSach.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvTheLoaiSach.MultiSelect = false;
            this.dtgvTheLoaiSach.Name = "dtgvTheLoaiSach";
            this.dtgvTheLoaiSach.RowHeadersVisible = false;
            this.dtgvTheLoaiSach.RowTemplate.Height = 24;
            this.dtgvTheLoaiSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvTheLoaiSach.Size = new System.Drawing.Size(746, 322);
            this.dtgvTheLoaiSach.TabIndex = 6;
            this.dtgvTheLoaiSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTheLoaiSach_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "MALOAI";
            this.Column1.HeaderText = "Mã loại";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "TENLOAI";
            this.Column2.HeaderText = "Tên thể loại";
            this.Column2.Name = "Column2";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTimKiem.FlatAppearance.BorderSize = 2;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(751, 15);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(61, 29);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(96, 15);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(643, 27);
            this.txtTimKiem.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã loại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên thể loại sách:";
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Enabled = false;
            this.txtMaLoai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoai.Location = new System.Drawing.Point(230, 61);
            this.txtMaLoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(215, 26);
            this.txtMaLoai.TabIndex = 1;
            // 
            // txtTenTheLoai
            // 
            this.txtTenTheLoai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTheLoai.Location = new System.Drawing.Point(230, 104);
            this.txtTenTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenTheLoai.Name = "txtTenTheLoai";
            this.txtTenTheLoai.Size = new System.Drawing.Size(215, 26);
            this.txtTenTheLoai.TabIndex = 1;
            // 
            // pnTheLoaiSach
            // 
            this.pnTheLoaiSach.BackColor = System.Drawing.Color.White;
            this.pnTheLoaiSach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnTheLoaiSach.Controls.Add(this.btnBrowse);
            this.pnTheLoaiSach.Controls.Add(this.btnXoaTheLoai);
            this.pnTheLoaiSach.Controls.Add(this.btnSuaTheLoai);
            this.pnTheLoaiSach.Controls.Add(this.txtTimKiem);
            this.pnTheLoaiSach.Controls.Add(this.btnTimKiem);
            this.pnTheLoaiSach.Controls.Add(this.btnExportExcel);
            this.pnTheLoaiSach.Controls.Add(this.btnImportExcel);
            this.pnTheLoaiSach.Controls.Add(this.btnThemTheLoai);
            this.pnTheLoaiSach.Controls.Add(this.txtBrowse);
            this.pnTheLoaiSach.Controls.Add(this.txtTenTheLoai);
            this.pnTheLoaiSach.Controls.Add(this.txtMaLoai);
            this.pnTheLoaiSach.Controls.Add(this.label2);
            this.pnTheLoaiSach.Controls.Add(this.label1);
            this.pnTheLoaiSach.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnTheLoaiSach.Location = new System.Drawing.Point(40, 328);
            this.pnTheLoaiSach.Margin = new System.Windows.Forms.Padding(2);
            this.pnTheLoaiSach.Name = "pnTheLoaiSach";
            this.pnTheLoaiSach.Size = new System.Drawing.Size(844, 253);
            this.pnTheLoaiSach.TabIndex = 10;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(138, 145);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 36);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnXoaTheLoai
            // 
            this.btnXoaTheLoai.BackColor = System.Drawing.Color.LightGray;
            this.btnXoaTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTheLoai.Enabled = false;
            this.btnXoaTheLoai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnXoaTheLoai.FlatAppearance.BorderSize = 0;
            this.btnXoaTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTheLoai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTheLoai.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaTheLoai.Image")));
            this.btnXoaTheLoai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaTheLoai.Location = new System.Drawing.Point(573, 123);
            this.btnXoaTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaTheLoai.Name = "btnXoaTheLoai";
            this.btnXoaTheLoai.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnXoaTheLoai.Size = new System.Drawing.Size(175, 37);
            this.btnXoaTheLoai.TabIndex = 4;
            this.btnXoaTheLoai.Text = "Xóa thể loại sách";
            this.btnXoaTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaTheLoai.UseVisualStyleBackColor = false;
            this.btnXoaTheLoai.EnabledChanged += new System.EventHandler(this.btnImportExcel_EnabledChanged);
            this.btnXoaTheLoai.Click += new System.EventHandler(this.btnXoaTheLoai_Click);
            // 
            // btnSuaTheLoai
            // 
            this.btnSuaTheLoai.BackColor = System.Drawing.Color.LightGray;
            this.btnSuaTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaTheLoai.Enabled = false;
            this.btnSuaTheLoai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSuaTheLoai.FlatAppearance.BorderSize = 0;
            this.btnSuaTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTheLoai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaTheLoai.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaTheLoai.Image")));
            this.btnSuaTheLoai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaTheLoai.Location = new System.Drawing.Point(573, 179);
            this.btnSuaTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuaTheLoai.Name = "btnSuaTheLoai";
            this.btnSuaTheLoai.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSuaTheLoai.Size = new System.Drawing.Size(175, 37);
            this.btnSuaTheLoai.TabIndex = 4;
            this.btnSuaTheLoai.Text = "Sửa thể loại sách";
            this.btnSuaTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaTheLoai.UseVisualStyleBackColor = false;
            this.btnSuaTheLoai.EnabledChanged += new System.EventHandler(this.btnImportExcel_EnabledChanged);
            this.btnSuaTheLoai.Click += new System.EventHandler(this.btnSuaTheLoai_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.Black;
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(347, 200);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnExportExcel.Size = new System.Drawing.Size(148, 37);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Xuất file Excel";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackColor = System.Drawing.Color.LightGray;
            this.btnImportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExcel.Enabled = false;
            this.btnImportExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnImportExcel.Image")));
            this.btnImportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportExcel.Location = new System.Drawing.Point(141, 200);
            this.btnImportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(173, 37);
            this.btnImportExcel.TabIndex = 4;
            this.btnImportExcel.Text = "Nhập từ file Excel";
            this.btnImportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.EnabledChanged += new System.EventHandler(this.btnImportExcel_EnabledChanged);
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnThemTheLoai
            // 
            this.btnThemTheLoai.BackColor = System.Drawing.Color.Black;
            this.btnThemTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemTheLoai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThemTheLoai.FlatAppearance.BorderSize = 0;
            this.btnThemTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTheLoai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTheLoai.ForeColor = System.Drawing.Color.White;
            this.btnThemTheLoai.Image = ((System.Drawing.Image)(resources.GetObject("btnThemTheLoai.Image")));
            this.btnThemTheLoai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemTheLoai.Location = new System.Drawing.Point(573, 69);
            this.btnThemTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemTheLoai.Name = "btnThemTheLoai";
            this.btnThemTheLoai.Size = new System.Drawing.Size(175, 37);
            this.btnThemTheLoai.TabIndex = 4;
            this.btnThemTheLoai.Text = "Thêm thể loại sách";
            this.btnThemTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemTheLoai.UseVisualStyleBackColor = false;
            this.btnThemTheLoai.Click += new System.EventHandler(this.btnThemTheLoai_Click);
            // 
            // txtBrowse
            // 
            this.txtBrowse.Enabled = false;
            this.txtBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrowse.Location = new System.Drawing.Point(230, 153);
            this.txtBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.Size = new System.Drawing.Size(300, 23);
            this.txtBrowse.TabIndex = 1;
            this.txtBrowse.TextChanged += new System.EventHandler(this.txtBrowse_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRefresh.FlatAppearance.BorderSize = 2;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(31, 287);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnRefresh.Size = new System.Drawing.Size(103, 37);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SubTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnTheLoaiSach);
            this.Controls.Add(this.dtgvTheLoaiSach);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubTheLoai";
            this.Size = new System.Drawing.Size(932, 597);
            this.Load += new System.EventHandler(this.SubTheLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTheLoaiSach)).EndInit();
            this.pnTheLoaiSach.ResumeLayout(false);
            this.pnTheLoaiSach.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.TextBox txtTenTheLoai;
        private System.Windows.Forms.Panel pnTheLoaiSach;
        private System.Windows.Forms.Button btnThemTheLoai;
        private System.Windows.Forms.Button btnXoaTheLoai;
        private System.Windows.Forms.Button btnSuaTheLoai;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.DataGridView dtgvTheLoaiSach;

    }
}
