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
    public partial class master_petugas : Form
    {
        int id, cond;
        public master_petugas()
        {
            InitializeComponent();
            dis();
            loadgrid();

            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        void dis()
        {
            btn_tambah.Enabled = true;
            btn_ubah.Enabled = true;
            btn_hapus.Enabled = true;
            btn_simpan.Enabled = false;
            btn_batal.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        void enable()
        {
            btn_tambah.Enabled = false;
            btn_ubah.Enabled = false;
            btn_hapus.Enabled = false;
            btn_simpan.Enabled = true;
            btn_batal.Enabled = true; 
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        void loadgrid()
        {
            string com = "select * from petugas join [dbo].[user] on petugas.id_user = [dbo].[user].id_user";
            dataGridView1.DataSource = Command.getdata(com);
        }

        bool getnik()
        {
            SqlConnection connection = new SqlConnection(Utils.conn);
            SqlCommand command = new SqlCommand("select * from petugas where nik = '" + textBox3.Text + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                connection.Close();
                MessageBox.Show("NIK telah digunakan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            connection.Close();
            return true;
        }

        bool val()
        {
            if(textBox2.TextLength < 1 || textBox3.TextLength < 1 || textBox4.TextLength < 1)
            {
                MessageBox.Show("Semua field wajib diisi!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox3.Text = "";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select * from petugas join [dbo].[user] on petugas.id_user = [dbo].[user].id_user where nama_petugas like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            enable();
            cond = 1;
        }

        private void btn_ubah_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                enable();
                cond = 2;
            }
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string com = "delete from petugas where id_petugas = " + id;
                    try
                    {
                        Command.exec(com);
                        MessageBox.Show("Success", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        dis();
                        loadgrid();
                        clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SqlConnection connection = new SqlConnection(Utils.conn);
                        connection.Close();
                    }
                }
            }
        }
        string getuser()
        {
            SqlConnection connection = new SqlConnection(Utils.conn);
            SqlCommand command = new SqlCommand("select count(id) from [dbo].[user] where level = 'petugas'", connection);

        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            if (val())
            {
                if(cond == 1)
                {
                    string com = "insert into [dbo].[user] values('')"
                }
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
    }
}
