using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppKasir
{
    public partial class FormLogin : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        Koneksi Konn = new Koneksi();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            SqlConnection conn = Konn.GetConn();
            {
                conn.Open();
                cmd = new SqlCommand("select * from TBL_KASIR where Kodekasir='" + textBox1.Text + "' and PasswordKasir='" + textBox2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    

                    FormMenuUtama.menu.menuLogin.Enabled = false;
                    FormMenuUtama.menu.menuLogout.Enabled = true;
                    FormMenuUtama.menu.menuMaster.Enabled = true;
                    FormMenuUtama.menu.menuTransaski.Enabled = true;
                    FormMenuUtama.menu.menuLaporan.Enabled = true;
                    FormMenuUtama.menu.menuUtility.Enabled = true;
                    //FormMenuUtama frmUtama = new FormMenuUtama();
                    //frmUtama.Show();


                    this.Close();
                }
                else
                {
                    MessageBox.Show("Salah Bro");
                }
            }
        }

            //if (textBox1.Text == "KSR001" && textBox2.Text == "Admin")
            //{
                //FormMenuUtama frmUtama = new FormMenuUtama();
               // frmUtama.Show();
                //this.Hide();
            //}
            //else
            //{
               // MessageBox.Show("Salah Bro");
            //}
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
