#ifndef TANQUE_H
#define TANQUE_H
#include <iostream>
#include <stdexcept>
#include <algorithm>

using namespace std;

class Tanque{
	private:
		float cantidad=0;	
		
	public:
		float cmax;
		string fabricante, material;
		
		Tanque(float cmax, string fabricante, string material){
			this->cmax=cmax;
			this->fabricante=fabricante;
			this->material=material;
		}
		Tanque(){
			
		}
		
		void setAgregar(float cantidad){
			if(cantidad>this->cmax)
				throw invalid_argument("La cantidad a agregar sobrepasa la capacidad maxima del tanque");
			if(cantidad+this->cantidad>this->cmax)
				throw invalid_argument("La cantidad a agregar sobrepasa la capacidad maxima del tanque");
			if(cantidad<0)
				throw invalid_argument("La cantidad de agua a agregar debe ser positiva");
			else
				this->cantidad+=cantidad;	
		}
		
		void setQuitar(float cantidad){
			if(cantidad>this->cantidad)
				throw invalid_argument("La cantidad a quitar sobrepasa la cantidad actual del tanque");
			if(cantidad<0)
				throw invalid_argument("La cantidad de agua a quitar debe ser positiva");
				
			else
				this->cantidad-=cantidad;		
		}
		
		
		float getCantidad(){
			return this->cantidad;
		}
		
		void Imprimir(){
			cout<<"La cantidad de agua del tanque es: "<<this->cantidad<<endl;
		}
		
		void Porcentaje(){
			cout<<"El porcentaje de la capacidad ocupada del tanque es: "<<(this->cantidad/cmax)*100<<endl;
		}
		
	
};


#endif
