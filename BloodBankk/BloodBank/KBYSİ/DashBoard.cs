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
    public partial class DashBoard : Form
    {
        Connection con = new Connection();
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            getDatas();
        }

        public void getDatas()
        {
            string queryForDonor = "SELECT COUNT(*) FROM Donor";
            string quetyForPatient = "SELECT COUNT(*) FROM Patient";

            SqlDataAdapter sqldaDonor = new SqlDataAdapter(queryForDonor, con.openConnection());
            DataTable dataTableForDonor = new DataTable();
            sqldaDonor.Fill(dataTableForDonor);

            SqlDataAdapter sqldaPatient = new SqlDataAdapter(quetyForPatient, con.openConnection());
            DataTable dataTableForPatient = new DataTable();
            sqldaPatient.Fill(dataTableForPatient);

            string donorCount = dataTableForDonor.Rows[0][0].ToString();
            string patientCount = dataTableForPatient.Rows[0][0].ToString();

            lbl_donor.Text = donorCount;
            lbl_patient.Text = patientCount;
            
            int transferCount;
            if (Convert.ToInt32(donorCount) < Convert.ToInt32(patientCount))
            {
                transferCount = Convert.ToInt32(donorCount);
            }
            else
            {
                transferCount = Convert.ToInt32(patientCount);
            }
            lbl_transfer.Text = Convert.ToString(transferCount);

            string queryForAPlus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 1";
            string queryForBPlus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 2";
            string queryForABPlus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 3";
            string queryFor0Plus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 4";
            string queryForAMinus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 5";
            string queryForBMinus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 6";
            string queryForABMinus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 7";
            string queryFor0Minus = "SELECT COUNT(*) AS BloodCount FROM Donor GROUP BY BloodGroupId HAVING BloodGroupId = 8";

            SqlCommand commandAPlus = new SqlCommand(queryForAPlus, con.openConnection());
            if (commandAPlus.ExecuteScalar() != null)
            {
                int APlus = (int)commandAPlus.ExecuteScalar();
                lbl_aPlus.Text = Convert.ToString(APlus);
                double percentAPlus = (Convert.ToDouble(APlus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_APlus.Value = Convert.ToInt32(percentAPlus);
            }
            else
            {
                lbl_aPlus.Text = "0";
                cpb_APlus.Value = 0;
            }


            SqlCommand commandBPlus = new SqlCommand(queryForBPlus, con.openConnection());
            if (commandBPlus.ExecuteScalar() != null)
            {
                int BPlus = (int)commandBPlus.ExecuteScalar();
                lbl_bPlus.Text = Convert.ToString(BPlus);
                double percentBPlus = (Convert.ToDouble(BPlus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_BPlus.Value = Convert.ToInt32(percentBPlus);
            }
            else
            {
                lbl_bPlus.Text = "0";
                cpb_BPlus.Value = 0;
            }

            SqlCommand commandABPlus = new SqlCommand(queryForABPlus, con.openConnection());
            if (commandABPlus.ExecuteScalar() != null)
            {
                int ABPlus = (int)commandABPlus.ExecuteScalar();
                lbl_abPlus.Text = Convert.ToString(ABPlus);
                double percentABPlus = (Convert.ToDouble(ABPlus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_ABPlus.Value = Convert.ToInt32(percentABPlus);
            }
            else
            {
                lbl_abPlus.Text = "0";
                cpb_BPlus.Value = 0;
            }


            SqlCommand command0Plus = new SqlCommand(queryFor0Plus, con.openConnection());
            if (command0Plus.ExecuteScalar() != null)
            {
                int oPlus = (int)command0Plus.ExecuteScalar();
                lbl_0Plus.Text = Convert.ToString(oPlus);
                double percent0Plus = (Convert.ToDouble(oPlus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_0Plus.Value = Convert.ToInt32(percent0Plus);
            }
            else
            {
                lbl_0Plus.Text = "0";
                cpb_0Plus.Value = 0;
            }


            SqlCommand commandAMinus = new SqlCommand(queryForAMinus, con.openConnection());
            if (commandAMinus.ExecuteScalar() != null)
            {
                int AMinus = (int)commandAMinus.ExecuteScalar();
                lbl_aMinus.Text = Convert.ToString(AMinus);
                double percentAMinus = (Convert.ToDouble(AMinus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_AMinus.Value = Convert.ToInt32(percentAMinus);
            }
            else
            {
                lbl_aMinus.Text = "0";
                cpb_AMinus.Value = 0;
            }

            SqlCommand commandBMinus = new SqlCommand(queryForBMinus, con.openConnection());
            if (commandBMinus.ExecuteScalar() != null)
            {
                int BMinus = (int)commandBMinus.ExecuteScalar();
                lbl_bMinus.Text = Convert.ToString(BMinus);
                double percentBMinus = (Convert.ToDouble(BMinus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_BMinus.Value = Convert.ToInt32(percentBMinus);
            }
            else
            {
                lbl_bMinus.Text = "0";
                cpb_BMinus.Value = 0;
            }

            SqlCommand commandABMinus = new SqlCommand(queryForABMinus, con.openConnection());
            if (commandABMinus.ExecuteScalar() != null)
            {
                int ABMinus = (int)commandABMinus.ExecuteScalar();
                lbl_abMinus.Text = Convert.ToString(ABMinus);
                double percentABMinus = (Convert.ToDouble(ABMinus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_ABMinus.Value = Convert.ToInt32(percentABMinus);
            }
            else
            {
                lbl_abMinus.Text = "0";
                cpb_ABMinus.Value = 0;
            }

            SqlCommand command0Minus = new SqlCommand(queryFor0Minus, con.openConnection());
            if (command0Minus.ExecuteScalar() != null)
            {
                int oMinus = (int)command0Minus.ExecuteScalar();
                lbl_0Minus.Text = Convert.ToString(oMinus);
                double percent0Minus = (Convert.ToDouble(oMinus) / Convert.ToDouble(lbl_donor.Text)) * 100;
                cpb_0Minus.Value = Convert.ToInt32(percent0Minus);
            }
            else
            {
                lbl_0Minus.Text = "0";
                cpb_0Minus.Value = 0;
            }

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

        private void label7_Click(object sender, EventArgs e)
        {
            Donate d = new Donate();
            d.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodTransfer btr = new BloodTransfer();
            btr.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
