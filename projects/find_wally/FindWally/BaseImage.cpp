#include "BaseImage.h"

//Default Constructor
BaseImage::BaseImage()
{
}

//Constructor
BaseImage::BaseImage(int Rows, int Cols, double* input_data)
{
	_M = Rows;
	_N = Cols;
	_data = new double[(_M * _N)]; //Allocate memory space
	for (int i = 0; i < (_M * _N); i++) //Populate with data
	{
		_data[i] = input_data[i];
	}
}

//Destructor: Deletes all stored data
BaseImage::~BaseImage()
{
}

//Virtual class to clear memory for _data in each class
void BaseImage::Destroy()
{
	delete[] _data;
}

//Gets all the data stored in _data
double* BaseImage::getData()
{
	return _data;
}
