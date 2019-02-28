#include "MatchImage.h"
#include "BaseImage.h"

//Default Constructor
MatchImage::MatchImage()
{
}

//Constructor
MatchImage::MatchImage(int Rows, int Cols, double* input_data, double* Wdata, int N)
{
	_M = Rows;
	_N = Cols;
	_data = new double[(_M * _N)]; //Allocate memory space
	for (int i = 0; i < (_M * _N); i++) //Populate with data
	{
		_data[i] = input_data[i];
	}

	//Resizes the vector to contain N empty rows
	NC_Block.resize(N, vector<double>(1, 0));

	//Calls the WallyCalc function to work out calculations needed for the NC algorithm with the Wally data
	//Therefore not required to repeat this set of calculations repeatedly
	WallyData = new double[(_M * _N)];
	WallyCalc(Wdata);
}

//Destructor: Deletes all stored data
MatchImage::~MatchImage()
{
	Temp_Store.clear();
	NC_Block.clear();
	delete WallyData;
}

//Gets block of data from data stored in _data
void MatchImage::getNewBlock(int Rows, int Cols, double* input_data)
{
	delete[] _data;
	_M = Rows;
	_N = Cols;
	_data = new double[(_M * _N)]; //Allocate memory space
	for (int i = 0; i < (_M * _N); i++) //Populate with data
	{
		_data[i] = input_data[i];
	}
}

//Gets all the data stored in _data
double* MatchImage::getData()
{
	return _data;
}

//NNS Algorithm
//Calculates normalised correlation between wally and extracted block data
double MatchImage::NC()
{
	int count = 0;
	double sum = 0, mean = 0;
	double topSum = 0, botSum = 0;
	double NC_Score = 0;

	//sum of block array
	for (int x = 0; x < (_M * _N); x++)
	{
		//Checks if the pixel data for the Wally image is equivalent to white
		//Skips white pixels in Wally image
		if (WallyData[x] != 255)
		{
			sum += _data[x];
			count++;
		}
	}

	//mean of block array
	mean = (sum / count);

	//array - mean
	for (int x = 0; x < (_M * _N); x++)
	{
		//Skips white pixels in Wally image
		if (WallyData[x] != 255)
			_data[x] -= mean;
	}

	//top half of equation
	//sum of wally * block of data for each element

	//bottom half of equation
	//sum of block squared
	sum = 0;
	for (int x = 0; x < (_M * _N); x++)
	{
		//Skips white pixels in Wally image
		if (WallyData[x] != 255)
		{
			//top half of equation
			topSum += (WallyData[x] * _data[x]);
			//bottom half of equation
			sum += (_data[x] * _data[x]);
		}
	}

	//multiply sums together
	botSum = (WallySqr * sum);

	//square root the above
	botSum = sqrt(botSum);

	//Final NC
	//top half divided by bottom half
	NC_Score = (topSum / botSum);

	return NC_Score;
}

//Sorts top N results 
void MatchImage::N_best(double NC, int sr, int er, int sc, int ec)
{
	Temp_Store.clear();
	//Temporarily stores the NC score and block data for the latest block compared
	Temp_Store.push_back(NC);
	Temp_Store.push_back(sr);
	Temp_Store.push_back(er);
	Temp_Store.push_back(sc);
	Temp_Store.push_back(ec);

	for (int i = 0; i < NC_Block.size(); i++)
	{
		if (NC > NC_Block[i][0])
		{
			//Appends the temp vector to end of 2D vector
			//Each row represents a block and its data
			NC_Block.push_back(Temp_Store);
			//Sorts 2D vector in descending order according to the NC score 
			sort(NC_Block.begin(), NC_Block.end());
			//Deletes top/lowest NC value in 2D vector along with the block data
			NC_Block.erase(NC_Block.begin());
			break;
		}
	}
}

//Works out the calculations needed for the NC algorithm with the Wally data
void MatchImage::WallyCalc(double* data)
{
	int count = 0;
	double sum = 0;
	double mean = 0;

	//sum of Wally array
	for (int x = 0; x < (_M * _N); x++)
	{
		//Checks if the pixel data for the Wally image is equivalent to white
		//Skips white pixels in Wally image
		if (data[x] != 255)
		{
			sum += data[x];
			count++;
		}
		//Stores Wally data in WallyD
		WallyData[x] = data[x];
	}

	//mean of Wally array
	mean = (sum / count);

	for (int x = 0; x < (_M * _N); x++)
	{
		//Skips white pixels in Wally image
		if (data[x] != 255)
		{
			//array - mean
			WallyData[x] -= mean;
			//Square Wally
			WallySqr += (WallyData[x] * WallyData[x]);
		}
	}
}