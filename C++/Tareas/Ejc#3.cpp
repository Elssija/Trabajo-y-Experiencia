#include <iostream>
#include <fstream>
#include <ctime>
#include <algorithm>
#include <cstdlib>

using namespace std;

int main(){
	cout<<"Jairo Jassiel Aguilera Romero\t20232001430"<<endl;
	fstream archivo;
	int n=0;
	string cadena,linea;
	
	archivo.open("ejemplo_24mil.txt",ios::in);
	cout<<"Ingrese una cadena de texto para ver si es igual a una lina del archivo: ";
	getline(cin,cadena);
	
	transform(cadena.begin(),cadena.end(),cadena.begin(),::toupper);
	
	if(archivo.is_open()){
		while(archivo.eof()==false){
			getline(archivo,linea);
			transform(linea.begin(),linea.end(),linea.begin(),::toupper);
			
			if(linea.find(cadena)== false){
				n++;
			}			
		}
		cout<<"Hay "<<n<<" lineas iguales a "<<cadena;
		archivo.close();
	}
	else{
		cout<<"El archivo no fue abierto";
	}
	
	
	
	
	return 8;
}
