using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Perpustakaan
{
    public partial class pengembalian : Form
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        int denda, id;
        string code;

        public pengembalian()
        {
            InitializeComponent();
            loadgrid();
            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        void loadgrid()
        {
            string com = "select * from peminjaman join anggota on peminjaman.id_anggota = anggota.id_anggota join peminjaman_buku on peminjaman_buku.id_pinjam = peminjaman.id_pinjam join buku on peminjaman_buku.kode_buku = buku.kode_buku where peminjaman_buku.tgl_kembali_riil is null";
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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from peminjaman where id_pinjam = " + textBox1.Text, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int id_pinjam = Convert.ToInt32(reader["id_pinjam"]);
            }
            else
            {
                MessageBox.Show("Id peminjaman tidak dapat ditemukan", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id != 0 && date_kembali.Value != null)
            {
                string com = "update peminjaman_buku set tgl_kembali_riil = '" + date_kembali.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', denda = " + Convert.ToInt32(lbldenda.Text) + ", jml_hari_denda = " + denda + "where id_pinjam = " + id;
                string com2 = "update buku set stok = " + getstok() + " where kode_buku = '" + code + "'";

                try
                {
                    Command.exec(com);
                    Command.exec(com2);
                    MessageBox.Show("Sukses Mengembalikan Buku", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    loadgrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
        }

        int getstok()
        {
            SqlCommand command = new SqlCommand("select * from buku where kode_buku = '" + code + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int stok = Convert.ToInt32(reader["stok"]) + 1;
            connection.Close();
            return stok;
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            lbldeadline.Text = "";
            lblanggota.Text = "";
            id = 0;
            denda = 0;
            code = "";
            date_kembali.Value = DateTime.Now;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            DateTime deadline = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[14].Value);
            DateTime kembali = date_kembali.Value;

            code = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
            lbldeadline.Text = deadline.ToString("dddd, dd MM yyyy");
            lblanggota.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            if (kembali > deadline)
                denda = Convert.ToInt32((kembali.Date - deadline.Date).TotalDays);
            else
                denda = 0;

            lbldenda.Text = (denda * 2250).ToString();
        }
    }
}
