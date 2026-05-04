#include <iostream>
#include <algorithm>

using namespace std;

int main(){
	cout<<"Jairo Jassiel Aguilera Romero\t20232001430"<<endl;
	
	string array[10]={"","","","","","","","","",""};
	string str;
	int num;
	int z=10;
	while(z>0){
		z--;
		cout<<"Ingrese la frase que desea ingresar al arreglo: ";
		getline(cin,str);
		for (int i=0;i<10;i++){
			if(array[i]==""){
				array[i]=str;
				break;
			}
		}
	}
	cout<<"\nYa no hay espacios disponibles:(\nEl arreglo queda de la siguiente forma:\n";
	for(int i=0;i<10;i++){
		if(i==9)
		cout<<array[i]<<endl;
		else
		cout<<array[i]<<",";
	}
	system("pause");
}
