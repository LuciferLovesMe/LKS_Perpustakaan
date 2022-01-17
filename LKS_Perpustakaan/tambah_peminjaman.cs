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
            tb_judul.Enabled = false;
            tb_kategori.Enabled = false;
            tb_penerbit.Enabled = false;
            tb_penulis.Enabled = false;
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
            if (comboBox1.SelectedValue == null || textBox1.TextLength < 1 || tb_judul.TextLength < 1 || tb_kategori.TextLength < 1 || tb_penulis.TextLength < 1)
            {
                MessageBox.Show("Silahkan pilih satu buku", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(date_kembali.Value < date_pinjam.Value)
            {
                MessageBox.Show("Tanggal kembali harus lebih besar daripada tanggal pinjam", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (Convert.ToInt32(reader["stok"]) > 0)
                {
                    tb_judul.Text = reader["judul"].ToString();
                    tb_kategori.Text = reader["nama_kat"].ToString();
                    tb_penerbit.Text = reader["penerbit"].ToString();
                    tb_penulis.Text = reader["penulis"].ToString();
                }
                else
                {
                    MessageBox.Show("Buku dengan kode " + textBox1.Text.ToUpper() + " sedang tidak ada stok", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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
                dataGridView1.Rows[row].Cells[6].Value = date_pinjam.Value.ToString("yyyy-MM-dd HH:mm:ss");
                dataGridView1.Rows[row].Cells[7].Value = date_kembali.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        int getstok()
        {
            SqlCommand command = new SqlCommand("select * from buku where kode_buku = '" + textBox1.Text + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int stok = Convert.ToInt32(reader["stok"]) - 1;
            connection.Close();
            return stok;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                string com = "insert into peminjaman values('" + dataGridView1.Rows[0].Cells[2].Value + "', '" + Model.id + "')";
                Command.exec(com);

                SqlCommand command = new SqlCommand("select top(1) * from peminjaman order by id_pinjam desc", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int id_pinjam = Convert.ToInt32(reader["id_pinjam"]);
                connection.Close();

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    string com1 = "insert into peminjaman_buku(kode_buku, id_pinjam, tgl_pinjam, tgl_kembali) values('" + dataGridView1.Rows[i].Cells[4].Value + "', " + id_pinjam + ", '" + dataGridView1.Rows[i].Cells[6].Value + "', '" + dataGridView1.Rows[i].Cells[7].Value + "')";
                    string com2 = "update buku set stok = " + getstok() + " where kode_buku = '" + textBox1.Text + "'";

                    try
                    {
                        Command.exec(com1);
                        Command.exec(com2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }

                MessageBox.Show("Sukses", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void clear()
        {
            dataGridView1.Rows.Clear();
            comboBox1.SelectedValue = 0;
            comboBox1.Text = "";
            textBox1.Text = "";
            date_pinjam.Value = DateTime.Now;
            date_kembali.Value = DateTime.Now;
            tb_judul.Text = "";
            tb_kategori.Text =  "";
            tb_penerbit.Text =  "";
            tb_penulis.Text = "";
        }
    }
}