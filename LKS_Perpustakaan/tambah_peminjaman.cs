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
    public partial class tambah_peminjaman : Form
    {
        SqlConnection connection = new SqlConnection(Utils.conn);

        public tambah_peminjaman()
        {
            InitializeComponent();
            loadanggota();

            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        void loadanggota()
        {
            string com = "select * from anggota";
            comboBox1.DataSource = Command.getdata(com);
            comboBox1.DisplayMember = "nama_lengkap";
            comboBox1.ValueMember = "id_anggota";
        }

        bool val()
        {
            if(comboBox1.SelectedValue == null || textBox1.TextLength < 1 || tb_judul.TextLength < 1 || tb_kategori.TextLength < 1 || tb_penulis.TextLength < 1)
            {
                MessageBox.Show("Silahkan pilih satu buku", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
            SqlCommand command = new SqlCommand("select * from buku join kategori on buku.id_kat = kategori.id_kat where kode_buku = '" + textBox1.Text + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                tb_judul.Text = reader["judul"].ToString();
                tb_kategori.Text = reader["nama_kat"].ToString();
                tb_penerbit.Text = reader["penerbit"].ToString();
                tb_penulis.Text = reader["penulis"].ToString();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Buku tidak dapat ditemukan!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (val())
            {
                int row = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells[0].Value = Model.id;
                dataGridView1.Rows[row].Cells[1].Value = Model.name;
                dataGridView1.Rows[row].Cells[2].Value = comboBox1.SelectedValue;
                dataGridView1.Rows[row].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[row].Cells[4].Value = textBox1.Text;
                dataGridView1.Rows[row].Cells[5].Value = tb_judul.Text;
                dataGridView1.Rows[row].Cells[6].Value = date_pinjam.Value;
                dataGridView1.Rows[row].Cells[7].Value = date_kembali.Value;
            }
        }
    }
}
