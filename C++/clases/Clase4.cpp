#include <iostream>
#include <algorithm>

using namespace std;

int main () {
	//transformar un string en mayusculas o minusculas
	string str;

	cout<<"Digite un string: ";
	getline(cin,str);

	//transformar a mayusculas
	transform(str.begin(),str.end(),str.begin(),::toupper);
	
	cout<<"El valor de str es: "<<str<<endl;
	
	//transformar a minusculas
	transform(str.begin(),str.end(),str.begin(),::tolower);
	
	cout<<"El valor de str es: "<<str<<endl;
	
	//hacer copia de una variable ya que transform altera la variable original
	string str2,copia;
	cout<<"Digite str2: ";
	getline(cin,str2);
	
	copia=str2;
	transform(copia.begin(),copia.end(),copia.begin(),::toupper);
	
	cout<<"El string original es: "<<str2;
	cout<<"La copia del original es: "<<copia;
	
}

