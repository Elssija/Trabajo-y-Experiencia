#include <iostream>
#include <fstream>

using namespace std;

int main(){
	int i=10;
	string linea,line;
	fstream archivo;
	archivo.open("5MIL_enteros.txt",ios::app);
	if(archivo.is_open())
		cout<<"El archivo se ha abierto :) ";
	else
		cout<<"El archivo no existe :(";
	
	while(i!=0){
		i--;
		cout<<"Ingrese una linea de numeros";
		getline(cin,linea);
		archivo<<linea;
		getline(archivo,line);
		cout<<line;
	}
}
