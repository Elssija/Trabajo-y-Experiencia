#include <iostream>
#include <ctime>
#include <cmath>
using namespace std;

int main (){
	
	int a1[25];
	srand(time(0));
	for (int i=1;i<26;i++)
	{
		int n = rand()%(105-9+1)+9;
		a1[i]=n;
		if (i==25){
			cout<<a1[i]<<endl;
		}
		else cout<<a1[i]<<",";
	}
		
	return 8;
}