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
    public partial class master_kategori : Form
    {
        int cond, id;
        public master_kategori()
        {
            InitializeComponent();
            dis();
            loadgrid();

            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        void dis()
        {
            textBox2.Enabled = false;
            btn_hapus.Enabled = true;
            btn_tambah.Enabled = true;
            btn_ubah.Enabled = true;
            btn_simpan.Enabled = false;
            btn_batal.Enabled = false;
        }

        void enable()
        {
            textBox2.Enabled = true;
            btn_hapus.Enabled = false;
            btn_tambah.Enabled = false;
            btn_ubah.Enabled = false;
            btn_simpan.Enabled = true;
            btn_batal.Enabled = true;
        }

        void loadgrid()
        {
            string com = "select * from kategori";
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

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            enable();
            cond = 1;
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string com = "delete from kategori where id_kat = " + id;
                    try
                    {
                        Command.exec(com);
                        MessageBox.Show("Success", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dis();
                        loadgrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SqlConnection connection = new SqlConnection(Utils.conn);
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih satu item!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            if(textBox2.TextLength > 1)
            {
                if(cond == 1)
                {
                    string com = "insert into kategori values ('" + textBox2.Text + "')";
                    try
                    {
                        Command.exec(com);
                        MessageBox.Show("Success", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dis();
                        textBox2.Text = "";
                        loadgrid();
                    }   
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SqlConnection connection = new SqlConnection(Utils.conn);
                        connection.Close();
                    }
                }
                else if (cond == 2)
                {
                    string com = "update kategori set nama_kat = '" + textBox2.Text + "' where id_kat =" + id;
                    try
                    {
                        Command.exec(com);
                        MessageBox.Show("Success", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        dis();
                        loadgrid();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btn_batal_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            dis();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select * from kategori where nama_kat like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void btn_ubah_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                enable();
                cond = 2;
            }
        }


    }
}
