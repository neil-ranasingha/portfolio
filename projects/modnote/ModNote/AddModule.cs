using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModNote
{
    public partial class AddModule : Form
    {
        public AddModule()
        {
            InitializeComponent();
        }
        public List<string> ModuleData = new List<string>();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Takes user back to main form
            MessageBox.Show("Adding new module cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Main M = new Main();
            M.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string ModulePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Modules\\" + txt1.Text + ".txt";
                if (File.Exists(ModulePath))
                {
                    MessageBox.Show("A Module with the same ModuleID already exists, please try a different ModuleID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Calls the ValidateText method and if the return is true the module data is saved
                    bool valid = ValidateText();
                    if (valid == true)
                    {
                        //Calls the AddData to add the data into the list and then write the list into a text file in the Modules folder
                        AddData();
                        File.WriteAllLines(ModulePath, ModuleData);

                        //Reads all lines of the module locations into an array
                        string[] ModLocations = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\ModuleLocations.txt");
                        int NoOfModules = ModLocations.Length;

                        List<string> ModulesList = new List<string>();
                        for (int i = 0; i < NoOfModules; ++i)
                        {
                            ModulesList.Add(ModLocations[i]);
                        }
                        //Appends the new module to the end of the file and overwrites the ModuleLocations file
                        ModulesList.Add(ModulePath);
                        File.WriteAllLines((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\ModuleLocations.txt"), ModulesList);

                        MessageBox.Show("The Module has been saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Takes user back to the main form
                        Main M = new Main();
                        M.Show();
                        this.Close();
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
                MessageBox.Show("The Module could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateText()
        {
            bool valid = false;
            //Checks that each textbox is not empty
            if (txt1.Text.Length < 8)
                MessageBox.Show("The ModuleID must be 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txt2.Text.Length < 0)
                MessageBox.Show("The Title must not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txt3.Text.Length < 0)
                MessageBox.Show("The Synopsis must not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Chb1.Checked == true)
            {
                if (txt4.Text.Length < 0)
                    MessageBox.Show("The LO1 must not be empty. Please untick the checkbox if there is no LO1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb2.Checked == true)
            {
                if (txt5.Text.Length < 0)
                    MessageBox.Show("The LO2 must not be empty. Please untick the checkbox if there is no LO2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb3.Checked == true)
            {
                if (txt6.Text.Length < 0)
                    MessageBox.Show("The LO3 must not be empty. Please untick the checkbox if there is no LO3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb4.Checked == true)
            {
                if (txt7.Text.Length < 0)
                    MessageBox.Show("The LO4 must not be empty. Please untick the checkbox if there is no LO4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb5.Checked == true)
            {
                if (cb1.Text.Length < 0)
                    MessageBox.Show("The Assignment type must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dtp1.Text.Length < 0)
                    MessageBox.Show("The Assignment date must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb6.Checked == true)
            {
                if (cb2.Text.Length < 0)
                    MessageBox.Show("The Assignment type must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dtp2.Text.Length < 0)
                    MessageBox.Show("The Assignment date must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb7.Checked == true)
            {
                if (cb3.Text.Length < 0)
                    MessageBox.Show("The Assignment type must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dtp3.Text.Length < 0)
                    MessageBox.Show("The Assignment date must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Chb8.Checked == true)
            {
                if (cb3.Text.Length < 0)
                    MessageBox.Show("The Assignment type must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dtp3.Text.Length < 0)
                    MessageBox.Show("The Assignment date must not be empty. Please untick the checkbox if there is no assessment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            valid = true;
            return valid;
        }

        private void AddData()
        {
            //Adds each line into the list as it would appear in the txt file for the module data
            ModuleData.Add("CODE");
            ModuleData.Add(txt1.Text);
            ModuleData.Add("TITLE");
            ModuleData.Add(txt2.Text);
            ModuleData.Add("SYNOPSIS");
            ModuleData.Add(txt3.Text);
            ModuleData.Add("LO");
            //Checks if the checkboxes are checked, if they are the data is added
            if (Chb1.Checked == true)
                ModuleData.Add("LO1 " + txt4.Text);
            else
                ModuleData.Add("LO1 N/A");
            if (Chb2.Checked == true)
                ModuleData.Add("LO2 " + txt5.Text);
            else
                ModuleData.Add("LO2 N/A");
            if (Chb3.Checked == true)
                ModuleData.Add("LO3 " + txt6.Text);
            else
                ModuleData.Add("LO3 N/A");
            if (Chb4.Checked == true)
                ModuleData.Add("LO4 " + txt7.Text);
            else
                ModuleData.Add("LO4 N/A");
            ModuleData.Add("ASSIGNMENT");
            //Checks if the checkboxes are checked, if they are the data is added
            if (Chb5.Checked == true)
                ModuleData.Add(cb1.Text + " = " + dtp1.Value.Date.ToString("dd-MM-yyyy"));
            if (Chb6.Checked == true)
                ModuleData.Add(cb2.Text + " = " + dtp2.Value.Date.ToString("dd-MM-yyyy"));
            if (Chb7.Checked == true)
                ModuleData.Add(cb3.Text + " = " + dtp3.Value.Date.ToString("dd-MM-yyyy"));
            if (Chb8.Checked == true)
                ModuleData.Add(cb4.Text + " = " + dtp4.Value.Date.ToString("dd-MM-yyyy"));
        }

        private void Chb1_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the textboxes if the checkbox is checked
            if (Chb1.Checked == true)
                txt4.Enabled = true;
            else
                txt4.Enabled = false;
        }

        private void Chb2_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the textboxes if the checkbox is checked
            if (Chb2.Checked == true)
                txt5.Enabled = true;
            else
                txt5.Enabled = false;
        }

        private void Chb3_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the textboxes if the checkbox is checked
            if (Chb3.Checked == true)
                txt6.Enabled = true;
            else
                txt6.Enabled = false;
        }

        private void Chb4_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the textboxes if the checkbox is checked
            if (Chb4.Checked == true)
                txt7.Enabled = true;
            else
                txt7.Enabled = false;
        }

        private void Chb5_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the combobox and date time picker if the checkbox is checked
            if (Chb5.Checked == true)
            {
                cb1.Enabled = true;
                dtp1.Enabled = true;
            }
            else
            {
                cb1.Enabled = false;
                dtp1.Enabled = false;
            }
        }

        private void Chb6_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the combobox and date time picker if the checkbox is checked
            if (Chb6.Checked == true)
            {
                cb2.Enabled = true;
                dtp2.Enabled = true;
            }
            else
            {
                cb2.Enabled = false;
                dtp2.Enabled = false;
            }
        }

        private void Chb7_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the combobox and date time picker if the checkbox is checked
            if (Chb7.Checked == true)
            {
                cb3.Enabled = true;
                dtp3.Enabled = true;
            }
            else
            {
                cb3.Enabled = false;
                dtp3.Enabled = false;
            }
        }

        private void Chb8_CheckedChanged(object sender, EventArgs e)
        {
            //Enables the combobox and date time picker if the checkbox is checked
            if (Chb8.Checked == true)
            {
                cb4.Enabled = true;
                dtp4.Enabled = true;
            }
            else
            {
                cb4.Enabled = false;
                dtp4.Enabled = false;
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allows only text and numbers to be entered in the ModuleID textbox
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                MessageBox.Show("Only text or numbers can be inputted for the ModuleID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
    }
}
