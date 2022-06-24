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
    public partial class Donate : Form
    {
        Connection con = new Connection();
        String bg;
        public Donate()
        {
            InitializeComponent();
        }
        private void Donate_Load(object sender, EventArgs e)
        {
            getDonate();
        }
        public void getDonate()
        {
            string getDonate = "SELECT * FROM VDonors";
            string getBloodStock = "SELECT * FROM BloodST";

            DataTable dt_donor = new DataTable();
            SqlDataAdapter sqlda = new SqlDataAdapter(getDonate, con.openConnection());
            sqlda.Fill(dt_donor);
            grd_Donor.DataSource = dt_donor;

            DataTable dt_blood = new DataTable();
            SqlDataAdapter sqlda2 = new SqlDataAdapter(getBloodStock, con.openConnection());
            sqlda2.Fill(dt_blood);
            grd_BloodStock.DataSource = dt_blood;

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            updateDonate();
        }
        public void updateDonate()
        {
            if (txt_name.Text != "" && txt_blood.Text != "")
            {
                string getId = "SELECT Id FROM BloodGroup WHERE BloodGroup='" + bg +"'";
                SqlCommand com = new SqlCommand(getId, con.openConnection());
                int id = ((int)com.ExecuteScalar());
                string increaseStock = "UPDATE BloodStock SET Stock = Stock + 1 WHERE BloodGroupId = '" + id + "'";
                SqlCommand command = new SqlCommand(increaseStock, con.openConnection());
                command.ExecuteNonQuery();
                con.openConnection().Close();
                controlsClear();
                MessageBox.Show("Kaydedildi.");
                getDonate();
            }
            else
            {
                MessageBox.Show("Hicbir alan bos birakilamaz.");
            }
        }
        private void grd_Donor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd_Donor.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grd_Donor.CurrentRow.Selected = true;
                txt_blood.Text = grd_Donor.Rows[e.RowIndex].Cells["BloodGroup"].FormattedValue.ToString();
                txt_name.Text = grd_Donor.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                bg = grd_Donor.Rows[e.RowIndex].Cells["BloodGroup"].FormattedValue.ToString();
            }
        }
        public void controlsClear()
        {
            txt_name.Clear();
            txt_blood.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor don = new Donor();
            don.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            VDonor vdon = new VDonor();
            vdon.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient();
            pat.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            VPatient vpat = new VPatient();
            vpat.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodTransfer btr = new BloodTransfer();
            btr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
