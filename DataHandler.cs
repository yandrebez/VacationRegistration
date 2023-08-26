using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaccinationRegistration
{
    internal class DataHandler
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dtreader;

        string connectionString = "Data Source=(local); Initial Catalog=VacinationRegistrationDB; Integrated Security = SSPI";

        public void registerPatient(int _patientID, string _name, string _surname, int _phonenumber, string _address)
        {
            string qryRegister = ("INSERT INTO tblPatientsRegistered VALUES('" + _patientID + "','" + _name + "','" + _surname + "','" + _phonenumber + "','" + _address + "')");
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(qryRegister, connection);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Patient Registered!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Patient was not registered..." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void updatePatient(int _patientID, string _name, string _surname, int _phonenumber, string _address)
        {
            string qryUpdate = ("UPDATE tblPatientRegistered SET PatientID = '" + _patientID + "', Name='" + _name + "', Surname= '" + _surname + "', PhoneNumber='" + _phonenumber + "', Address='" + _address + "')");
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(qryUpdate, connection);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Patient Details UPDATED!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update was unsuccesfull " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void deletePatient(int _patientID)
        {
            string qryDelete = ("DELETE FROM tblPatientRegistered WHERE PatientID = '" + _patientID + "'");
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(qryDelete, connection);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Patient has been Deleted!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not Delete File..." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void searchPatient(int _patientID)
        {
            string qrySearch = ("SELECT * FROM tblPatientRegistered WHERE PatientID = '" + _patientID + "'");
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(qrySearch, connection);

            try
            {
                dtreader = command.ExecuteReader();
                if (dtreader.Read())
                {
                    _patientID = int.Parse(dtreader[0].ToString());

                }
                else
                {
                    MessageBox.Show("No patient record found!");
                }
                dtreader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No record found" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
       
    }
}

    