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
    public partial class history_pengembalian : Form
    {
        public history_pengembalian()
        {
            InitializeComponent();
            loadgrid();
            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        private void panel_buku_Click(object sender, EventArgs e)
        {
            master_buku master = new master_buku();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_anggota_Click(object sender, EventArgs e)
        {
            master_anggota master = new master_anggota();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_petugas_Click(object sender, EventArgs e)
        {
            master_petugas master = new master_petugas();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_lokasi_Click(object sender, EventArgs e)
        {
            master_lokasi master = new master_lokasi();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_kategori_Click(object sender, EventArgs e)
        {
            master_kategori master = new master_kategori();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_user_Click(object sender, EventArgs e)
        {
            master_user master = new master_user();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_peminjaman_Click(object sender, EventArgs e)
        {
            peminjaman master = new peminjaman();
            this.Hide();
            master.ShowDialog();
        }

        private void panel_pengembalian_Click(object sender, EventArgs e)
        {
            pengembalian master = new pengembalian();
            this.Hide();
            master.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin menutup aplikasi ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        void loadgrid()
        {
            string com = "select buku.*, anggota.nama_lengkap, petugas.nama_petugas, peminjaman_buku.tgl_pinjam, peminjaman_buku.tgl_kembali_riil from peminjaman join peminjaman_buku on peminjaman.id_pinjam = peminjmana_buku.id_pinjam join buku on peminjaman_buku.kode_buku = buku.kode_buku join anggota on peminjaman.id_anggota = anggota.id_anggota join petugas on petugas.id_petugas = peminjaman.id_petugas";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select buku.*, anggota.nama_lengkap, petugas.nama_petugas, peminjaman_buku.tgl_pinjam, peminjaman_buku.tgl_kembali_riil from peminjaman join peminjaman_buku on peminjaman.id_pinjam = peminjmana_buku.id_pinjam join buku on peminjaman_buku.kode_buku = buku.kode_buku join anggota on peminjaman.id_anggota = anggota.id_anggota join petugas on petugas.id_petugas = peminjaman.id_petugas where judul_buku like '%" + textBox1.Text +"%'";
            dataGridView1.DataSource = Command.getdata(com);

        }
    }
}
