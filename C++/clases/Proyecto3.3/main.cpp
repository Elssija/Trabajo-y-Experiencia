#include <iostream>
#include <cstdlib>
#include "Cola.h"

using namespace std;

int main(){
	string n;
	string str;
	Cola *colita=new Cola();
	
	
	while (true){
		system("cls");
		cout<<"Jairo Jassiel Aguilera Romero\t20232001430\n\n";
		cout<<"=====CONSULTORIO DR.AGUILERA====="<<endl;
		cout<<"1) Ingresar paciente a la fila"<<endl;
		cout<<"2) Atender paciente"<<endl;
		cout<<"3) Imprimir fila"<<endl;
		cout<<"4) salir"<<endl;
		cout<<"Digitar la opcion deseada: ";
		getline(cin,n);
		
		if(n=="1"){
			cout<<"Por favor digite el nombre del paciente:";
			getline(cin,str);
			colita->enqueue(str);
			continue;
		}
		if(n=="2"){
			if(colita->getLength()==NULL)
				cout<<"NO HAY PACIENTES"<<endl;
			else{
				cout<<"Atentiendo a: "<<colita->getFirst()->value<<endl;
				colita->dequeue();
			}
			system("pause");
			continue;
		}
		if(n=="3"){
			cout<<"COLA A IMPRIMR: "<<endl;
			if(colita->getLength()==NULL)
				cout<<"no hay cola :("<<endl;
			else{
				colita->print();
			}
			system("pause");
			continue;
		}
		if(n=="4"){
			cout<<"Hasta Luego amigo :("<<endl;
			system("pause");
			break;
		}
		else{
			cout<<"opcion no valida"<<endl;
			system("pause");
		}
	}
	
}
