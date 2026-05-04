#include <iostream>
#include <algorithm>

using namespace std;

int main(){
	string str1, str2;
	
	cout<<"Ingrese el str1: ";
	getline(cin,str1);
	cout<<"Ingrese el str2: ";
	getline(cin,str2);
	
	string a=str1, b=str2;
	transform(a.begin(),a.end(),a.begin(),::tolower);
	transform(b.begin(),b.end(),b.begin(),::tolower);
	if (a==b)
		cout<<"Ambos son iguales";
	else
		cout<<"No son iguales:(";
	
}
