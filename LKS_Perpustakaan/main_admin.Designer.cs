
namespace LKS_Perpustakaan
{
    partial class main_admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbladmin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_pengembalian = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel_peminjaman = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel_user = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel_kategori = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel_lokasi = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_petugas = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_anggota = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_buku = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lbltime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_pengembalian.SuspendLayout();
            this.panel_peminjaman.SuspendLayout();
            this.panel_user.SuspendLayout();
            this.panel_kategori.SuspendLayout();
            this.panel_lokasi.SuspendLayout();
            this.panel_petugas.SuspendLayout();
            this.panel_anggota.SuspendLayout();
            this.panel_buku.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(42)))), ((int)(((byte)(137)))));
            this.panel1.Controls.Add(this.lbladmin);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel_pengembalian);
            this.panel1.Controls.Add(this.panel_peminjaman);
            this.panel1.Controls.Add(this.panel_user);
            this.panel1.Controls.Add(this.panel_kategori);
            this.panel1.Controls.Add(this.panel_lokasi);
            this.panel1.Controls.Add(this.panel_petugas);
            this.panel1.Controls.Add(this.panel_anggota);
            this.panel1.Controls.Add(this.panel_buku);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 703);
            this.panel1.TabIndex = 0;
            // 
            // lbladmin
            // 
            this.lbladmin.AutoSize = true;
            this.lbladmin.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmin.ForeColor = System.Drawing.Color.White;
            this.lbladmin.Location = new System.Drawing.Point(4, 13);
            this.lbladmin.Name = "lbladmin";
            this.lbladmin.Size = new System.Drawing.Size(72, 24);
            this.lbladmin.TabIndex = 10;
            this.lbladmin.Text = "ADMIN";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 649);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_pengembalian
            // 
            this.panel_pengembalian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_pengembalian.Controls.Add(this.label15);
            this.panel_pengembalian.Controls.Add(this.label16);
            this.panel_pengembalian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_pengembalian.Location = new System.Drawing.Point(0, 558);
            this.panel_pengembalian.Name = "panel_pengembalian";
            this.panel_pengembalian.Size = new System.Drawing.Size(243, 65);
            this.panel_pengembalian.TabIndex = 8;
            this.panel_pengembalian.Click += new System.EventHandler(this.panel_pengembalian_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(69, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 25);
            this.label15.TabIndex = 1;
            this.label15.Text = "Pengembalian";
            this.label15.Click += new System.EventHandler(this.panel_pengembalian_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Webdings", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label16.Location = new System.Drawing.Point(3, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 49);
            this.label16.TabIndex = 0;
            this.label16.Text = "";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.Click += new System.EventHandler(this.panel_pengembalian_Click);
            // 
            // panel_peminjaman
            // 
            this.panel_peminjaman.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_peminjaman.Controls.Add(this.label13);
            this.panel_peminjaman.Controls.Add(this.label14);
            this.panel_peminjaman.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_peminjaman.Location = new System.Drawing.Point(0, 487);
            this.panel_peminjaman.Name = "panel_peminjaman";
            this.panel_peminjaman.Size = new System.Drawing.Size(243, 65);
            this.panel_peminjaman.TabIndex = 7;
            this.panel_peminjaman.Click += new System.EventHandler(this.panel_peminjaman_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(69, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 29);
            this.label13.TabIndex = 1;
            this.label13.Text = "Peminjaman";
            this.label13.Click += new System.EventHandler(this.panel_peminjaman_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Webdings", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label14.Location = new System.Drawing.Point(3, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 49);
            this.label14.TabIndex = 0;
            this.label14.Text = "";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Click += new System.EventHandler(this.panel_peminjaman_Click);
            // 
            // panel_user
            // 
            this.panel_user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_user.Controls.Add(this.label11);
            this.panel_user.Controls.Add(this.label12);
            this.panel_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_user.Location = new System.Drawing.Point(0, 416);
            this.panel_user.Name = "panel_user";
            this.panel_user.Size = new System.Drawing.Size(243, 65);
            this.panel_user.TabIndex = 6;
            this.panel_user.Click += new System.EventHandler(this.panel_user_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(91, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 29);
            this.label11.TabIndex = 1;
            this.label11.Text = "User";
            this.label11.Click += new System.EventHandler(this.panel_user_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label12.Location = new System.Drawing.Point(3, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 48);
            this.label12.TabIndex = 0;
            this.label12.Text = "";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Click += new System.EventHandler(this.panel_user_Click);
            // 
            // panel_kategori
            // 
            this.panel_kategori.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_kategori.Controls.Add(this.label9);
            this.panel_kategori.Controls.Add(this.label10);
            this.panel_kategori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_kategori.Location = new System.Drawing.Point(0, 345);
            this.panel_kategori.Name = "panel_kategori";
            this.panel_kategori.Size = new System.Drawing.Size(243, 65);
            this.panel_kategori.TabIndex = 5;
            this.panel_kategori.Click += new System.EventHandler(this.panel_kategori_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(91, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 29);
            this.label9.TabIndex = 1;
            this.label9.Text = "Kategori";
            this.label9.Click += new System.EventHandler(this.panel_kategori_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 48);
            this.label10.TabIndex = 0;
            this.label10.Text = "";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.panel_kategori_Click);
            // 
            // panel_lokasi
            // 
            this.panel_lokasi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_lokasi.Controls.Add(this.label7);
            this.panel_lokasi.Controls.Add(this.label8);
            this.panel_lokasi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_lokasi.Location = new System.Drawing.Point(0, 274);
            this.panel_lokasi.Name = "panel_lokasi";
            this.panel_lokasi.Size = new System.Drawing.Size(243, 65);
            this.panel_lokasi.TabIndex = 4;
            this.panel_lokasi.Click += new System.EventHandler(this.panel_lokasi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(91, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 29);
            this.label7.TabIndex = 1;
            this.label7.Text = "Lokasi";
            this.label7.Click += new System.EventHandler(this.panel_lokasi_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 48);
            this.label8.TabIndex = 0;
            this.label8.Text = "";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.panel_lokasi_Click);
            // 
            // panel_petugas
            // 
            this.panel_petugas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_petugas.Controls.Add(this.label5);
            this.panel_petugas.Controls.Add(this.label6);
            this.panel_petugas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_petugas.Location = new System.Drawing.Point(0, 203);
            this.panel_petugas.Name = "panel_petugas";
            this.panel_petugas.Size = new System.Drawing.Size(243, 65);
            this.panel_petugas.TabIndex = 3;
            this.panel_petugas.Click += new System.EventHandler(this.panel_petugas_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(91, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "Petugas";
            this.label5.Click += new System.EventHandler(this.panel_petugas_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 48);
            this.label6.TabIndex = 0;
            this.label6.Text = "";
            this.label6.Click += new System.EventHandler(this.panel_petugas_Click);
            // 
            // panel_anggota
            // 
            this.panel_anggota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_anggota.Controls.Add(this.label3);
            this.panel_anggota.Controls.Add(this.label4);
            this.panel_anggota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_anggota.Location = new System.Drawing.Point(0, 132);
            this.panel_anggota.Name = "panel_anggota";
            this.panel_anggota.Size = new System.Drawing.Size(243, 65);
            this.panel_anggota.TabIndex = 2;
            this.panel_anggota.Click += new System.EventHandler(this.panel_anggota_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(91, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Anggota";
            this.label3.Click += new System.EventHandler(this.panel_anggota_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 48);
            this.label4.TabIndex = 0;
            this.label4.Text = "";
            this.label4.Click += new System.EventHandler(this.panel_anggota_Click);
            // 
            // panel_buku
            // 
            this.panel_buku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(44)))), ((int)(((byte)(153)))));
            this.panel_buku.Controls.Add(this.label2);
            this.panel_buku.Controls.Add(this.label1);
            this.panel_buku.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_buku.Location = new System.Drawing.Point(0, 61);
            this.panel_buku.Name = "panel_buku";
            this.panel_buku.Size = new System.Drawing.Size(243, 65);
            this.panel_buku.TabIndex = 0;
            this.panel_buku.Click += new System.EventHandler(this.panel_buku_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(91, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buku";
            this.label2.Click += new System.EventHandler(this.panel_buku_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(235)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "";
            this.label1.Click += new System.EventHandler(this.panel_buku_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1101, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.Black;
            this.lbltime.Location = new System.Drawing.Point(249, 9);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(55, 18);
            this.lbltime.TabIndex = 11;
            this.lbltime.Text = "ADMIN";
            // 
            // main_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main_admin";
            this.Text = "MainAnggota";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_pengembalian.ResumeLayout(false);
            this.panel_pengembalian.PerformLayout();
            this.panel_peminjaman.ResumeLayout(false);
            this.panel_peminjaman.PerformLayout();
            this.panel_user.ResumeLayout(false);
            this.panel_user.PerformLayout();
            this.panel_kategori.ResumeLayout(false);
            this.panel_kategori.PerformLayout();
            this.panel_lokasi.ResumeLayout(false);
            this.panel_lokasi.PerformLayout();
            this.panel_petugas.ResumeLayout(false);
            this.panel_petugas.PerformLayout();
            this.panel_anggota.ResumeLayout(false);
            this.panel_anggota.PerformLayout();
            this.panel_buku.ResumeLayout(false);
            this.panel_buku.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbladmin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_pengembalian;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel_peminjaman;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel_user;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel_kategori;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel_lokasi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel_petugas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_anggota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_buku;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbltime;
    }
}