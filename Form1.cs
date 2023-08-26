using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaccinationRegistration
{
    public partial class Form1 : Form
    {
        DataHandler dtHandler = new DataHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;

            txtShowTelephone.Visible = true;
            txtShowName.Visible = true;
            txtShowSurname.Visible = true;
            txtShowAddress.Visible = true;

            dtHandler.searchPatient(int.Parse(txtSearchPID.Text));
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            dtHandler.registerPatient(int.Parse(txtPatientID.Text), txtName.Text, txtSurname.Text, int.Parse(txtNumber.Text), txtAddress.Text);
        }


        private void dgvVaccinationRegistrations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;

            txtShowTelephone.Visible = true;
            txtShowName.Visible = true;
            txtShowSurname.Visible = true;
            txtShowAddress.Visible = true;

            if (dgvVaccinationRegistrations.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string patientID = dgvVaccinationRegistrations.Rows[e.RowIndex].Cells["PatientID"].FormattedValue.ToString();
                string Name = dgvVaccinationRegistrations.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                string Surname = dgvVaccinationRegistrations.Rows[e.RowIndex].Cells["Surname"].FormattedValue.ToString();
                string PhoneNumber = dgvVaccinationRegistrations.Rows[e.RowIndex].Cells["PhoneNumber"].FormattedValue.ToString();
                string Address = dgvVaccinationRegistrations.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();

                txtSearchPID.Text = patientID;
                txtShowName.Text = Name;
                txtShowSurname.Text = Surname;
                txtShowTelephone.Text = PhoneNumber;
                txtShowAddress.Text = Address;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dtHandler.updatePatient(int.Parse(txtSearchPID.Text), txtShowName.Text, txtShowSurname.Text, int.Parse(txtShowTelephone.Text), txtShowAddress.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dtHandler.deletePatient(int.Parse(txtSearchPID.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtShowTelephone.Visible = false;
            txtShowName.Visible = false;
            txtShowSurname.Visible = false;
            txtShowAddress.Visible = false;

            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
        }
    }
}
