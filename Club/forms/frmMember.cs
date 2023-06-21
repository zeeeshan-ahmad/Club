using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Club.business_logic;
using Club.model;

namespace Club.forms
{
    public partial class frmMember : Form
    {
        private MemberBL memberBL;
        private bool isLoaded;

        public frmMember()
        {
            InitializeComponent();
            memberBL = new MemberBL();
            isLoaded = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id can not be empty");
            }
            if (string.IsNullOrEmpty(txtClub_Id.Text))
            {
                MessageBox.Show("Club Id can not be empty");
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address can not be empty");
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone can not be empty");
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email can not be empty");
            }
          


            int id = int.Parse(txtId.Text);
            
            char gender;
            if (rdoMale.Checked)
            {
                gender = 'm';
            }
            else if (rdoFemale.Checked)
            {
                gender = 'f';
            }
            else
            {
                gender = 'u';
            }
            

            int club_id = int.Parse(txtClub_Id.Text);
            
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;


            model.Member M = new Member( id, club_id, address, phone, email, gender);

            Console.WriteLine(club_id);
            bool result = memberBL.Save(M);
            if (result)
            {
                MessageBox.Show("Record successfully saved");
            }
            else
            {
                MessageBox.Show("Record can not be saved");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Int32 id;
            bool isConverted =  Int32.TryParse(txtId.Text, out id);

            Int32 club_id;
            Int32.TryParse(txtClub_Id.Text,out club_id);

            Member M = memberBL.SearchById(id);

           
            if (M != null)
            {
                if(M.Gender == 'm')
                {
                    rdoMale.Checked = true;
                }
                else if (M.Gender == 'f')
                {
                    rdoFemale.Checked = true;
                }
               
                txtPhone.Text = M.Phone;
                txtEmail.Text = M.Email;
                txtAddress.Text = M.Address;
                txtClub_Id.Text = M.Club_Id.ToString();
                isLoaded = true;
                
 
            }
            else
            {
                MessageBox.Show("No Record Exists!");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                MessageBox.Show("Load a record");
                return;
            }

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id can not be empty");
            }
            if (string.IsNullOrEmpty(txtClub_Id.Text))
            {
                MessageBox.Show("Club Id can not be empty");
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address can not be empty");
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone can not be empty");
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email can not be empty");
            }



            int id = int.Parse(txtId.Text);

            char gender;
            if (rdoMale.Checked)
            {
                gender = 'm';
            }
            else if (rdoFemale.Checked)
            {
                gender = 'f';
            }
            else
            {
                gender = 'u';
            }


            int club_id = int.Parse(txtClub_Id.Text);

            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;


            model.Member M = new Member(id, club_id, address, phone, email, gender);

            bool result = memberBL.Update(M);
            if (result)
            {
                MessageBox.Show("Record updated successfully ");
            }
            else
            {
                MessageBox.Show("Record can not be Updated");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                MessageBox.Show("can not Delete: no record loaded");
                return;
            }


            Int32 id;
            bool isConverted = Int32.TryParse(txtId.Text, out id);
            bool result = memberBL.Delete(id);

            if (result)
            {
                MessageBox.Show("Record deleted successfully");
                clearForm();
            }
            else
            {
                MessageBox.Show("Record can not deleted");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearForm();   
        }

        private void clearForm()
        {
            txtId.Clear();
            txtClub_Id.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            isLoaded = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}
