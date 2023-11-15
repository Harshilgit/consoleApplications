using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace prjWinEmployeeManagement
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        struct employee
        {
            public string Fname;
            public string Lname;
            public string number;
            public string company;
        }
        employee[] tabEmps = new employee[50];
        Int16 nbEmp;
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            StreamReader myfile = new StreamReader("Employees.txt");
            Int16 i = 0;

            while (myfile.EndOfStream == false)
            {
                tabEmps[i].number = myfile.ReadLine();
                tabEmps[i].Fname = myfile.ReadLine();
                tabEmps[i].Lname = myfile.ReadLine();
                tabEmps[i].company = myfile.ReadLine();

                lstEmpNo.Items.Add(tabEmps[i].number);
                i++;
            }
            nbEmp = i;

            myfile.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            employee newE;
            //tabEmps[nbEmp] = newE;
            Int16 p, p2, p3, pAt;
            string temp;
            

            StreamWriter myfile = new StreamWriter("Employees.txt");

            //for (Int16 i = 0; i < nbEmp; i++)
            //{
            newE.Fname = txtName.Text;
            newE.Fname = newE.Fname.Trim();

            
            p = Convert.ToInt16(newE.Fname.IndexOf("."));
            if (p == -1)
            {
                MessageBox.Show("Please enter . between Firstname and Lastname");
                txtName.Focus();
                return;
            }
            newE.Fname = newE.Fname.Substring(0, p);
            newE.Fname = newE.Fname.Trim();
            if (newE.Fname.Length == 0)
            {
                MessageBox.Show("Please enter Firstname");
                txtName.Focus();
                return;
            }
            newE.Fname = newE.Fname.Substring(0, 1).ToUpper() + newE.Fname.Substring(1);
            txtFname.Text = newE.Fname;
               // myfile.WriteLine(tabEmps[i].Fname);


                temp = txtName.Text.Substring(p + 1).Trim();

            p2 = Convert.ToInt16(temp.IndexOf("."));
            if (p2 == -1)
            {
                MessageBox.Show("Please enter Dot between Last name and Number");
                txtName.Focus();
                return;
            }
            // recuperating Last name from Email and addig to the file
            newE.Lname= temp.Substring(0, p2);
            newE.Lname= newE.Lname.Trim();

            if (newE.Lname.Length == 0)
            {
                MessageBox.Show("Please enter Last name!");
                txtName.Focus();
                return;
            }

            newE.Lname= newE.Lname.Substring(0, 1).ToUpper() + newE.Lname.Substring(1).ToLower();
            txtLname.Text = newE.Lname;
                //myfile.WriteLine(tabEmps[i].Lname);
                
                temp = temp.Substring(p2 + 1).Trim();



            //finding @ position
            pAt = Convert.ToInt16(temp.IndexOf("@"));
            if (pAt == -1)
            {
                MessageBox.Show("Please enter @ between Number and Company");
                txtName.Focus();
                return;
            }
            // recuperating Number from Email and adding to the file
            newE.number= temp.Substring(0, pAt);
            newE.number= newE.number.Trim();

            if (newE.number.Length == 0)
            {
                MessageBox.Show("Please enter Number!");
                txtName.Focus();
                return;
            }

            newE.number= newE.number.Substring(0, 1).ToUpper() + newE.number.Substring(1).ToLower();
            txtNumber.Text = newE.number;
            //myfile.WriteLine(tabEmps[i].number);

                temp = temp.Substring(pAt + 1).Trim();

            p3 = Convert.ToInt16(temp.IndexOf("."));
            if (p3 == -1)
            {
                MessageBox.Show("Please enter Dot between Company and com");
                txtName.Focus();
                return;
            }
            // recuperating company from Email and adding to the file
            newE.company = temp.Substring(0, p3);
            newE.company= newE.company.Trim();



            if (newE.company.Length == 0)
            {
                MessageBox.Show("Please enter Company!");
                txtName.Focus();
                return;
            }



            newE.company= newE.company.Substring(0, 1).ToUpper() + newE.company.Substring(1).ToLower();
            txtCompany.Text = newE.company;
            //myfile.WriteLine(tabEmps[i].company);


            //}
            //myfile.Close();
            if (!(lstEmpNo.Items.Contains(newE.number)))
            {
                lstEmpNo.Items.Add(newE.number);
                tabEmps[nbEmp].number = newE.number;
                tabEmps[nbEmp].Fname = newE.Fname;
                tabEmps[nbEmp].Lname = newE.Lname;
                tabEmps[nbEmp].company = newE.company;

                nbEmp++;
            }
            else
            {
                MessageBox.Show("Number alredy exists. Please enter a different number.");
                txtName.Focus();
            }


        }

        private void lstEmpNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtNumber.Text = lstEmpNo.SelectedItem.ToString();
            for (Int16 i = 0; i < nbEmp; i++)
            {
                if (tabEmps[i].number == lstEmpNo.SelectedItem.ToString())
                {
                    string num = tabEmps[i].number;
                    txtNumber.Text = num;

                    string fnm = tabEmps[i].Fname;
                    txtFname.Text = fnm;

                    string flm = tabEmps[i].Lname;
                    txtLname.Text = flm;

                    string cmp = tabEmps[i].company;
                    txtCompany.Text = cmp;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtCompany.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstEmpNo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee to edit.");
                return;
            }

            int selectedIndex = lstEmpNo.SelectedIndex;

            // Assuming that lstEmpNo.Items are unique numbers
            string selectedNumber = lstEmpNo.SelectedItem.ToString();

            // Find the index of the selected number in the array
            int indexToUpdate = -1;
            for (int i = 0; i < nbEmp; i++)
            {
                if (tabEmps[i].number == selectedNumber)
                {
                    indexToUpdate = i;
                    break;
                }
            }

            // Check if the number was found
            if (indexToUpdate != -1)
            {
                // Update the employee details
                tabEmps[indexToUpdate].Fname = txtFname.Text.Trim();
                tabEmps[indexToUpdate].Lname = txtLname.Text.Trim();
                tabEmps[indexToUpdate].company = txtCompany.Text.Trim();

                // Update the ListBox item
                lstEmpNo.Items[selectedIndex] = tabEmps[indexToUpdate].number;

                // Save the changes to the file (if needed)
                SaveToFile();

                MessageBox.Show("Employee details updated successfully.");
            }
            else
            {
                MessageBox.Show("Error: Selected employee not found.");
            }

        }

        private void SaveToFile()
        {
            // Save the updated employee details to the file
            StreamWriter myfile = new StreamWriter("Employees.txt");

            for (int i = 0; i < nbEmp; i++)
            {
                myfile.WriteLine(tabEmps[i].number);
                myfile.WriteLine(tabEmps[i].Fname);
                myfile.WriteLine(tabEmps[i].Lname);
                myfile.WriteLine(tabEmps[i].company);
            }

            myfile.Close();
        }
    }
}
