#include <iostream>
#include <string>
#include <ctime>
#include <cstdlib>
#include <fstream>
#include <algorithm>

using namespace std;

int main (){
	fstream archivo;
	int i=0;
	string linea;
	archivo.open("5MIL_enteros.txt",ios::in);
	if(archivo.is_open()){
		cout<<"Archivo Abierto :)";
		while(archivo.eof()==false){
			getline(archivo,linea);
			try{
				if(stoi(linea)%2==0){
				cout<<linea;
				i++;
				}		
			}
			catch(exception ex){
				
			}
		}
		cout<<"Hay "<<i<<" numeros pares";
	archivo.close();
	}
}
