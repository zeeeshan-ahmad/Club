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
   partial class frmClub : Form
    {
        private ClubBL clubBL;
        private bool isLoaded;

        public frmClub()
        {
            InitializeComponent();
            this.clubBL = new ClubBL();
            isLoaded = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id can't be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name can't be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone can't be empty");
                return;
            }
            int id = Int16.Parse(txtId.Text);

            string Name = txtName.Text;
            
            string Phone = txtPhone.Text;


            model. ClubModel p = new ClubModel(id, Name, Phone);

            bool result = clubBL.Save(p);
            if (result)
            {
                MessageBox.Show("Record Successfully Saved");

            }
            else
            {
                MessageBox.Show("Record Can't Saved");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Int32 id;
            bool isConverted = Int32.TryParse(txtId.Text, out id);

            ClubModel p = clubBL.SearchById(id);

            if (p != null)
            {
                txtName.Text = p.Name;
            }
            else
            {
                MessageBox.Show("No Record Exists!");
            }

            if (p != null)
            {
                txtPhone.Text = p.Phone;
                isLoaded = true;   
            }
            else
            {
                MessageBox.Show("No Record Exists!");
            }

            

        }

      

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(!isLoaded)
            {
                MessageBox.Show("Can not perform upadate: No record loaded");
                return;

            }

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Id can't be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name can't be empty");
                return;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone can't be empty");
                return;
            }
            int id = Int16.Parse(txtId.Text);

            string Name = txtName.Text;

            string Phone = txtPhone.Text;


            model.ClubModel p = new ClubModel(id, Name, Phone);

            bool result = clubBL.Update(p);
            if (result)
            {
                MessageBox.Show("Record Successfully Updated");

            }
            else
            {
                MessageBox.Show("Record Can not be update");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                MessageBox.Show("Cannot perform Delete: No record loaded");
                return;
            }


            Int32 id;
            bool isConverted = Int32.TryParse(txtId.Text, out id);

            bool result = clubBL.Delete(id);
            if (result)
            {
                MessageBox.Show("Record successfully Deleted");
                clearForm();
            }

            else
            {
                MessageBox.Show("Record cannot be Deleted");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
           clearForm();
        }

        private void clearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();

            isLoaded=false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmClub_Load(object sender, EventArgs e)
        {

        }
    }
}
