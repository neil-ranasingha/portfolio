#pragma once
//Header file for MatchImage class
#include "BaseImage.h"
#include "LargeImage.h"

#include <math.h> // sqrt
#include <iostream> // cout, cerr
#include <vector> // vector<>, vector<vector>>
#include <array> // sort

using namespace std;
class MatchImage : public BaseImage
{
public:
	//Default Constructor
	MatchImage();
	//Constructor
	MatchImage(int, int, double*, double*, int);
	//Destructor
	~MatchImage();

	//Gets block of data from data stored in _data
	void getNewBlock(int, int, double*);
	//Gets all the data stored in _data
	double* getData();

	//NNS Algorithm
	//Calculates normalised correlation between wally and extracted block data
	double NC();

	//Checks the NC score of each comparison and stores the top 5 with the highest NC score
	void N_best(double, int, int, int, int);

	//Works out the calculations needed for the NC algorithm for the Wally data
	void WallyCalc(double*);
	
	//Stores the N_best results from the NNS algorithm
	vector<vector<double>> NC_Block;
	//Temporary storage for the NC score and block data
	vector<double> Temp_Store;

private:
	double* WallyData = 0;
	double WallySqr = 0;
};


