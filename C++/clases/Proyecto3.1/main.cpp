#include <iostream>
#include "ListaSimple.h"
#include "Pila.h"
#include <cstdlib>

using namespace std;

int main(){

	ListaSimple *lista= new ListaSimple();
	ListaSimple *lista1= new ListaSimple();
	Pila *pila=new Pila();
	Pila *pila1=new Pila();
	
	string n,fecha,nombre;
	int borrar;	
	while(true){
		system("cls");
		cout<<"Jairo Jassiel Aguilera Romero\t20232001430\n\n";
		cout<<"********INVENTARIO DE CITAS MEDICAS********"<<endl;
		cout<<"1) Realizar cita"<<endl;
		cout<<"2) Revision de registro"<<endl;
		cout<<"3) Eliminar cita"<<endl;
		cout<<"4) Salir"<<endl;
		cout<<"5) Historial de eliminados"<<endl;
		cout<<"Seleccione un opcion: ";
		getline(cin,n);
		
		if(n=="1"){
			cout<<"Ingrese la fecha en la que desea realizar su cita: ";
			getline(cin,fecha);
			cout<<"Ingrese a nombre de quien va la cita: ";
			getline(cin, nombre);
			lista->push(fecha);
			lista1->push(nombre);
			system("pause");
		}
		else if(n=="2"){
			if(lista->getLength()==NULL){
				cout<<"NO HAY UN REGISTRO DE CITAS"<<endl;
				system("pause");
			}
			else{
				int s=lista->getLength()-1;
				cout<<"Nombre del paciente:\tFecha de la cita:"<<endl;
				while(s>-1){
					cout<<lista1->get(s)->value<<"\t\t\t"<<lista->get(s)->value<<endl;
					s--;
				}
				system("pause");
			}
		}
		else if(n=="3"){
			if(lista->getLength()==NULL){
				cout<<"No existen citas para borrar"<<endl;
				system("pause");
			}
			else{
				int s=lista->getLength()-1;
				int i=lista->getLength();
				cout<<"\tNombre del paciente:\tFecha de la cita:"<<endl;
				while(s>-1){
					cout<<i<<"\t"<<lista1->get(s)->value<<"\t\t\t"<<lista->get(s)->value<<endl;
					s--;
					i--;
				}
				cout<<"Seleccione la cita que desea borrar: ";
				cin>>borrar;
				cin.ignore();
				if(borrar < 1 || borrar > lista->getLength()){
            		cout << "No existe esa cita :(" << endl;
            		system("pause");
            		continue;
        		}
				else{
					pila->push(lista->get(lista->getLength()-1)->value);
					pila1->push(lista1->get(lista1->getLength()-1)->value);
					lista1->pop(borrar-1);
					lista->pop(borrar-1);
					system("pause");
				}

			}
		}
		else if(n=="4"){
			cout<<"Nos vemos otro dia :)"<<endl;
			break;
		}
		else if(n=="5"){
			if(pila->getLength()==NULL){
				cout<<"NO HAY REGISTRO DE ELIMINADOS"<<endl;
				system("pause");
			}
			else{
				int s=lista->getLength()-1;
				cout<<"Nombre del paciente de las citas eliminadas: "<<endl;
				pila1->print();
				string opc;
				cout<<"¿Desea restaurar la ultima cita? [si,no]: ";
				getline(cin, opc);
				if(opc=="si"){
					lista->push(pila->getTop()->value);
					lista1->push(pila1->getTop()->value);
					pila->pop();
					pila1->pop();
				}
				else{
					system("pause");
				}
			}
		}
		else {
			cout<<"Opcion no disponible :("<<endl;
			system("pause");
	}
	
}
}
