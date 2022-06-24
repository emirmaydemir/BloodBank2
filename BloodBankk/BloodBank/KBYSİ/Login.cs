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

namespace KBYSİ
{
    public partial class Login : Form
    {
        Connection con = new Connection();
        public Login()
        {
            InitializeComponent();
        }
        public void login()
        {
            string sorgu = "SELECT * FROM SystemUser WHERE TcNo = '" + txt_id.Text +"' AND Password = '" + txt_password.Text + "'";
            SqlDataAdapter sqlda = new SqlDataAdapter(sorgu, con.openConnection());
            DataTable dataTable = new DataTable();
            sqlda.Fill(dataTable);

            if (txt_id.Text != "" && txt_password.Text != "")
            {
                if (dataTable.Rows.Count == 1)
                {
                    if (true)
                    {
                        MainForm mf = new MainForm();
                        mf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sifre yanlis lutfen tekrardan giriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Tc Kimlik No veya sifre yanlis lutfen tekrardan giriniz.");
                    controlsClear();
                }
            }
            else
            {
                MessageBox.Show("Lutfen kontrolleri bos birakmayiniz.");
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            login();
        }
        public void controlsClear()
        {
            txt_id.Clear();
            txt_password.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
