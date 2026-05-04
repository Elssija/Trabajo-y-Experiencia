#include <iostream>
using namespace std;

int main(){
	
	/*string str;
	
	cout<<"Ingrese un string: ";
	getline(cin,str);
	
	for (int i=0; i<str.length();i++){	
		cout<<str[i]<<"***";
	}
	*/
	string str1;
	
	cout<<"Ingrese string1: ";
	getline(cin,str1);
	
	string str2;
	
	for (int i = 0; i < str1.length(); i++){
		str2=str2+str1[i]+"***";
	}//
	cout<<str2;
	
}