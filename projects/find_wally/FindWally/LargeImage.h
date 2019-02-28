#pragma once
//Header file for LargeImage class
#include "BaseImage.h"
#include "MatchImage.h"

class LargeImage : public BaseImage
{
public:
	//Default Constructor
	LargeImage();
	////Constructor
	LargeImage(int, int, double*);
	//Copy Constructor
	LargeImage(const LargeImage& B);
	//Destructor
	~LargeImage();

	//Gets block of data from data stored in _data
	double* getBlock(int, int, int, int);
	//Gets all the data stored in _data
	double* getData();
	//Draws a box around the block
	void drawBox(int, int, int, int);

	//Experiment
	void experiment(int, int, int, int);

	//Temporarily stores extracted block data
	double* _temp = 0;
};

