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
    public partial class InputBox : Form
    {
        Module[] ObjArray;
        public InputBox()
        {
            InitializeComponent();
        }

        public string ReturnValue1 { get; set; }

        private void InputBox_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //Reads all the module locations into an array
            string[] ModLocations = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\ModuleLocations.txt");
            int NoOfModules = ModLocations.Length;

            ObjArray = new Module[NoOfModules];

            for (int i = 0; i < NoOfModules; ++i)
            {
                ObjArray[i] = new Module();
                ObjArray[i].Path = ModLocations[i];
                //Reads all lines of each module file into temporary array
                string[] temp = File.ReadAllLines(ObjArray[i].Path);

                //Used to determine where each bit of data is sorted into 
                int TempLoc = 0;
                //Checks each line of the array and sorts each bit of data
                for (int j = 0; j < temp.Length; j++)
                {
                    switch (temp[j])
                    {
                        case "CODE":
                            TempLoc = 1;
                            break;
                        case "TITLE":
                            TempLoc = 0;
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
                                default:
                                    break;
                            }
                            break;
                    }
                }
                //Adds each ModuleID into the combo box as an item
                CbInput1.Items.Add(ObjArray[i].ModuleID);
            }
        }

        private void btnInputOK_Click(object sender, EventArgs e)
        {
            //Checks if a value has been selected, if it has this value is returned to the main form.
            if (CbInput1.Text == "")
            {
                MessageBox.Show("Please enter a Module first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ReturnValue1 = CbInput1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnInputCancel_Click(object sender, EventArgs e)
        {
            //Closes form and takes user back to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
