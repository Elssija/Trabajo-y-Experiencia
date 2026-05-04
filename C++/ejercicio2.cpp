#include <iostream>
#include <ctime>
#include <cmath>

using namespace std;

int main() {
	
	srand(time(0));
	int array[5][8];
	for(int i=0; i< end(array)-begin(array);i++){
		for (int j=0; j< end(array[i])-begin(array[i]); j++){
		int n = rand()%(33-(-7)+1)+(-7);
		array[i][j] = n;
		cout<<array[i][j]<<"\t";	
		}
		cout<<endl;
		
	}
	return 8;
}