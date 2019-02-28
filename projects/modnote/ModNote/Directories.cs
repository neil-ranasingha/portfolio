using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ModNote
{
    class Directories
    {
        public void CreateDir()
        {
            string path = Environment.CurrentDirectory + "\\ModNote";
            try
            {
                // Determine whether the directory in the documents folder exists.
                if (Directory.Exists(path))
                {
                    //Ensures that the ModuleLocations text file contains the correct and updated locations of the Modules text files
                    path = Environment.CurrentDirectory + "\\ModNote\\Modules";
                    string[] FileDirs = Directory.GetFiles(path);
                    //Creates a list and adds each filepath into the list
                    List<string> ModulesList = new List<string>();
                    for (int i = 0; i < FileDirs.Length; i++)
                    {
                        ModulesList.Add(FileDirs[i]);
                    }
                    //List is then written into the text file
                    File.WriteAllLines((Environment.CurrentDirectory + "\\ModNote\\ModuleLocations.txt"), ModulesList);
                    return;
                }
                else
                {
                    //Creates the directories in the documents folder.
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    path = Environment.CurrentDirectory + "\\ModNote\\Modules";
                    di = Directory.CreateDirectory(path);

                    path = Environment.CurrentDirectory + "\\ModNote\\Notes";
                    di = Directory.CreateDirectory(path);
                    //Creates a file for the module locations
                    path = Environment.CurrentDirectory + "\\ModNote\\ModuleLocations.txt";
                    File.Create(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The process failed: " + ex.ToString());
            }
        }
    }
}
