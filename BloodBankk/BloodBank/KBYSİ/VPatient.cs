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
    public partial class VPatient : Form
    {
        Connection con = new Connection();
        public VPatient()
        {
            InitializeComponent();
        }
        private void VPatient_Load(object sender, EventArgs e)
        {
            getVPatients();
            controlsLoad();
        }
        public void getVPatients()
        {
            string getVPatients = "SELECT * FROM vPatients";

            DataTable dt = new DataTable();
            SqlDataAdapter sqlda = new SqlDataAdapter(getVPatients, con.openConnection());
            sqlda.Fill(dt);
            grd_patients.DataSource = dt;

        }
        private void grd_patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd_patients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grd_patients.CurrentRow.Selected = true;
                txt_tc.Text = grd_patients.Rows[e.RowIndex].Cells["TcNo"].FormattedValue.ToString();
                txt_name.Text = grd_patients.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                txt_surname.Text = grd_patients.Rows[e.RowIndex].Cells["Surname"].FormattedValue.ToString();
                txt_age.Text = grd_patients.Rows[e.RowIndex].Cells["Age"].FormattedValue.ToString();
                cmb_gender.Text = grd_patients.Rows[e.RowIndex].Cells["Gender"].FormattedValue.ToString();
                txt_phone.Text = grd_patients.Rows[e.RowIndex].Cells["PhoneNum"].FormattedValue.ToString();
                txt_address.Text = grd_patients.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                cmb_blood.Text = grd_patients.Rows[e.RowIndex].Cells["BloodGroup"].FormattedValue.ToString();
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            updatePatient();
        }
        public void updatePatient()
        {
            if (txt_tc.Text != "" && txt_name.Text != "" && txt_surname.Text != "" && txt_age.Text != "" && txt_phone.Text != "" && txt_address.Text != "" && cmb_blood.SelectedIndex != -1 && cmb_gender.SelectedIndex != -1)
            {
                string patientInsert = "UPDATE Patient SET TcNo = @p1, Name = @p2, Surname = @p3, Age = @p4, Gender = @p5, PhoneNum = @p6, Address = @p7, BloodGroupId = @p8 WHERE TcNo = @p1";
                SqlCommand command = new SqlCommand(patientInsert, con.openConnection());
                command.Parameters.AddWithValue("@p1", txt_tc.Text);
                command.Parameters.AddWithValue("@p2", txt_name.Text);
                command.Parameters.AddWithValue("@p3", txt_surname.Text);
                command.Parameters.AddWithValue("@p4", Convert.ToInt32(txt_age.Text));
                command.Parameters.AddWithValue("@p5", cmb_gender.Text);
                command.Parameters.AddWithValue("@p6", txt_phone.Text);
                command.Parameters.AddWithValue("@p7", txt_address.Text);
                command.Parameters.AddWithValue("@p8", Convert.ToInt32(cmb_blood.SelectedIndex) + 1);
                command.ExecuteNonQuery();
                con.openConnection().Close();
                controlsClear();
                MessageBox.Show("Kaydedildi.");
                getVPatients();
            }
            else
            {
                MessageBox.Show("Hicbir alan bos birakilamaz.");
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            deletePatient();
        }
        public void deletePatient()
        {
            string patientDelete = "DELETE FROM Patient WHERE TcNo = @p1";
            SqlCommand command = new SqlCommand(patientDelete, con.openConnection());
            command.Parameters.AddWithValue("@p1", txt_tc.Text);
            command.ExecuteNonQuery();
            con.openConnection().Close();
            controlsClear();
            MessageBox.Show("Silindi.");
            getVPatients();
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

            SqlCommand genderLoadCommand = new SqlCommand(getGender, con.openConnection());
            SqlCommand bloodGroupLoadCommand = new SqlCommand(getBloodGroup, con.openConnection());

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
