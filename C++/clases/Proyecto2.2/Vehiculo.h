#ifndef VEHICULO_H
#define VEHICULO_H

#include <iostream>
#include <stdexcept>

using namespace std;

class Vehiculo{
	private:
		string estado = "Detenido";
			
	public:
		string marca="Ford",modelo="Escape",color="Negro",placa="HN2118";
		int anio;
		Vehiculo(string marca, string modelo, string color, string placa){
			this->marca=marca;
			this->modelo=modelo;
			this->color=color;
			this->placa=placa;		
		}
		
		Vehiculo(){
			this->marca;
			this->modelo;
			this->color;
			this->placa;
			
		}
		void acelerar(){
			this->estado="En marcha";			
		}
		void frenar(){
			this->estado="Detenido";
		}
		
		string getEstado(){
			return this->estado;
		}
		
	
};




#endif
