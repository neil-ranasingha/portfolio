#include "LargeImage.h"
#include "BaseImage.h"

//Default Constructor
LargeImage::LargeImage()
{
}

//Constructor
LargeImage::LargeImage(int Rows, int Cols, double* input_data)
{
	_M = Rows;
	_N = Cols;
	_data = new double[(_M * _N)]; //Allocate memory space
	for (int i = 0; i < (_M * _N); i++) //Populate with data
	{
		_data[i] = input_data[i];
	}
}

//CopyConstructor
LargeImage::LargeImage(const LargeImage& copy)
{
	this->_M = copy._M;
	this->_N = copy._N;
	this->_data = new double[(this->_M * this->_N)]; //Allocate memory space
	for (int i = 0; i < (this->_M * this->_N); i++) //Populate with data
	{
		this->_data[i] = copy._data[i];
	}
}

//Destructor: Deletes all stored data
LargeImage::~LargeImage()
{
	delete[] _temp;
}

//Gets block of data from data stored in _data
double* LargeImage::getBlock(int startRow, int endRow, int startCol, int endCol)
{
	delete[] _temp;
	int r = endRow - startRow;
	int c = endCol - startCol;
	_temp = new double[(r * c)];
	int inc = 0;

	for (int i = startRow; i < endRow; i++)
	{
		for (int j = startCol; j < endCol; j++)
		{
			_temp[inc] = _data[(i * _N) + j];
			inc++;
		}
	}

	return _temp;
}

void LargeImage::drawBox(int startRow, int endRow, int startCol, int endCol)
{
	//Line Top
	for (int i = startRow; i < (startRow + 3); i++)
	{
		for (int j = startCol; j < endCol; j++)
		{
			_data[(i * _N) + j] = 0;
		}
	}

	//Line Bottom
	for (int i = (endRow - 3); i < endRow; i++)
	{
		for (int j = startCol; j < endCol; j++)
		{
			_data[(i * _N) + j] = 0;
		}
	}

	//Line Left
	for (int i = startRow; i < endRow; i++)
	{
		for (int j = startCol; j < (startCol + 3); j++)
		{
			_data[(i * _N) + j] = 0;
		}
	}

	//Line Right
	for (int i = startRow; i < endRow; i++)
	{
		for (int j = (endCol - 3); j < endCol; j++)
		{
			_data[(i * _N) + j] = 0;
		}
	}
}

//Gets all the data stored in _data
double* LargeImage::getData()
{
	return _data;
}

//Experiment
void LargeImage::experiment(int sr, int er, int sc, int ec)
{
	int count = 0;
	double* wally = new double[(49 * 36)];

	for (int i = sr; i < er; i++)
	{
		for (int j = sc; j < ec; j++)
		{
			wally[count] = _data[(i * _N) + j];
			_data[(i * _N) + j] = 0;
			count++;
		}
	}

	count = 0;
	for (int i = (sr + 253); i < (er + 253); i++)
	{
		for (int j = (sc + 543); j < (ec + 543); j++)
		{
			_data[(i * _N) + j] = wally[count];
			count++;
		}
	}

	/*count = 0;
	for (int i = 719; i < 768; i++)
	{
	for (int j = 988; j < 1024; j++)
	{
	_data[(i * _N) + j] = wally[count];
	count++;
	}
	}*/

	delete[] wally;
}