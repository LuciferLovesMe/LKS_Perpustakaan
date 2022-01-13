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
    public partial class master_user : Form
    {
        int id, cond;
        string old;
        SqlConnection connection = new SqlConnection(Utils.conn);

        public master_user()
        {
            InitializeComponent();
            loadgrid();
            dis();
            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        void dis()
        {
            btn_ubah.Enabled = true;
            btn_simpan.Enabled = false;
            btn_batal.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        void enable()
        {
            btn_ubah.Enabled = false;
            btn_simpan.Enabled = true;
            btn_batal.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        void loadgrid()
        {
            string com = "select * from [dbo].[user]";
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

        bool getuser()
        {
            SqlCommand command = new SqlCommand("select * from [dbo].[user] where username = '" + textBox2.Text + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                MessageBox.Show("Username telah digunakan!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }

            connection.Close();
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            old = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select * from [dbo].[user] where username like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void btn_ubah_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                enable();
            }
        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            if(textBox2.TextLength > 1)
            {
                if(textBox3.TextLength > 1)
                {
                    if(textBox3.Text != old)
                    {
                        MessageBox.Show("Password Lama Tidak Valid!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(textBox4.TextLength < 1)
                    {
                        MessageBox.Show("Password baru harus diisi!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (getuser())
                    {
                        string com = "update [dbo].[user] set password = '" + textBox4.Text + "', username = '" + textBox2.Text + "' where id_user = "+id;
                        try
                        {
                            Command.exec(com);
                            MessageBox.Show("Sukses", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dis();
                            clear();
                            loadgrid();
                        }
                        catch (Exception ex)
                        {
                            connection.Close();
                            MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.PasswordChar = '\0';
                textBox4.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '*';
                textBox4.PasswordChar = '*';
            }
        }
    }
}
