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
    public partial class Donor : Form
    {
        Connection con = new Connection();
        public Donor()
        {
            InitializeComponent();
        }
        private void Donor_Load(object sender, EventArgs e)
        {
            controlsLoad();
        }
        public void controlsClear()
        {
            txt_tc.Clear();
            txt_name.Clear();
            txt_surname.Clear();
            txt_age.Clear();
            cmb_gender.SelectedIndex = -1;
            txt_phone.Clear();
            txt_address.Clear();
            cmb_blood.SelectedIndex = -1;
        }
        public void controlsLoad()
        {
            string getGender = "SELECT * FROM Gender ";
            string getBloodGroup = "SELECT * FROM BloodGroup";
            SqlDataReader readBloodGroup;
            SqlDataReader readGender;

            SqlCommand genderLoadCommand = new SqlCommand(getGender,con.openConnection());
            SqlCommand bloodGroupLoadCommand = new SqlCommand(getBloodGroup,con.openConnection());

            readGender = genderLoadCommand.ExecuteReader();
            readBloodGroup = bloodGroupLoadCommand.ExecuteReader();

            while (readBloodGroup.Read())
            {
                cmb_blood.Items.Add(readBloodGroup[1].ToString());
            }

            while (readGender.Read())
            {
                cmb_gender.Items.Add(readGender[1].ToString());
            }

            con.openConnection().Close();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            saveDonor();
        }
        public void saveDonor()
        {
            if (txt_tc.Text != "" && txt_name.Text != "" && txt_surname.Text != "" && txt_age.Text != "" && txt_phone.Text != "" && txt_address.Text != "" && cmb_blood.SelectedIndex != -1 && cmb_gender.SelectedIndex != -1)
            {
                string donorInsert = "INSERT INTO Donor (TcNo, Name, Surname, Age, Gender, PhoneNum, Address, BloodGroupId) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";
                SqlCommand command = new SqlCommand(donorInsert, con.openConnection());
                command.Parameters.AddWithValue("@p1", txt_tc.Text);
                command.Parameters.AddWithValue("@p2", txt_name.Text);
                command.Parameters.AddWithValue("@p3", txt_surname.Text);
                command.Parameters.AddWithValue("@p4", Convert.ToInt32(txt_age.Text));
                command.Parameters.AddWithValue("@p5", cmb_gender.Text);
                command.Parameters.AddWithValue("@p6", txt_phone.Text);
                command.Parameters.AddWithValue("@p7", txt_address.Text);
                command.Parameters.AddWithValue("@p8", Convert.ToInt32(cmb_blood.SelectedIndex)+1);
                command.ExecuteNonQuery();
                con.openConnection().Close();
                controlsClear();
                MessageBox.Show("Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Hicbir alan bos birakilamaz.");
            }
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

        private void label5_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
            this.Hide();
        }
        private void LabelEffect_Click(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 45 || lbl.Location.X == 358 || lbl.Location.X == 691)
            {
                lbl.Font = new Font("Microsoft Sans Serif", 12);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 20);
                foreach (Control txt in panel4.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
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
