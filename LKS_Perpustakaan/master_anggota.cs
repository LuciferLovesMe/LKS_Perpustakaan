using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Perpustakaan
{
    public partial class master_anggota : Form
    {
        int cond, userid;
        string id;
        SqlConnection connection = new SqlConnection(Utils.conn);

        public master_anggota()
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
            btn_up.Enabled = false;
        }

        void enable()
        {
            btn_tambah.Enabled = false;
            btn_ubah.Enabled = false;
            btn_hapus.Enabled = false;
            btn_simpan.Enabled = true;
            btn_batal.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            btn_up.Enabled = true;
        }

        bool val()
        {
            if (textBox2.TextLength < 1 || textBox3.TextLength < 1 || textBox3.TextLength  < 1 || pictureBox1.Image == null)
            {
                MessageBox.Show("Semua field harus diisi!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBox3.TextLength != 16)
            {
                MessageBox.Show("NIK harus 16 digit", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (getnik() == false)
            {
                MessageBox.Show("NIK telah digunakan", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        bool val_up()
        {
            if (textBox2.TextLength < 1 || textBox3.TextLength < 1 || textBox4.TextLength < 1)
            {
                MessageBox.Show("Semua field wajib diisi!", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBox3.TextLength != 16)
            {
                MessageBox.Show("NIK harus 16 digit", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        bool getnik()
        {
            SqlCommand command = new SqlCommand("select * from anggota where nik = '" + textBox3.Text + "'", connection);
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

        void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = null;
        }

        void loadgrid()
        {
            string com = "select * from anggota join [dbo].[user] on anggota.id_user = [dbo].[user].id_user";
            dataGridView1.DataSource = Command.getdata(com);
        }

        string getuser()
        {
            SqlCommand command = new SqlCommand("select count(id_user) as num from [dbo].[user] where level = 'anggota'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int c = Convert.ToInt32(reader["num"]) + 1;
                connection.Close();
                return "ANG" + c.ToString();
            }
            connection.Close();
            return "ANG1";
        }

        string getuser1()
        {
            SqlCommand command = new SqlCommand("select count(id_user) as num from [dbo].[user] where level = 'anggota'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                int c = Convert.ToInt32(reader["num"]);
                connection.Close();
                return "PET" + c.ToString();
            }
            connection.Close();
            return "PET1";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select * from anggota join [dbo].[user] on anggota.id_user = [dbo].[user].id_user where nama_lengkap like '%" + textBox1.Text+"%'";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image|*.jpeg;*.png;*.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(ofd.FileName);
                    Bitmap bmp = (Bitmap)img;
                    pictureBox1.Image = bmp;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_ubah_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                enable();
                cond = 2;
            }
            else
            {
                MessageBox.Show("Pilih 1 item", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            if(cond == 1)
            {
                if (val())
                {
                    string com = "insert into [dbo].[user] values ('" + getuser() + "', '123123123', 'anggota')";
                    Command.exec(com);

                    SqlCommand comm = new SqlCommand("select top(1) * from [dbo].[user] where level = 'anggota' order by id_user desc", connection);
                    connection.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    int userid = Convert.ToInt32(reader["id_user"]);
                    connection.Close();

                    ImageConverter converter = new ImageConverter();
                    byte[] img = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    string command = "insert into anggota values('" + getuser1() + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', getdate(), @img, " + userid + ")";
                    SqlCommand sql = new SqlCommand(command, connection);
                    sql.Parameters.AddWithValue("@img", img);
                    try
                    {
                        connection.Open();
                        sql.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Sukses", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadgrid();
                        dis();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }
                }
            }
            else if (cond == 2)
            {
                if (val_up())
                {
                    ImageConverter converter = new ImageConverter();
                    byte[] img = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    string command = "update anggota set nama_lengkap = '"+textBox2.Text+"', nik = '"+textBox3.Text+"', alamat = '"+textBox4.Text+"', foto = @img";
                    SqlCommand sql = new SqlCommand(command, connection);
                    sql.Parameters.AddWithValue("@img", img);
                    try
                    {
                        connection.Open();
                        sql.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Sukses", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadgrid();
                        dis();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            if (dataGridView1.SelectedRows[0].Cells[5].Value == System.DBNull.Value)
            {
                pictureBox1.Image = null;
            }
            else
            {
                byte[] b = (byte[])dataGridView1.SelectedRows[0].Cells[5].Value;
                MemoryStream stream = new MemoryStream(b);
                pictureBox1.Image = Image.FromStream(stream);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string com = "delete from anggota where id_anggota = '" + id + "'";
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
                        connection.Close();
                    }
                }
            }
        }
    }
}
