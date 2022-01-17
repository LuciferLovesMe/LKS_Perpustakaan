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
    public partial class cari_buku : Form
    {
        public cari_buku()
        {
            InitializeComponent();
            loadgrid();
            lbltime.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy / HH:mm:ss");
            lbladmin.Text = Model.name;
        }

        private void panel_cari_Click(object sender, EventArgs e)
        {
            cari_buku cari = new cari_buku();
            this.Hide();
            cari.ShowDialog();
        }

        private void panel_history_Click(object sender, EventArgs e)
        {
            history history = new history();
            this.Hide();
            history.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin menutup aplikasi ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        void loadgrid()
        {
            string com = "select * from buku";
            dataGridView1.DataSource = Command.getdata(com);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string com = "select * from buku where kode_buku like '%" + textBox1.Text + "%' or judul like = '%" + textBox1.Text + "%' or penulis like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = Command.getdata(com);
        }
    }
}
