#ifndef TIENDA_H
#define TIEDNA_H

#include <iostream>
using namespace std;


class Tienda{
	private:
		int existencias=0;	
		
	public:
		string codigo="803fdsa21839dh122", nombre="Maseca";
		float costo=19.12f, compra=20.99f;
	
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
