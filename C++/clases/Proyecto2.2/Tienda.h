#ifndef TIENDA_H
#define TIEDNA_H

#include <iostream>
using namespace std;


class Tienda{
	private:
		int existencias=0;	
		
	public:
		string codigo="iodf4312490fdao", nombre="Maseca";
		float costo=18.99f, compra=21.80;
	
	Tienda(string codigo, string nombre, float costo, float compra){
		this->codigo=codigo;
		this->nombre=nombre;
		this->compra=compra;
		this->costo=costo;
	}
	
	Tienda(){
		this->codigo;
		this->nombre;
		this->compra;
		this->costo;
	}
	
	void setTienda(int existencias){
		this->existencias=existencias;
	}
	
	int getTienda(){
		return this->existencias;
	}
	
};



#endif
