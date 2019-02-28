using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Caesar_Cipher
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Neil's Caesar Cipher Program!");
            //Sets the size of the console screen.
            Console.BufferWidth = 400;
            Console.BufferHeight = 1000;

            //While loop so that when an operation has completed or if there is an exception or wrong input is entered, code is run again.
            bool check = true;
            while (check)
            {
                try
                {
                    Console.WriteLine("\nWould you like to: \nEncrypt (E)\nDecrypt (D)\nQuit (Q)");
                    Global.Ans = Convert.ToChar(Console.ReadLine());
                    switch (Global.Ans)
                    {
                        case 'e':
                        case 'E':
                            Console.WriteLine("\nDo you want to import a txt file to Encrypt? (Y|N)\n");
                            Global.Ans = Convert.ToChar(Console.ReadLine());
                            switch (Global.Ans)
                            {
                                case 'y':
                                case 'Y':
                                    //Allows the user to import a txt file to encrypt.
                                    OpenFileDialog ofd = new OpenFileDialog
                                    {
                                        Multiselect = false,
                                        Title = "Open Text Document",
                                        //Allows only txt files to be opened.
                                        Filter = "Text Document|*.txt"
                                    };
                                    ofd.ShowDialog();
                                    //Imports the txt file and reads it.
                                    Global.Text = File.ReadAllText(ofd.FileName);
                                    Global.Text = Global.Text.ToUpper();
                                    Console.WriteLine("Text:\n{0}\n\nShift: 0\n" + "--------------------------------------------------------------------------------", Global.Text);
                                    while (check)
                                    {
                                        //Asks user how they would like the results to be outputted.
                                        Console.WriteLine("\nChoose output type:\nA = Show all shifts in the range given.\nB = Show only the chosen shift.\n");
                                        Global.Ans = Convert.ToChar(Console.ReadLine());
                                        switch (Global.Ans)
                                        {
                                            case 'a':
                                            case 'A':
                                                Global.ShiftType = 0;
                                                check = false;
                                                break;
                                            case 'b':
                                            case 'B':
                                                Global.ShiftType = 1;
                                                check = false;
                                                break;
                                        }
                                    }
                                    check = true;
                                    while (check)
                                    {
                                        //Asks the user how many shifts they would like to do.
                                        Console.WriteLine("\nHow many shifts would you like to do? (Enter a number between 1-25)\n");
                                        Global.AnsInt = Convert.ToInt32(Console.ReadLine());
                                        if ((Global.AnsInt > 0) && (Global.AnsInt < 26))
                                        {
                                            //Sets the ShiftNumber to the number inputted by the user.
                                            Global.ShiftNumber = Global.AnsInt;
                                            check = false;
                                        }
                                    }
                                    check = true;
                                    //Link to Encryption Class.
                                    Encryption.Encrypt();
                                    break;
                                case 'n':
                                case 'N':
                                    Console.WriteLine("\nPlease enter the string you wish to encrypt here:\n");
                                    Global.Text = Console.ReadLine();
                                    Global.Text = Global.Text.ToUpper();
                                    Console.WriteLine("Text:\n{0}\n\nShift: 0\n", Global.Text);
                                    while (check)
                                    {
                                        //Asks user how they would like the results to be outputted.
                                        Console.WriteLine("\nChoose output type:\nA = Show all shifts in the range given.\nB = Show only the chosen shift.\n");
                                        Global.Ans = Convert.ToChar(Console.ReadLine());
                                        switch (Global.Ans)
                                        {
                                            case 'a':
                                            case 'A':
                                                Global.ShiftType = 0;
                                                check = false;
                                                break;
                                            case 'b':
                                            case 'B':
                                                Global.ShiftType = 1;
                                                check = false;
                                                break;
                                        }
                                    }
                                    check = true;
                                    while (check)
                                    {
                                        //Asks the user how many shifts they would like to do.
                                        Console.WriteLine("\nHow many shifts would you like to do? (Enter a number between 1-25)\n");
                                        Global.AnsInt = Convert.ToInt32(Console.ReadLine());
                                        if ((Global.AnsInt > 0) && (Global.AnsInt < 26))
                                        {
                                            //Sets the ShiftNumber to the number inputted by the user.
                                            Global.ShiftNumber = Global.AnsInt;
                                            check = false;
                                        }
                                    }
                                    check = true;
                                    //Link to Encryption Class
                                    Encryption.Encrypt();
                                    break;
                            }
                            break;
                        case 'd':
                        case 'D':
                            Console.WriteLine("\nDo you want to import a txt file to Decrypt? (Y|N)\n");
                            Global.Ans = Convert.ToChar(Console.ReadLine());
                            switch (Global.Ans)
                            {
                                case 'y':
                                case 'Y':
                                    //Allows the user to import a txt file to decrypt.
                                    OpenFileDialog ofd = new OpenFileDialog
                                    {
                                        Multiselect = false,
                                        Title = "Open Text Document",
                                        //Allows only txt files to be opened.
                                        Filter = "Text Document|*.txt"
                                    };
                                    ofd.ShowDialog();
                                    //Imports the txt file and reads it.
                                    Global.Text = File.ReadAllText(ofd.FileName);
                                    Global.Text = Global.Text.ToUpper();
                                    Console.WriteLine("Encoded text:\n{0}\n\nShift: 0\n" + "--------------------------------------------------------------------------------", Global.Text);
                                    //Link to Decryption Class.
                                    Decryption.Decrypt();
                                    break;
                                case 'n':
                                case 'N':
                                    Console.WriteLine("\nPlease enter the string you wish to decrypt here:\n");
                                    Global.Text = Console.ReadLine();
                                    Global.Text = Global.Text.ToUpper();
                                    Console.WriteLine("Encoded text:\n{0}\n\nShift: 0\n", Global.Text);
                                    //Link to Decryption Class.
                                    Decryption.Decrypt();
                                    break;
                            }
                            break;
                        case 'q':
                        case 'Q':
                            //Exits application.
                            check = false;
                            Console.WriteLine("Exiting Program.");
                            Console.Read();
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception e)
                {
                    //In any case of exception a message will be shown.
                    Console.WriteLine("\nError: {0}\nPlease try again.\n", e.Message);
                }
            }
        }
    }
    class Encryption
    {
        //An object used to call the other methods within this class.
        public static Encryption Object1 = new Encryption();
        public static void Encrypt()
        {
            //Starts a stopwatch as soon as the Encryption method is started.
            Global.watch.Start();

            //Reset global variables.
            Global.decode = "";
            Global.result = "";
            Global.FinalOut = "";

            //If the user wants each shift to be outputted in the range given, this code is executed.
            if (Global.ShiftType == 0)
            {
                //For loop from 1 to the user's input (1-25) to operate the all shifts in the range given.
                for (Global.ShiftCount = 1; Global.ShiftCount <= Global.ShiftNumber; Global.ShiftCount++)
                {
                    //Calls RightShift to find all possible shifts to the right.
                    Object1.RightShift();

                    //Adds a space between shifts in every print.
                    Global.result = Global.result + "\r\n------------------------------------------" + "\r\nShift: " + Global.ShiftCount + "\r\n------------------------------------------\r\n\n";
                }
            }
            //If the user wants the output to only contain the shift they have given, this code is executed.
            else if (Global.ShiftType == 1)
            {
                //Sets ShiftCount.
                Global.ShiftCount = Global.ShiftNumber;

                //Calls RightShift to find all possible shifts to the right.
                Object1.RightShift();

                //Adds a space between shifts.
                Global.result = Global.result + "\r\nShift: " + Global.ShiftCount + "\r\n\n";
            }
            //Outputs the encrypted text.
            Global.FinalOut = Global.result;
            Console.WriteLine(Global.FinalOut);

            //Stops the stopwatch and stores the time into a variable and displays it to the user.
            Global.watch.Stop();
            var elapsedMs = Global.watch.ElapsedMilliseconds;
            Console.WriteLine("Elapsed time for encryption: {0}Ms\n", elapsedMs);

            //Exports the outputs into a text file on the users desktop.
            string path = Environment.CurrentDirectory;
            StreamWriter file = new StreamWriter(path + @"\caesarShiftEncodedCustomText.txt", false);
            file.WriteLine(Global.FinalOut);
            file.Close();
        }

        public void RightShift()
        {
            foreach (char c in Global.Text)
            {
                //Determines the ASCII value for each character in the text.
                int ascii = (char)c;
                if ((ascii >= 65) && (ascii <= 90))
                {
                    /*Checks if the ASCII value of the character is within the A-Z (65-90) range.
                    Then takes away the value of the ShiftCount from the ASCII value.
                    Performing the right shift.*/
                    ascii += Global.ShiftCount;
                    if (ascii > 90)
                        ascii -= 26;
                    /*Then checks if the new ASCII value is more than Z (90).
                    If it is, 26 is subtracted to the current ASCII value.*/
                }

                //Converts the ASCII value back to a character and appends the new character to the 'result' string variable.
                char newchar = (char)ascii;
                Global.result += newchar;
            }
        }
    }
    class Decryption
    {
        //An object used to call the other methods within this class.
        public static Decryption Object2 = new Decryption();
        public static void Decrypt()
        {
            //Starts a stopwatch as soon as the Decryption method is started.
            Global.watch.Start();

            //Reset global variables.
            Global.decode = "";
            Global.Frequencies.Clear();
            Global.FreqAnalysis = "";
            Global.MaxFreq = 0;
            Global.result = "";
            Global.FinalOut = "";

            //Calls AnalyseFrequency to find the find the frequencies of each letter and find the most common letter and then use that to find the correct shift.
            Global.Frequencies = AnalyseFrequency();

            //Gets Shift key value.
            Object2.ShiftFinder();

            //For loop from 1-25 to operate the 24 shifts.
            for (Global.ShiftCount = 1; Global.ShiftCount <= 25; Global.ShiftCount++)
            {
                //Calls LeftShift to find all possible shifts to the left.
                Object2.LeftShift();

                //Adds a space between shifts in every print.
                Global.result = Global.result + "\r\n------------------------------------------" + "\r\nShift: " + Global.ShiftCount + "\r\n------------------------------------------\r\n\n";
            }

            //Outputs the decrypted text and the frequency of each letter in the encoded text.
            Global.decode = "------Decryption------\r\n" + Global.decode;
            Global.FinalOut = "\r\n" + Global.result + "\r\n" + Global.decode + "\r\n\n" + Global.FreqAnalysis;
            Console.WriteLine(Global.FinalOut);

            //Outputs the most frequent character and the shift that outputs the decoded text.
            Console.WriteLine(string.Format("\nThe most frequent character is: {0}", Global.MostFrequentChar));
            Console.WriteLine(string.Format("Shift Key would be: {0}", Global.ShiftKey));

            //Stops the stopwatch and stores the time into a variable and displays it to the user.
            Global.watch.Stop();
            var elapsedMs = Global.watch.ElapsedMilliseconds;
            Console.WriteLine("\nElapsed time for decryption: {0}Ms\n", elapsedMs);

            //Exports the outputs into a text file on the users desktop.
            string path = Environment.CurrentDirectory;
            StreamWriter file = new StreamWriter(path + @"\caesarShiftPlainText.txt", false);
            file.WriteLine(Global.FinalOut);
            file.Close();
        }

        public void LeftShift()
        {
            foreach (char c in Global.Text)
            {
                //Determines the ASCII value for each character in the encoded text.
                int ascii = (int)c;
                if ((ascii >= 65) && (ascii <= 90))
                {
                    /*Checks if the ASCII value of the character is within the A-Z (65-90) range.
                    Then takes away the value of the ShiftCount from the ASCII value.
                    Performing the left shift.*/
                    ascii -= Global.ShiftCount;
                    if (ascii < 65)
                        ascii += 26;
                    /*Then checks if the new ASCII value is less than A (65).
                    If it is, 26 is added to the current ASCII value.*/
                }

                //Converts the ASCII value back to a character and appends the new character to the 'result' string variable.
                char newchar = (char)ascii;
                Global.result += newchar;
                /*This is where the correct decryption text is extracted.
                An if statement checks if the current ShiftCount is the same as the ShiftKey of the correct decryption text.
                If it is, the current decryption text is appended to the 'decode' string variable.*/
                if (Global.ShiftCount == Global.ShiftKey)
                    Global.decode += newchar;
            }
        }

        static Dictionary<char, double> AnalyseFrequency()
        {
            //Removes All white spaces from the text and calculates the length.
            string Spaces = "";
            Spaces = Global.Text.Replace(" ", String.Empty);
            Spaces = Spaces.Replace("\r\n", String.Empty);
            int TextLength = Spaces.Length;

            //For loop to count the frequency of each character in the encoded text.
            for (int i = 0; i < TextLength; i++)
            {
                char c = Spaces[i];
                char key = ' ';

                //Ignores characters that are not upper case letters or some selected symbols.
                if ((c >= 'A' && c <= 'Z'))
                    key = c;
                else if ((c >= 33 && c <= 47) || (c >= 58 && c <= 64))
                    key = c;

                /*Every time a character is passed a check is made to see if the character exists in the Frequencies array.
                If it doesn't, the character's frequency becomes 1.
                If it does, the character's frequency is incremented by 1.*/
                if (Global.Frequencies.Keys.Contains(key))
                    Global.Frequencies[key] = Global.Frequencies[key] + 1;
                else
                    Global.Frequencies[key] = 1;
            }
            //Creates a list containing each character and its frequency.
            List<char> keys = Global.Frequencies.Keys.ToList();
            keys.Sort();

            Global.FreqAnalysis = "Frequency Analysis of encoded text:\r\n-----------------------------------\r\n";

            //Calculates the percentage of frequency of each character and displays it.
            foreach (char c in keys)
            {
                Global.Frequencies[c] = (Global.Frequencies[c] / TextLength) * 100;
                Global.FreqAnalysis = Global.FreqAnalysis + "\rCharacter: " + c + "  Frequency: " + Math.Round(Global.Frequencies[c], 2) + "%\r\n";
                //Checks for the most frequent character and then stores it in the MostFrequentChar variable.
                if (Global.Frequencies[c] > Global.MaxFreq)
                {
                    Global.MaxFreq = Global.Frequencies[c];
                    Global.MostFrequentChar = c;
                }
            }
            return Global.Frequencies;
        }

        public int ShiftFinder()
        {
            /*Finds the amount of shifts required to do to decrypt the text correctly.
            To do this, the difference in distance in the alphabet of the most frequent character in the text and the letter 'E' is calculated.
            This difference becomes the ShiftKey, which if used, the text would be decrypted. 
            This will only work correctly if the most frequent letter in the decrypted/plain text is the letter 'E'.*/
            Global.ShiftKey = (char)(Global.MostFrequentChar - 'E');
            return Global.ShiftKey;
        }

    }
    public static class Global
    {
        //This class stores all the variables which are needed in multiple classes.
        public static string result = "", decode = "", FinalOut = "", Text = "", FreqAnalysis = "";
        public static char Ans = ' ', MostFrequentChar = ' ';
        public static int AnsInt = 0, ShiftNumber = 0, ShiftCount = 0, ShiftKey = 0, ShiftType = 0;
        public static double MaxFreq = 0;
        //Used to count the frequency of each character in the text.
        public static Dictionary<char, double> Frequencies = new Dictionary<char, double>();
        //Stopwatch to record how long the Encryption or Decryption classes take to process.
        public static Stopwatch watch = new Stopwatch();
    }
}
