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
    public partial class BloodTransfer : Form
    {
        int sayac = 0;
        Connection con = new Connection();
        String Tc;
        string availableblood = "";
        public BloodTransfer()
        {
            InitializeComponent();
        }
        private void BloodTransfer_Load(object sender, EventArgs e)
        {
            controlsLoad();
        }
        public void controlsLoad()
        {
            string getTc = "SELECT * FROM Patient";
            SqlDataReader readTc;
            SqlCommand TcLoadCommand = new SqlCommand(getTc, con.openConnection());

            readTc = TcLoadCommand.ExecuteReader();

            while (readTc.Read())
            {
                cmb_tc.Items.Add(readTc[1].ToString());
            }

            con.openConnection().Close();
        }
        private void cmb_tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tc = (string)cmb_tc.SelectedItem;
            string getPatientName = "SELECT Name FROM Patient WHERE TcNo='" + Tc + "'";
            SqlCommand com = new SqlCommand(getPatientName, con.openConnection());
            string name = ((string)com.ExecuteScalar());

            string getPatientBlood = "SELECT BloodGroup FROM vPatients WHERE TcNo='" + Tc + "'";
            SqlCommand com2 = new SqlCommand(getPatientBlood, con.openConnection());
            string blood = ((string)com2.ExecuteScalar());

            txt_name.Text = name;
            txt_blood.Text = blood;

            SqlDataReader readGiven;
            string getGivenBlood = "SELECT GivenBlood FROM BloodTransfer WHERE BloodGroup='" + txt_blood.Text + "'";
            SqlCommand givenCom = new SqlCommand(getGivenBlood, con.openConnection());
            readGiven = givenCom.ExecuteReader();
            String givenb="";
                    
            while (readGiven.Read())
            {
                string getBloodStock = "SELECT Stock FROM BloodST WHERE BloodGroup='" + readGiven[0].ToString() + "'";
                SqlCommand commm = new SqlCommand(getBloodStock, con.openConnection());
                int getBloodStockk = ((int)commm.ExecuteScalar());

                //MessageBox.Show(readGiven[0].ToString() +"    "+Convert.ToString(getBloodStockk));

                if(Convert.ToInt32(getBloodStockk) > 0)
                {
                    sayac = 1;
                    availableblood = readGiven[0].ToString();
                    break;
                }

            }
            if (sayac > 0)
            {
                label12.Text = "Aranan kana uygun kan grubu bulunmuştur:  " + availableblood;
            }
            else
            {
                label12.Text = "Aranan kana uygun kan grubu bulunamamıştır";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateTrasnferr();
        }
        public void updateTrasnferr()
        {
            if (sayac > 0)
            {
                if (txt_name.Text != "" && txt_blood.Text != "" && cmb_tc.SelectedIndex != -1)
                {
                    string getbId = "SELECT Id FROM BloodGroup WHERE BloodGroup='" + availableblood + "'";
                    SqlCommand getbCom = new SqlCommand(getbId, con.openConnection());
                    int bloId = ((int)getbCom.ExecuteScalar());

                    string decreaseStock = "UPDATE BloodStock SET Stock = Stock - 1 WHERE BloodGroupId = '" + bloId + "'";
                    SqlCommand command = new SqlCommand(decreaseStock, con.openConnection());
                    command.ExecuteNonQuery();
                    con.openConnection().Close();
                    controlsClear();
                    MessageBox.Show("Aktarıldı.");
                }
                else
                {
                    MessageBox.Show("Hicbir alan bos birakilamaz.");
                }
            }
            else
            {
                MessageBox.Show("Aranan kana uygun kan grubu bulunamamistir.");
            }
            
        }
        public void controlsClear()
        {
            txt_name.Clear();
            txt_blood.Clear();
            cmb_tc.SelectedIndex = -1;
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

        private void label13_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
