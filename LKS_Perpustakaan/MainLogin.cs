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
    public partial class MainLogin : Form
    {
        public MainLogin()
        {
            InitializeComponent();
            setcaptcha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin menutup aplikasi ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        static string gen()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        bool val()
        {
            if(textBox1.TextLength < 1 || textBox2.TextLength < 1 || textBox3.TextLength < 1)
            {
                MessageBox.Show("Semua kolom harus diisi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setcaptcha();
                return false;
            }
            if(textBox3.Text != captcha.Text)
            {
                MessageBox.Show("Captcha salah!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                setcaptcha();
                return false;
            }

            return true;
        }

        void setcaptcha()
        {
            captcha.Text = gen();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (val())
            {
                SqlConnection connection = new SqlConnection(Utils.conn);
                SqlCommand command = new SqlCommand("Select * from [dbo].[user] where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Model.userid = Convert.ToInt32(reader["id_user"]);
                    Model.role = reader["level"].ToString();
                    connection.Close();
                    if(Model.role == "petugas")
                    {
                        SqlCommand sql = new SqlCommand("select * from petugas where id_user = " + Model.userid, connection);
                        connection.Open();
                        SqlDataReader reader1 = sql.ExecuteReader();
                        reader1.Read();
                        Model.name = reader1["nama_petugas"].ToString();
                        Model.id = reader1["id_petugas"].ToString();
                        connection.Close();

                        main_admin main = new main_admin();
                        this.Hide();
                        main.ShowDialog();
                    }
                    else if(Model.role == "anggota")
                    {
                        SqlCommand sql = new SqlCommand("select * from anggota where id_user = " + Model.userid, connection);
                        connection.Open();
                        SqlDataReader reader1 = sql.ExecuteReader();
                        reader1.Read();
                        Model.name = reader1["nama_lengkap"].ToString();
                        Model.id = reader1["id_anggota"].ToString();
                        connection.Close();

                        main_anggota main = new main_anggota();
                        this.Hide();
                        main.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("User tidak dapat ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    setcaptcha();
                }
            }
        }
    }
}
