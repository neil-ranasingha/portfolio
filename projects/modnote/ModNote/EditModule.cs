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
    public partial class EditModule : Form
    {
        Module[] ObjArray;
        public EditModule(string ModuleID, int Index)
        {
            InitializeComponent();
            //Stores variables from call
            txt1.Text = ModuleID;
            lblIndex.Text = Convert.ToString(Index);
        }
        public List<string> ModuleData = new List<string>();
        private void EditModule_Load(object sender, EventArgs e)
        {
            LoadData();

            //Loads all the data into the correct fields
            int Index = Convert.ToInt32(lblIndex.Text);
            txt2.Text = ObjArray[Index].ModuleTitle;
            txt3.Text = ObjArray[Index].ModuleSynopsis;
            txt4.Text = ObjArray[Index].ModuleLO[0];
            Chb1.Checked = true;
            txt5.Text = ObjArray[Index].ModuleLO[1];
            Chb2.Checked = true;
            txt6.Text = ObjArray[Index].ModuleLO[2];
            Chb3.Checked = true;
            txt7.Text = ObjArray[Index].ModuleLO[3];
            Chb4.Checked = true;
            //Checks if assignment exists
            if (!(ObjArray[Index].AssessmentType[0] == null))
            {
                cb1.SelectedText = ObjArray[Index].AssessmentType[0];
                dtp1.Value = ObjArray[Index].AssessmentDate[0];
                Chb5.Checked = true;
            }
            if (!(ObjArray[Index].AssessmentType[1] == null))
            {
                cb2.SelectedText = ObjArray[Index].AssessmentType[1];
                dtp2.Value = ObjArray[Index].AssessmentDate[1];
                Chb6.Checked = true;
            }
            if (!(ObjArray[Index].AssessmentType[2] == null))
            {
                cb3.SelectedText = ObjArray[Index].AssessmentType[2];
                dtp3.Value = ObjArray[Index].AssessmentDate[2];
                Chb7.Checked = true;
            }
            if (!(ObjArray[Index].AssessmentType[3] == null))
            {
                cb4.SelectedText = ObjArray[Index].AssessmentType[3];
                dtp4.Value = ObjArray[Index].AssessmentDate[3];
                Chb8.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Takes user back to main form
            MessageBox.Show("Amending module cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Main M = new Main();
            M.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Calls the ValidateText method and if the return is true the module data is saved
                bool valid = ValidateText();
                if (valid == true)
                {
                    //Calls the SaveData to add the new data into the list and then write the list into a text file and overwrite the old file
                    SaveData();
                    string ModulePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Modules\\" + txt1.Text + ".txt";
                    File.WriteAllLines(ModulePath, ModuleData);

                    MessageBox.Show("The Module updates have been saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Takes user back to the main form
                    Main M = new Main();
                    M.Show();
                    this.Close();
                }
                else
                {
                }
            }
            catch
            {
                MessageBox.Show("The Module updates could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            //Reads all lines of the module locations into an array
            string[] ModLocations = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\ModuleLocations.txt");
            int NoOfModules = ModLocations.Length;

            //Declaring object array
            ObjArray = new Module[NoOfModules];

            //Initialising elements in object array
            for (int i = 0; i < NoOfModules; ++i)
            {
                ObjArray[i] = new Module();
                ObjArray[i].Path = ModLocations[i];
                ObjArray[i].ModuleLO = new List<string>();
                ObjArray[i].AssessmentType = new string[4];
                ObjArray[i].AssessmentDate = new DateTime[4];
                //Reads all lines of each module file into temporary array
                string[] temp = File.ReadAllLines(ObjArray[i].Path);

                //Used to determine where each bit of data is sorted into 
                int TempLoc = 0;
                int C = 0;
                //Checks each line of the array and sorts each bit of data
                for (int j = 0; j < temp.Length; j++)
                {
                    switch (temp[j])
                    {
                        case "CODE":
                            TempLoc = 1;
                            break;
                        case "TITLE":
                            TempLoc = 2;
                            break;
                        case "SYNOPSIS":
                            TempLoc = 3;
                            break;
                        case "LO":
                            TempLoc = 4;
                            break;
                        case "ASSIGNMENT":
                            TempLoc = 5;
                            break;
                        default:
                            switch (TempLoc)
                            {
                                case 0:
                                    break;
                                case 1:
                                    //Sets the Module ID as the string
                                    ObjArray[i].ModuleID = temp[j];
                                    break;
                                case 2:
                                    //Sets the Module Title as the string
                                    ObjArray[i].ModuleTitle = temp[j];
                                    break;
                                case 3:
                                    //Sets the Module Synopsis as the string
                                    ObjArray[i].ModuleSynopsis = temp[j];
                                    break;
                                case 4:
                                    //Adding each Learning Objective into the list
                                    string LO = temp[j];
                                    LO = LO.Replace("LO1 ", "");
                                    LO = LO.Replace("LO2 ", "");
                                    LO = LO.Replace("LO3 ", "");
                                    LO = LO.Replace("LO4 ", "");
                                    ObjArray[i].ModuleLO.Add(LO);
                                    break;
                                case 5:
                                    //Adding each assessment into the list
                                    string temp1 = temp[j];
                                    string[] temp2 = temp1.Split('=');
                                    string temp3 = temp2[0].TrimEnd(' ');
                                    ObjArray[i].AssessmentType[C] = temp2[0];
                                    ObjArray[i].AssessmentDate[C] = Convert.ToDateTime(temp2[1]);
                                    C++;
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                }
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

        private void SaveData()
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
                ModuleData.Add(cb1.Text + " = " + dtp1.Value.Date.ToString("dd/MM/yyyy"));
            if (Chb6.Checked == true)
                ModuleData.Add(cb2.Text + " = " + dtp2.Value.Date.ToString("dd/MM/yyyy"));
            if (Chb7.Checked == true)
                ModuleData.Add(cb3.Text + " = " + dtp3.Value.Date.ToString("dd/MM/yyyy"));
            if (Chb8.Checked == true)
                ModuleData.Add(cb4.Text + " = " + dtp4.Value.Date.ToString("dd/MM/yyyy"));
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

    }
}
