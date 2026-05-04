#include <iostream>
#include <algorithm>
using namespace std;

int main(){
	cout<<"Jairo Jassiel Aguilera Romero\t20232001430"<<endl;
	string str;
	bool ban=false;	
	string a1[20]={"Manzana", "Banano", "Naranja", "Fresa", "Mango","Piña", "Melón", "Sandía", "Uva", "Papaya","Cereza", "Durazno", "Pera", "Guayaba", "Kiwi",
		"Limón", "Mandarina", "Granada", "Aguacate", "Frambuesa"};
		
	cout<<"Ingrese la fruta a buscar: ";
	getline(cin,str);
	transform(str.begin(),str.end(),str.begin(), ::tolower);
	
	int i;
	for(i=0;i<20;i++){
		transform(a1[i].begin(),a1[i].end(),a1[i].begin(), ::tolower);
		if(a1[i]==str){
			cout<<"La fruta esta en el arreglo";
			break;
		}
	}
	if(i==20){
		cout<<"La fruto no esta :(";
	}
}
