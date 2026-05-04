#include <iostream>
#include "Vehiculo.h"
#include "Tienda.h"
#include "Rectangulo.h"
#include "Tanque.h"

using namespace std;

int main(){
	cout<<"Jairo Jassiel Aguilera Romero\t20232001430"<<endl;
	
	cout<<"**********Ejercicio1**********"<<endl;
	Vehiculo *ejc1 = new Vehiculo("Nissan","X-Trail","Rojo","HCN1920");
	cout<<"Marca del auto: "<<ejc1->marca<<endl;
	cout<<"Modelo del auto: "<<ejc1->modelo<<endl;
	cout<<"Color del auto: "<<ejc1->color<<endl;
	cout<<"Color del auto: "<<ejc1->placa<<endl;
	ejc1->acelerar();
	cout<<"Estado del vehiculo: "<<ejc1->getEstado()<<endl;
	
	Vehiculo *ejc11 = new Vehiculo();
	cout<<"Marca del auto: "<<ejc11->marca<<endl;
	cout<<"Modelo del auto: "<<ejc11->modelo<<endl;
	cout<<"Color del auto: "<<ejc11->color<<endl;
	cout<<"Color del auto: "<<ejc11->placa<<endl;
	ejc11->frenar();
	cout<<"Estado del vehiculo: "<<ejc11->getEstado()<<endl;
	
	
	cout<<endl<<"**********Ejercicio2**********"<<endl;
	Tienda *ejc2 = new Tienda("iodu21389fdsa8912","Chorizo",75.99f,80.8f);
	cout<<"Codigo del producto: "<<ejc2->codigo<<endl;
	cout<<"Nombre del producto: "<<ejc2->nombre<<endl;
	cout<<"Costo del producto: "<<ejc2->costo<<endl;
	cout<<"Precio de la compra del producto: "<<ejc2->compra<<endl;
	ejc2->setTienda(87);
	cout<<"Exitencias del producto: "<<ejc2->getTienda()<<endl;
	
	Tienda *ejc22 = new Tienda();
	cout<<"Codigo del producto: "<<ejc22->codigo<<endl;
	cout<<"Nombre del producto: "<<ejc22->nombre<<endl;
	cout<<"Costo del producto: "<<ejc22->costo<<endl;
	cout<<"Precio de la compra del producto: "<<ejc22->compra<<endl;
	cout<<"Exitencias del producto: "<<ejc22->getTienda()<<endl;
	
	cout<<endl<<"**********Ejercicio3**********"<<endl;
	Rectangulo *ejc3 = new Rectangulo(23.8f,74.5f);
	cout<<"Ancho del rectangulo: "<<ejc3->ancho<<endl;
	cout<<"Largo del rectangulo: "<<ejc3->largo<<endl;
	ejc3->Area();
	ejc3->Diagonal();
	
	
	Rectangulo *ejc33 = new Rectangulo();
	cout<<"Ancho del rectangulo: "<<ejc33->ancho<<endl;
	cout<<"Largo del rectangulo: "<<ejc33->largo<<endl;
	ejc3->Perimetro();
	
	cout<<endl<<"**********Ejercicio4**********"<<endl;
	Tanque *ejc4 = new Tanque(80.0f,"Pegasus","Metal");
	cout<<"Capacidad del tanque: "<<ejc4->cmax<<endl;
	cout<<"Fabricante: "<<ejc4->fabricante<<endl;
	cout<<"Material: "<<ejc4->material<<endl;
	ejc4->setAgregar(20.0f);
	cout<<"Cantidad actual: "<<ejc4->getCantidad()<<endl;
	ejc4->Porcentaje();
	ejc4->setQuitar(10.0f);
	cout<<"Cantidad actual: "<<ejc4->getCantidad()<<endl;
	ejc4->Porcentaje();
	ejc4->setAgregar(60.0f);
	cout<<"Cantidad actual: "<<ejc4->getCantidad()<<endl;
	ejc4->Porcentaje();
	ejc4->setQuitar(70.0f);
	cout<<"Cantidad actual: "<<ejc4->getCantidad()<<endl;
	ejc4->Porcentaje();
	
	return 77;
}
