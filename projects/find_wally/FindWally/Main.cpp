// Neil Miran Ranasingha 2016
// FindWally.cpp : Defines the entry point for the console application.
//

#include <sstream> // stringstream
#include <iostream> // cout, cerr
#include <fstream> // ifstream
#include <ctime> // clock_t

#include "BaseImage.h"
#include "LargeImage.h"
#include "MatchImage.h"

using namespace std;

// Reads .txt file representing an image of R rows and C Columns stored in filename 
// and converts it to a 1D array of doubles of size R*C
// Memory allocation is performed inside readTXT
double* readTXT(char *fileName, int sizeR, int sizeC);

// Converts a 1D array of doubles of size R*C to .pgm image of R rows and C Columns 
// and stores .pgm in filename
// Use Q = 255 for greyscale images and Q=1 for binary images.
void WritePGM(string filename, double *data, int sizeR, int sizeC, int Q);


int main()
{
	bool Oloop = false;
	//While loop to keep looping program unless user choses otherwise
	while (!Oloop)
	{
		//N_Temp stores the number of best matches to be displayed
		int N_Temp = 0;
		string temp;
		bool Iloop = false;
		//While loop for user to choose the number matches to be displayed
		while (!Iloop)
		{
			try
			{
				cout << "Please specify number of best matches to be listed (More than 0):" << endl;
				cin >> temp;
				N_Temp = stoi(temp);
				if ( N_Temp < 1)
					cout << "The number you have specified is too low. Please try again.\n" << endl;
				else
					Iloop = true;
			}
			catch (exception e)
			{
				cout << "Incorrect format. Please enter a number.\n" << endl;
			}
		}

		//Variables that store the row and col for the linear seach 
		int rows = 0;
		int cols = 0;
		int incrR = 0;
		int incrC = 0;

		//M and N represent the number of rows and columns in the images 
		int M = 768; int N = 1024; //Cluttered scene
		int O = 49; int P = 36; //Wally Image

		//While loop for user to choose the speed of the linear search
		char ans = ' ';
		Iloop = false;
		while (!Iloop)
		{
			cout << "Please choose speed of search:" << endl;
			cout << "---> 'a' <--- VERY SLOW\n Linear search: [1 Row by 1 Col]\n Most Accurate, Least Efficient.\n 713,069 Blocks compared.\n" << endl;
			cout << "---> 'b' <--- SLOW\n Linear search: [6 Rows by 1 Col]\n Fairly Accurate, Not Very Efficient.\n 119,669 Blocks compared.\n" << endl;
			cout << "---> 'c' <--- FAST\n Linear search: [12 Rows by 3 Cols]\n Not very Accurate, Very Efficient.\n 20,191 Blocks compared.\n" << endl;
			cout << "---> 'd' <--- VERY FAST\n Linear search: [12 Rows by 6 Cols]\n LEAST Accurate, Most Efficient.\n 10,126 Blocks compared.\n" << endl;
			cin >> ans;
			switch (ans)
			{
			case 'a':
				////1r by 1c 713,069 Blocks
				//-------------------------- Most Accurate/Least Efficient
				rows = ((M - 48) / 1);
				cols = ((N - 35) / 1);
				incrR = 1;
				incrC = 1;
				Iloop = true;
				break;
			case 'b':
				////6r by 1c 119,669 Blocks 
				//-------------------------- Fairly Accurate/Not Very Efficient
				rows = ((M - 48) / 6);
				cols = ((N - 35) / 1);
				incrR = 6;
				incrC = 1;
				Iloop = true;
				break;
			case 'c':
				////12r by 3c 20,191 Blocks
				//-------------------------- Not very Accurate/Very Efficient
				rows = ((M - 48) / 12);
				cols = ((N - 31) / 3);
				incrR = 12;
				incrC = 3;
				Iloop = true;
				break;
			case 'd':
				////1r by 1c 10,126 Blocks
				//-------------------------- LEAST Accurate/Most Efficient
				rows = ((M - 48) / 12);
				cols = ((N - 28) / 6);
				incrR = 12;
				incrC = 6;
				Iloop = true;
				break;
			default:
				cout << "Invalid choice. Please Try again." << endl;
			}
		}

		//Starts a clock to determine how long the program takes to import, process and export data
		//Starts after user has finished inputting information so it only times computing time
		clock_t start;
		double duration;
		start = clock();

		//input_data and wally_data are pointers to a 1D array of M*N doubles stored in heap. Memory allocation is performed inside readTXT. 
		//readTXT will read an image (in .pgm format) of size MxN and will store the result in input_data.
		double* input_data = 0;
		double* wally_data = 0;

		//.pgm image is stored in inputFileName, change the path in your program appropriately
		char* inputFileName = "Text_Files\\Cluttered_scene.txt";
		char* WallyFileName = "Text_Files\\Wally_grey.txt";
		
		//Reads text files into variable
		input_data = readTXT(inputFileName, M, N);
		wally_data = readTXT(WallyFileName, O, P);

		//Initialising class objects
		LargeImage LargeObj(M, N, input_data);
		BaseImage BaseObj(O, P, wally_data);
		MatchImage MatchObj(O, P, LargeObj.getBlock(0, O, 0, P), BaseObj.getData(), N_Temp);

		cout << "----------Data from files imported successfully----------\n" << endl;

		//----Experiment----
		//LargeObj.experiment(144, 193, 162, 198);

		//Variables to store row and column positions
		int sr = 0, er = 49, sc = 0, ec = 36;
		int r = er - sr;
		int c = ec - sc;
		//Variable to keep track of how many blocks are being compared to wally
		int blockC = 0;
		//Variable to temporarily store the NC_Score
		double NC_Temp = 0;
		
		for (int i = 0; i <= rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				//Checks if the row counter or column counter has exceeded the size of the full image 
				if (er <= M && ec <= N)
				{
					//Extracts a block from the cluttered scene and stores it temporarily in the MatchImage class
					MatchObj.getNewBlock(r, c, LargeObj.getBlock(sr, er, sc, ec));
					//Calculates the NC score and temporarily stores it in the variable
					NC_Temp = MatchObj.NC();
					//Determines the N_Best results, comparing each NC score to see which is the highest and stores it in descending order
					MatchObj.N_best(NC_Temp, sr, er, sc, ec);

					//Can be used to display the blocks being compared, along with the NC score
					//cout << "(Row: " << sr << " to " << er << ") (Column: " << sc << " to " << ec << ") " << endl;
					//cout << "Block: " << blockC << " Result: " << NC_Temp << endl;

					//Increments column
					sc += incrC;
					ec += incrC;
					//Increments block counter
					blockC++;
				}
				else
				{
					//This gets the remainder of the image that is less than the size of the Wally picture
					//The block stays the same size however, it simply overlaps part of the image that has already been processed
					int temp1 = 0;
					if (er >= M)
					{
						temp1 = er - M;
						er = er - temp1;
						sr = M - O;
					}
					if (ec >= N)
					{
						temp1 = ec - N;
						ec = ec - temp1;
						sc = N - P;
					}

					//Extracts a block from the cluttered scene and stores it temporarily in the MatchImage class
					MatchObj.getNewBlock(r, c, LargeObj.getBlock(sr, er, sc, ec));
					//Calculates the NC score and temporarily stores it in the variable
					NC_Temp = MatchObj.NC();
					//Determines the N_Best results, comparing each NC score to see which is the highest and stores it in descending order
					MatchObj.N_best(NC_Temp, sr, er, sc, ec);

					//Can be used to display the blocks being compared, along with the NC score
					//cout << "----(Row: " << sr << " to " << er << ") (Column: " << sc << " to " << ec << ") " << endl;
					//cout << "Block: " << blockC << " Result: " << NC_Temp << endl;

					//Increments column
					sc += incrC;
					ec += incrC;
					//Increments block counter
					blockC++;
				}
			}
			//Increments row
			sr += incrR;
			er += incrR;
			//Resets column
			sc = 0;
			ec = 36;
		}

		//Outputs the N_best results from the NC algorithm
		cout << "Search complete shifting blocks " << incrR << "(Row/s) by " << incrC << "(Column/s) pixels." << endl;
		cout << "Blocks analyzed: " << blockC << endl;
		cout << "\nTop " << N_Temp << " NC Scores:" << endl;
		int num = 1;
		for (int x = (N_Temp - 1); x >= 0; x--)
		{
			cout << "#" << num << " " << "NC Score: " << MatchObj.NC_Block[x][0] << " from block " << "(Row: " << MatchObj.NC_Block[x][1] << " to " << MatchObj.NC_Block[x][2] << ") (Column: " << MatchObj.NC_Block[x][3] << " to " << MatchObj.NC_Block[x][4] << ")" << endl;
			num++;
		}
		cout << endl;
		
		// Writes data back to .pgm file stored in outputFileName
		string outputFileName = "Outputs\\Cluttered_scene.pgm";
		// Q changes whether the image output is in greyscale or binary. 
		// Q = 255 for greyscale images and 1 for binary images.
		int Q = 255;
		WritePGM(outputFileName, input_data, M, N, Q);
		
		//Exports the Wally image into a greyscale image.
		outputFileName = "Outputs\\Wally_Grey.pgm";
		WritePGM(outputFileName, wally_data, O, P, Q);

		for (int i = (N_Temp - 1); i >= 0; i--)
		{
			//Creates a copy of the LargeObj class
			LargeImage LargeObjCopy = LargeObj;
			//Draws a box around the block in which the match is found
			LargeObjCopy.drawBox(MatchObj.NC_Block[i][1], MatchObj.NC_Block[i][2], MatchObj.NC_Block[i][3], MatchObj.NC_Block[i][4]);

			if (i == (N_Temp - 1))
			{
				//Exports the scattered image with a box around where Wally is found, as a greyscale image.
				outputFileName = "Outputs\\Wally_Result.pgm";
				WritePGM(outputFileName, LargeObjCopy.getData(), M, N, Q);
			}
			else
			{
				outputFileName = "Outputs\\Result_" + to_string(i + 1) + "_Best.pgm";
				//Exports the scattered image with a box around where Wally is found, as a greyscale image.
				WritePGM(outputFileName, LargeObjCopy.getData(), M, N, Q);
			}
			LargeObjCopy.Destroy();
		}

		cout << "----------Data exported successfully----------\n" << endl;

		//Deletes data
		delete[] input_data;
		delete[] wally_data;
		//Calls virtual function that clears memory in _data used by each class
		BaseObj.Destroy();
		LargeObj.Destroy();
		MatchObj.Destroy();

		//Clock stops and outputs time taken
		duration = (clock() - start) / (double)CLOCKS_PER_SEC;
		cout << "Total Time Taken: " << duration << " seconds" << endl;
		cout << "(Only includes Import/Calculation/Export for time)" << endl;

		//Ask if the user wants to run the program again
		Iloop = false;
		while (!Iloop)
		{
			cout << "\nRun program again?" << endl;
			cout << "y = Yes\nn = No" << endl;
			cin >> ans;
			switch (ans)
			{
			case 'y':
				Iloop = true;
				break;
			case 'n':
				Iloop = true;
				Oloop = true;
				break;
			default:
				cout << "Invalid format. Please try again." << endl;
				break;
			}
			cout << endl;
		}
	}
	return 0;
}


// Read .txt file with image of size RxC, and convert to an array of doubles
double* readTXT(char *fileName, int sizeR, int sizeC)
{
	double* data = new double[sizeR*sizeC];
	int i = 0;
	ifstream myfile(fileName);
	if (myfile.is_open())
	{

		while (myfile.good())
		{
			if (i>sizeR*sizeC - 1) break;
			myfile >> *(data + i);
			i++;
		}
		myfile.close();
	}

	else
	{
		cout << "Unable to open file" << endl;
		exit(1);
	}
	return data;
}

// Convert data from double to .pgm stored in filename
void WritePGM(string filename, double *data, int sizeR, int sizeC, int Q)
{
	int i = 0, j = 0;
	unsigned char *image;
	ofstream myfile;

	image = (unsigned char *) new unsigned char[sizeR*sizeC];

	// convert the integer values to unsigned char

	for (i = 0; i<sizeR*sizeC; i++)
		image[i] = (unsigned char)data[i];

	myfile.open(filename, ios::out | ios::binary | ios::trunc);

	if (!myfile) {
		cout << "Can't open file: " << filename << endl;
		exit(1);
	}

	myfile << "P5" << endl;
	myfile << sizeC << " " << sizeR << endl;
	myfile << Q << endl;

	myfile.write(reinterpret_cast<char *>(image), (sizeR*sizeC) * sizeof(unsigned char));

	if (myfile.fail()) {
		cout << "Can't write image " << filename << endl;
		exit(1);
	}

	myfile.close();

	delete[] image;
}