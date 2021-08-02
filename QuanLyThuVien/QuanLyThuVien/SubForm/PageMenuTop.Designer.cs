namespace QuanLyThuVien.SubForm
{
    partial class PageMenuTop
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenuSubTheLoai = new System.Windows.Forms.Button();
            this.btnMenuSubSach = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.subTheLoai1 = new QuanLyThuVien.SubForm.SubTheLoai();
            this.subSach1 = new QuanLyThuVien.SubForm.SubSach();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnMenuSubTheLoai);
            this.panel1.Controls.Add(this.btnMenuSubSach);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 35);
            this.panel1.TabIndex = 1;
            // 
            // btnMenuSubTheLoai
            // 
            this.btnMenuSubTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.btnMenuSubTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuSubTheLoai.FlatAppearance.BorderSize = 0;
            this.btnMenuSubTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSubTheLoai.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSubTheLoai.ForeColor = System.Drawing.Color.White;
            this.btnMenuSubTheLoai.Location = new System.Drawing.Point(75, 0);
            this.btnMenuSubTheLoai.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuSubTheLoai.Name = "btnMenuSubTheLoai";
            this.btnMenuSubTheLoai.Size = new System.Drawing.Size(133, 35);
            this.btnMenuSubTheLoai.TabIndex = 1;
            this.btnMenuSubTheLoai.Text = "Thể loại sách";
            this.btnMenuSubTheLoai.UseVisualStyleBackColor = false;
            this.btnMenuSubTheLoai.Click += new System.EventHandler(this.btnMenuSubTheLoai_Click);
            // 
            // btnMenuSubSach
            // 
            this.btnMenuSubSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.btnMenuSubSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuSubSach.FlatAppearance.BorderSize = 0;
            this.btnMenuSubSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSubSach.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSubSach.ForeColor = System.Drawing.Color.White;
            this.btnMenuSubSach.Location = new System.Drawing.Point(0, 0);
            this.btnMenuSubSach.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenuSubSach.Name = "btnMenuSubSach";
            this.btnMenuSubSach.Size = new System.Drawing.Size(75, 35);
            this.btnMenuSubSach.TabIndex = 0;
            this.btnMenuSubSach.Text = "Sách";
            this.btnMenuSubSach.UseVisualStyleBackColor = false;
            this.btnMenuSubSach.Click += new System.EventHandler(this.btnMenuSubSach_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.subTheLoai1);
            this.panel2.Controls.Add(this.subSach1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 597);
            this.panel2.TabIndex = 2;
            // 
            // subTheLoai1
            // 
            this.subTheLoai1.BackColor = System.Drawing.Color.White;
            this.subTheLoai1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subTheLoai1.Location = new System.Drawing.Point(0, 0);
            this.subTheLoai1.Margin = new System.Windows.Forms.Padding(0);
            this.subTheLoai1.Name = "subTheLoai1";
            this.subTheLoai1.Size = new System.Drawing.Size(932, 597);
            this.subTheLoai1.TabIndex = 1;
            // 
            // subSach1
            // 
            this.subSach1.BackColor = System.Drawing.Color.White;
            this.subSach1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subSach1.Location = new System.Drawing.Point(0, 0);
            this.subSach1.Margin = new System.Windows.Forms.Padding(0);
            this.subSach1.Name = "subSach1";
            this.subSach1.Size = new System.Drawing.Size(932, 597);
            this.subSach1.TabIndex = 0;
            // 
            // PageMenuTop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PageMenuTop";
            this.Size = new System.Drawing.Size(932, 632);
            this.Load += new System.EventHandler(this.PageSach_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMenuSubSach;
        private SubTheLoai subTheLoai1;
        private SubSach subSach1;
        private System.Windows.Forms.Button btnMenuSubTheLoai;

    }
}
