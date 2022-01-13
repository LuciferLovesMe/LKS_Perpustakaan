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
    public partial class peminjaman : Form
    {
        public peminjaman()
        {
            InitializeComponent();
            loadgrid();
            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        void loadgrid()
        {
            string com = "select * from peminjaman join petugas on peminjaman.id_petugas = petugas.id_petugas join anggota on peminjaman.id_anggota = anggota.id_anggota";
            dataGridView1.DataSource = Command.getdata(com);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select * from peminjaman join petugas on peminjaman.id_petugas = petugas.id_petugas join anggota on peminjaman.id_anggota = anggota.id_anggota where nama_petugas like '%" + textBox1.Text + "%' or nama_lengkap like '%" + textBox1.Text + "%' ";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tambah_peminjaman tambah = new tambah_peminjaman();
            this.Hide();
            tambah.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            Selected.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                detail_peminjaman detail = new detail_peminjaman();
                this.Hide();
                detail.ShowDialog();
            }
        }
    }
}
