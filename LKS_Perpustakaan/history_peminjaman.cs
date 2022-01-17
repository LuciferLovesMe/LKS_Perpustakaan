using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Perpustakaan
{
    public partial class history_peminjaman : Form
    {
        public history_peminjaman()
        {
            InitializeComponent();
            loadgrid();
            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        private void panel_cari_Click(object sender, EventArgs e)
        {
            cari_buku cari = new cari_buku();
            this.Hide();
            cari.ShowDialog();
        }

        private void panel_history_Click(object sender, EventArgs e)
        {
            history history = new history();
            this.Hide();
            history.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin menutup aplikasi ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin untuk Logout ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MainLogin master = new MainLogin();
                this.Hide();
                master.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select buku.*, peminjaman_buku.tgl_pinjam, peminjaman_buku.tgl_kembali_riil from buku join peminjaman_buku on buku.kode_buku = peminjman_buku.kode_buku join peminjman on peminjaman_buku.id_pinjam = peminjaman.id_pinjam where tgl_kembali_riil is no null and peminjaman.id_anggota = " + Model.id + " and judul = '" + textBox1.Text + "'";
            dataGridView1.DataSource = Command.getdata(sql);
        }

        void loadgrid()
        {
            string sql = "select buku.*, peminjaman_buku.tgl_pinjam, peminjaman_buku.tgl_kembali_riil from buku join peminjaman_buku on buku.kode_buku = peminjman_buku.kode_buku join peminjman on peminjaman_buku.id_pinjam = peminjaman.id_pinjam where tgl_kembali_riil is no null and peminjaman.id_anggota = " + Model.id;
            dataGridView1.DataSource = Command.getdata(sql);

        }
    }
}
