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
using System.Drawing.Text;

namespace ModNote
{
    public partial class Main : Form
    {
        //Initialising classes
        Directories Dir = new Directories();
        Help H = new Help();
        Module[] ObjArray;

        //Initialising variables
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote";
        string filename;
        string module;
        string ReturnVal;
        bool saved;

        public Main()
        {
            InitializeComponent();

            //Calls Directories class to check if directories need to be created
            Dir.CreateDir();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //
            //
            // Modules Page
            //
            //
            LoadData();

            //
            //
            // Notes Page
            //
            //

            //Colours for text added as dropdown items
            colourToolStripMenuItem.DropDown.Items.Add("Black");
            colourToolStripMenuItem.DropDown.Items.Add("Red");
            colourToolStripMenuItem.DropDown.Items.Add("Blue");

            //Imports all fonts and adds them as dropdown items
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                fontToolStripMenuItem.DropDown.Items.Add(family.Name);
            }

            //Size for text added as dropdown items
            sizeToolStripMenuItem.DropDown.Items.Add("8");
            sizeToolStripMenuItem.DropDown.Items.Add("10");
            sizeToolStripMenuItem.DropDown.Items.Add("12");
            sizeToolStripMenuItem.DropDown.Items.Add("14");
        }

        //
        //
        // Modules Page
        //
        //
        public void LoadData()
        {
            try
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
                    ObjArray[i].ModuleAssessments = new List<string>();
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
                                        ObjArray[i].ModuleAssessments.Add(temp[j]);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        }
                    }
                    //Appends ModuleID to Combobox for each module
                    CbModules1.Items.Add(ObjArray[i].ModuleID);
                    CbAssessments1.Items.Add(ObjArray[i].ModuleID);

                    string NotesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\" + ObjArray[i].ModuleID;
                    string TempAssessment;
                    try
                    {
                        //Determine whether the directory exists
                        if (Directory.Exists(NotesPath))
                        {

                        }
                        else
                        {
                            //Creates directory for each assessment of a module in the notes folder for that module
                            DirectoryInfo di = Directory.CreateDirectory(NotesPath);

                            for (int x = 0; x < ObjArray[i].ModuleAssessments.Count; ++x)
                            {
                                TempAssessment = ObjArray[i].ModuleAssessments[x];
                                TempAssessment = TempAssessment.Replace(" = ", "_");
                                TempAssessment = TempAssessment.Replace("/", "-");
                                TempAssessment = TempAssessment.Replace("-", "_");
                                TempAssessment = TempAssessment.Replace(" ", "_");
                                NotesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\" + ObjArray[i].ModuleID + "\\" + TempAssessment;
                                di = Directory.CreateDirectory(NotesPath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The process failed: {0}", ex.ToString());
                    }
                }
            }
            catch
            {

            }
        }

        private void CbModules1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displays the correct data in the correct places
            txtModules2.Text = ObjArray[CbModules1.SelectedIndex].ModuleTitle;
            txtModules3.Text = ObjArray[CbModules1.SelectedIndex].ModuleSynopsis;
            txtModules4.Text = String.Join(Environment.NewLine, ObjArray[CbModules1.SelectedIndex].ModuleLO[0]);
            txtModules5.Text = String.Join(Environment.NewLine, ObjArray[CbModules1.SelectedIndex].ModuleLO[1]);
            txtModules6.Text = String.Join(Environment.NewLine, ObjArray[CbModules1.SelectedIndex].ModuleLO[2]);
            txtModules7.Text = String.Join(Environment.NewLine, ObjArray[CbModules1.SelectedIndex].ModuleLO[3]);
            //Sets the combo box in the assessments tab to be the same so that the same data is loaded
            CbAssessments1.SelectedItem = CbModules1.SelectedItem;
        }

        private void CbAssessments1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displays the correct data in the correct places
            txtAssessments3.Clear();
            //Sets the combo box in the assessments tab to be the same so that the same data is loaded
            CbModules1.SelectedItem = CbAssessments1.SelectedItem;
            txtAssessments2.Text = String.Join(Environment.NewLine, ObjArray[CbAssessments1.SelectedIndex].ModuleAssessments);
            //Checks if the date of the assessment has passed yet and displays the text accordingly
            for (int d = 0; d < ObjArray[CbAssessments1.SelectedIndex].AssessmentDate.Length; d++)
            {
                DateTime datetemp = (ObjArray[CbAssessments1.SelectedIndex].AssessmentDate[d]);
                if (datetemp > DateTime.Today.AddYears(-10))
                {
                    if (datetemp < DateTime.Today)
                    {
                        txtAssessments3.Text += "Date Passed\n";
                    }
                    else
                    {
                        txtAssessments3.Text += "Date Not Passed\n";
                    }
                }
            }
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            //Takes the user to the AddModule form to add a new module
            AddModule AM = new AddModule();
            AM.Show();
            this.Hide();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            //Checks if a module is being displayed, opens editing form to allow the user to amend any data
            if (CbModules1.SelectedIndex < 0)
            {
                MessageBox.Show("Please pick a module you would like to edit first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EditModule EM = new EditModule(CbModules1.Text, CbModules1.SelectedIndex);
                EM.Show();
                this.Hide();
            }
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            //Checks if a module is being displayed, deletes the module from the system
            try
            {
                if (CbModules1.SelectedIndex < 0)
                {
                    MessageBox.Show("Please pick a module you would like to delete first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Reads all lines of the module locations into an array
                    string[] ModLocations = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\ModuleLocations.txt");
                    int NoOfModules = ModLocations.Length;

                    List<string> ModulesList = new List<string>();
                    for (int i = 0; i < NoOfModules; ++i)
                    {
                        ModulesList.Add(ModLocations[i]);
                    }
                    //Removes the selected module, deletes the module data and overwrites the ModuleLocations file
                    ModulesList.RemoveAt(CbModules1.SelectedIndex);
                    File.WriteAllLines((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\ModuleLocations.txt"), ModulesList);
                    string filepath = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Modules\\" + CbModules1.Text + ".txt");
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
                    //Asks the user if they would like to delete the notes or keep them.
                    DialogResult result = MessageBox.Show("Would you like to delete all the notes for this module too?", "Delete Notes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        filepath = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\" + CbModules1.Text);
                        if (Directory.Exists(filepath))
                        {
                            Directory.Delete(filepath, true);
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        filepath = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Modules\\" + CbModules1.Text);
                        MessageBox.Show("The notes have not been deleted. They are located in: " + filepath, "Delete Notes?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MessageBox.Show("The Module was deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            }
            catch
            {
                MessageBox.Show("The Module could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        //
        // Notes Page
        //
        //

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //Calls clear method
            Clear();
        }

        private void Clear()
        {
            //Clears the textbox and variables
            txtNotes.Clear();
            toolStripNotesLabel.Text = "";
            toolStripNotesLabel.Visible = false;
            filename = null;
            module = null;
            saved = false;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //Opens a dialog box asking the user to select a rtf file
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Open";
            file.Filter = "RTF files (*.rtf)|*.rtf";
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\";
            file.InitialDirectory = path;

            //Opens the file selected in the dialog box
            if (file.ShowDialog() == DialogResult.OK)
            {
                filename = file.FileName;
                txtNotes.LoadFile(filename, RichTextBoxStreamType.RichText);
                toolStripNotesLabel.Visible = true;
                //Get the module and filename of the file
                string title = filename;
                title = title.Replace(path, "");
                title = title.Replace(Path.GetExtension(file.FileName), "");
                toolStripNotesLabel.Text = ("Module\\Title: " + title);
                module = "temp";
                saved = true;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //Calls save method
            Save();
        }
        
        private void Save()
        {
            if (CbModules1.Items.Count > 0)
            {
                if ((filename == null && module == null ) || ((module == ReturnVal)))
                {
                    //Opens the InputBox form and takes input from user
                    using (var form = new InputBox())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //Value selected from inputbox form
                            string val = form.ReturnValue1;

                            ReturnVal = val;

                            //Checks if the file is being saved for the first time
                            if (filename == null || !(module == ReturnVal))
                            {
                                //Sets path according to the selected value
                                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\" + ReturnVal;

                                //Sets file name, it is automatically generated
                                string temp = "Note - " + DateTime.Today.Date.ToString("dd-MM-yy");
                                temp = GetUniqueName(temp, path);
                                path = path + "\\" + temp + ".rtf";

                                //Saves file as a rich text file
                                txtNotes.SaveFile(path, RichTextBoxStreamType.RichText);
                                filename = path;
                                module = ReturnVal;
                                saved = true;

                                //Get the module and filename of the file
                                string title = filename;
                                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\";
                                title = title.Replace(path, "");
                                title = title.Replace(Path.GetExtension(filename), "");
                                toolStripNotesLabel.Text = ("Module\\Title: " + title);
                                toolStripNotesLabel.Visible = true;

                                MessageBox.Show("Note has been saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //Saves previously opened/saved file
                                txtNotes.SaveFile(filename, RichTextBoxStreamType.RichText);
                            }
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            MessageBox.Show("You must pick a module in order to save the note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    //Saves previously opened/saved file
                    txtNotes.SaveFile(filename, RichTextBoxStreamType.RichText);
                    saved = true;
                }
            }
            else
                MessageBox.Show("Please add a module before making notes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            string Module;
            //Opens the InputBox form and takes input from user
            //Checks if the system contains data for modules or not
            if (CbModules1.Items.Count > 0)
            {
                //Sets path
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\";

                //Sets file name
                string temp = "Note - " + DateTime.Today.Date.ToString("d");
                temp = GetUniqueName(temp, path);

                //Opens save file dialog for user to select where to save the file or to give it a different name
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "RTF files (*.rtf)|*.rtf";
                saveFileDialog1.Title = "Save a Rich Text File";
                saveFileDialog1.FileName = temp;
                saveFileDialog1.InitialDirectory = path;
                saveFileDialog1.ShowDialog();

                //Checks if user has selected a filepath to save in
                if (saveFileDialog1.FileName != "")
                {
                    //Saves file as a rich text file
                    txtNotes.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                saved = true;
                MessageBox.Show("Note has been saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (var form = new InputBox())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //Value selected from inputbox form
                        string val = form.ReturnValue1;

                        Module = val;

                        //Sets path according to the selected value
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ModNote\\Notes\\" + Module;

                        //Sets file name
                        string temp = "Note - " + DateTime.Today.Date.ToString("d");
                        temp = GetUniqueName(temp, path);

                        //Opens save file dialog for user to select where to save the file or to give it a different name
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "RTF files (*.rtf)|*.rtf";
                        saveFileDialog1.Title = "Save a Rich Text File";
                        saveFileDialog1.FileName = temp;
                        saveFileDialog1.InitialDirectory = path;
                        saveFileDialog1.ShowDialog();

                        //Checks if user has selected a filepath to save in
                        if (saveFileDialog1.FileName != "")
                        {
                            //Saves file as a rich text file
                            txtNotes.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                        }
                        saved = true;
                        MessageBox.Show("Note has been saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("You must pick a module in order to save the note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private string GetUniqueName(string name, string folderPath)
        {
            //Checks if the name inputted already exists in the path that the file is being saved into
            string validatedName = name;
            int tries = 1;
            //If the name exists a number is appended to the end of the name of the file
            while (File.Exists(folderPath + "\\" + validatedName + ".rtf"))
            {
                validatedName = string.Format("{0} [{1}]", name, tries++);
            }
            return validatedName;
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            //Opens the help dialog box
            MessageBox.Show(H.aboutText, "ModNote", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            txtNotes.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            txtNotes.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {

            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                txtNotes.Paste();
            }
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Makes selected text bold
            if (txtNotes.SelectionFont == null)
            {
                return;
            }

            FontStyle style = txtNotes.SelectionFont.Style;

            if (txtNotes.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            txtNotes.SelectionFont = new Font(txtNotes.SelectionFont, style);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Underlines selected text
            if (txtNotes.SelectionFont == null)
            {
                return;
            }

            FontStyle style = txtNotes.SelectionFont.Style;

            if (txtNotes.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            txtNotes.SelectionFont = new Font(txtNotes.SelectionFont, style);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Makes selected text italic
            if (txtNotes.SelectionFont == null)
            {
                return;
            }
            FontStyle style = txtNotes.SelectionFont.Style;

            if (txtNotes.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            txtNotes.SelectionFont = new Font(txtNotes.SelectionFont, style);
        }

        private void fontToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Changes the font of the text
            if (txtNotes.SelectionFont == null)
            {
                txtNotes.SelectionFont = new Font(e.ClickedItem.Text, txtNotes.Font.Size);
            }
            txtNotes.SelectionFont = new Font(e.ClickedItem.Text, txtNotes.SelectionFont.Size);
        }

        private void colourToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Changes the colour of the text
            KnownColor selectedColor;
            selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), e.ClickedItem.Text);

            txtNotes.SelectionColor = Color.FromKnownColor(selectedColor);
        }

        private void sizeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Changes the size of the text
            if (txtNotes.SelectionFont == null)
            {
                return;
            }
            txtNotes.SelectionFont = new Font(txtNotes.SelectionFont.FontFamily,
                Convert.ToInt32(e.ClickedItem.Text),
                txtNotes.SelectionFont.Style);
        }

        private void NotesPage_Leave(object sender, EventArgs e)
        {
            if (txtNotes.Text.Length > 0 && saved == false)
            {
                //Checks if the text box contains text, if it does it asks the user if they want to leave the tab without saving
                DialogResult result = MessageBox.Show("Are you sure you want to leave without saving?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Clear();
                }
                else if (result == DialogResult.No)
                {
                    Save();
                    Clear();
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Exits program
            if (TabControl.SelectedIndex == 4)
            {
                Application.Exit();
            }
        }
    }
}
