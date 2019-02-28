#pragma once
//Header file for BaseImage class
class BaseImage
{
public:
	//Default Constructor
	BaseImage();
	//Constructor
	BaseImage(int, int, double*);
	//Destructor
	~BaseImage();

	//Virtual class to clear memory for _data in each class
	virtual void Destroy();

	//Gets all the data stored in _data
	double* getData();

protected:
	int _M = 0, _N = 0;
	double *_data = 0;
};

