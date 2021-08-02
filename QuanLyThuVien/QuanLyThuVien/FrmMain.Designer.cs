namespace QuanLyThuVien
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnMenuSach = new System.Windows.Forms.Button();
            this.btnMenuDocGia = new System.Windows.Forms.Button();
            this.btnMuonTra = new System.Windows.Forms.Button();
            this.btnMenuThongKe = new System.Windows.Forms.Button();
            this.btnMenuTaiKhoan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pageThongKe1 = new QuanLyThuVien.SubForm.PageThongKe();
            this.pageTaiKhoan1 = new QuanLyThuVien.SubForm.PageTaiKhoan();
            this.pageMuonTra1 = new QuanLyThuVien.SubForm.PageMuonTra();
            this.pageDocGia1 = new QuanLyThuVien.SubForm.PageDocGia();
            this.pageSach1 = new QuanLyThuVien.SubForm.PageMenuTop();
            this.pnContainer.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnContainer
            // 
            this.pnContainer.BackColor = System.Drawing.Color.White;
            this.pnContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnContainer.Controls.Add(this.pnContent);
            this.pnContainer.Controls.Add(this.pnMenu);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(1149, 646);
            this.pnContainer.TabIndex = 0;
            // 
            // pnContent
            // 
            this.pnContent.BackColor = System.Drawing.Color.White;
            this.pnContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnContent.Controls.Add(this.pageThongKe1);
            this.pnContent.Controls.Add(this.pageTaiKhoan1);
            this.pnContent.Controls.Add(this.pageMuonTra1);
            this.pnContent.Controls.Add(this.pageDocGia1);
            this.pnContent.Controls.Add(this.pageSach1);
            this.pnContent.Location = new System.Drawing.Point(207, 7);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(932, 632);
            this.pnContent.TabIndex = 1;
            // 
            // pnMenu
            // 
            this.pnMenu.AutoSize = true;
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.pnMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMenu.Controls.Add(this.pictureBox1);
            this.pnMenu.Controls.Add(this.btnMenuSach);
            this.pnMenu.Controls.Add(this.btnMenuDocGia);
            this.pnMenu.Controls.Add(this.btnMuonTra);
            this.pnMenu.Controls.Add(this.btnMenuThongKe);
            this.pnMenu.Controls.Add(this.btnMenuTaiKhoan);
            this.pnMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnMenu.Location = new System.Drawing.Point(7, 7);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(192, 632);
            this.pnMenu.TabIndex = 0;
            // 
            // btnMenuSach
            // 
            this.btnMenuSach.AutoSize = true;
            this.btnMenuSach.BackColor = System.Drawing.Color.White;
            this.btnMenuSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuSach.FlatAppearance.BorderSize = 2;
            this.btnMenuSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMenuSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSach.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSach.Image = global::QuanLyThuVien.Properties.Resources.sach;
            this.btnMenuSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuSach.Location = new System.Drawing.Point(9, 209);
            this.btnMenuSach.Margin = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.btnMenuSach.Name = "btnMenuSach";
            this.btnMenuSach.Padding = new System.Windows.Forms.Padding(20, 2, 25, 2);
            this.btnMenuSach.Size = new System.Drawing.Size(173, 78);
            this.btnMenuSach.TabIndex = 0;
            this.btnMenuSach.Text = "SÁCH";
            this.btnMenuSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuSach.UseVisualStyleBackColor = false;
            this.btnMenuSach.Click += new System.EventHandler(this.btnMenuSach_Click);
            // 
            // btnMenuDocGia
            // 
            this.btnMenuDocGia.AutoSize = true;
            this.btnMenuDocGia.BackColor = System.Drawing.Color.White;
            this.btnMenuDocGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuDocGia.FlatAppearance.BorderSize = 2;
            this.btnMenuDocGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuDocGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMenuDocGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDocGia.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuDocGia.Image = global::QuanLyThuVien.Properties.Resources.docGia;
            this.btnMenuDocGia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDocGia.Location = new System.Drawing.Point(9, 292);
            this.btnMenuDocGia.Margin = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.btnMenuDocGia.Name = "btnMenuDocGia";
            this.btnMenuDocGia.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.btnMenuDocGia.Size = new System.Drawing.Size(173, 78);
            this.btnMenuDocGia.TabIndex = 0;
            this.btnMenuDocGia.Text = "ĐỘC GIẢ";
            this.btnMenuDocGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuDocGia.UseVisualStyleBackColor = false;
            this.btnMenuDocGia.Click += new System.EventHandler(this.btnMenuDocGia_Click);
            // 
            // btnMuonTra
            // 
            this.btnMuonTra.AutoSize = true;
            this.btnMuonTra.BackColor = System.Drawing.Color.White;
            this.btnMuonTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuonTra.FlatAppearance.BorderSize = 2;
            this.btnMuonTra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMuonTra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMuonTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuonTra.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuonTra.Image = global::QuanLyThuVien.Properties.Resources.muonTraSach;
            this.btnMuonTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonTra.Location = new System.Drawing.Point(8, 375);
            this.btnMuonTra.Margin = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.btnMuonTra.Name = "btnMuonTra";
            this.btnMuonTra.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.btnMuonTra.Size = new System.Drawing.Size(173, 78);
            this.btnMuonTra.TabIndex = 0;
            this.btnMuonTra.Text = "MƯỢN/TRẢ";
            this.btnMuonTra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMuonTra.UseVisualStyleBackColor = false;
            this.btnMuonTra.Click += new System.EventHandler(this.btnMuonTra_Click);
            // 
            // btnMenuThongKe
            // 
            this.btnMenuThongKe.AutoSize = true;
            this.btnMenuThongKe.BackColor = System.Drawing.Color.White;
            this.btnMenuThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuThongKe.FlatAppearance.BorderSize = 2;
            this.btnMenuThongKe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuThongKe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMenuThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuThongKe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuThongKe.Image = global::QuanLyThuVien.Properties.Resources.thongke;
            this.btnMenuThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuThongKe.Location = new System.Drawing.Point(8, 458);
            this.btnMenuThongKe.Margin = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.btnMenuThongKe.Name = "btnMenuThongKe";
            this.btnMenuThongKe.Padding = new System.Windows.Forms.Padding(6, 2, 1, 2);
            this.btnMenuThongKe.Size = new System.Drawing.Size(173, 78);
            this.btnMenuThongKe.TabIndex = 0;
            this.btnMenuThongKe.Text = "THỐNG KÊ";
            this.btnMenuThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuThongKe.UseVisualStyleBackColor = false;
            this.btnMenuThongKe.Click += new System.EventHandler(this.btnMenuThongKe_Click);
            // 
            // btnMenuTaiKhoan
            // 
            this.btnMenuTaiKhoan.AutoSize = true;
            this.btnMenuTaiKhoan.BackColor = System.Drawing.Color.White;
            this.btnMenuTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuTaiKhoan.FlatAppearance.BorderSize = 2;
            this.btnMenuTaiKhoan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuTaiKhoan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnMenuTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTaiKhoan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTaiKhoan.Image = global::QuanLyThuVien.Properties.Resources.account;
            this.btnMenuTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTaiKhoan.Location = new System.Drawing.Point(9, 541);
            this.btnMenuTaiKhoan.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnMenuTaiKhoan.Name = "btnMenuTaiKhoan";
            this.btnMenuTaiKhoan.Padding = new System.Windows.Forms.Padding(4, 2, 1, 2);
            this.btnMenuTaiKhoan.Size = new System.Drawing.Size(173, 78);
            this.btnMenuTaiKhoan.TabIndex = 0;
            this.btnMenuTaiKhoan.Text = "TÀI KHOẢN";
            this.btnMenuTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuTaiKhoan.UseVisualStyleBackColor = false;
            this.btnMenuTaiKhoan.Click += new System.EventHandler(this.btnMenuTaiKhoan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 204);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pageThongKe1
            // 
            this.pageThongKe1.BackColor = System.Drawing.Color.White;
            this.pageThongKe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageThongKe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageThongKe1.Location = new System.Drawing.Point(0, 0);
            this.pageThongKe1.Margin = new System.Windows.Forms.Padding(0);
            this.pageThongKe1.Name = "pageThongKe1";
            this.pageThongKe1.Size = new System.Drawing.Size(930, 630);
            this.pageThongKe1.TabIndex = 4;
            // 
            // pageTaiKhoan1
            // 
            this.pageTaiKhoan1.BackColor = System.Drawing.Color.White;
            this.pageTaiKhoan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageTaiKhoan1.Location = new System.Drawing.Point(0, 0);
            this.pageTaiKhoan1.Margin = new System.Windows.Forms.Padding(4);
            this.pageTaiKhoan1.Name = "pageTaiKhoan1";
            this.pageTaiKhoan1.Size = new System.Drawing.Size(930, 630);
            this.pageTaiKhoan1.TabIndex = 3;
            // 
            // pageMuonTra1
            // 
            this.pageMuonTra1.BackColor = System.Drawing.Color.White;
            this.pageMuonTra1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageMuonTra1.Location = new System.Drawing.Point(0, 0);
            this.pageMuonTra1.Margin = new System.Windows.Forms.Padding(0);
            this.pageMuonTra1.Name = "pageMuonTra1";
            this.pageMuonTra1.Size = new System.Drawing.Size(930, 630);
            this.pageMuonTra1.TabIndex = 2;
            // 
            // pageDocGia1
            // 
            this.pageDocGia1.BackColor = System.Drawing.Color.White;
            this.pageDocGia1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDocGia1.Location = new System.Drawing.Point(0, 0);
            this.pageDocGia1.Margin = new System.Windows.Forms.Padding(0);
            this.pageDocGia1.Name = "pageDocGia1";
            this.pageDocGia1.Size = new System.Drawing.Size(930, 630);
            this.pageDocGia1.TabIndex = 1;
            // 
            // pageSach1
            // 
            this.pageSach1.BackColor = System.Drawing.Color.White;
            this.pageSach1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageSach1.Location = new System.Drawing.Point(0, 0);
            this.pageSach1.Margin = new System.Windows.Forms.Padding(0);
            this.pageSach1.Name = "pageSach1";
            this.pageSach1.Size = new System.Drawing.Size(930, 630);
            this.pageSach1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 646);
            this.Controls.Add(this.pnContainer);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnContainer.ResumeLayout(false);
            this.pnContainer.PerformLayout();
            this.pnContent.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Button btnMenuTaiKhoan;
        private System.Windows.Forms.Button btnMenuSach;
        private System.Windows.Forms.Button btnMenuDocGia;
        private System.Windows.Forms.Button btnMuonTra;
        private System.Windows.Forms.Button btnMenuThongKe;
        private SubForm.PageTaiKhoan pageTaiKhoan1;
        private SubForm.PageMuonTra pageMuonTra1;
        private SubForm.PageDocGia pageDocGia1;
        private SubForm.PageMenuTop pageSach1;
        private SubForm.PageThongKe pageThongKe1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

