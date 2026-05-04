#include <iostream>

using namespace std;
int main (){
	string str1, str2;
	cout<<"Digite str1: ";
	getline(cin,str1);
	cout<<"Digite str2: ";
	getline(cin,str2);
	
	if (str1 == str2)
		cout<<"Ambos string son iguales";
	else
		cout<<"Ambos string NO son iguales";
}
