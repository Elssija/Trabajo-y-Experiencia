#ifndef RECTANGULO_H
#define RECTANGULO_H

#include <iostream>
#include <cmath>

using namespace std;

class Rectangulo{
	private:
		
	public:
		float ancho, largo;
		
		Rectangulo(){
			this->ancho=0;
			this->largo=0;
		}
		Rectangulo(float ancho, float largo){
			this->ancho=ancho;
			this->largo=largo;		
		}
		void Area(){
			cout<<"El area del rectangulo es: "<<this->ancho*this->largo<<endl;
		}
		void Perimetro(){
			cout<<"El perimetro del rectangulo es: "<<2*(this->ancho+this->largo)<<endl;
		}
		void Diagonal(){
			cout<<"La diagonal del rectangulo es: "<<sqrt(pow(this->ancho,2)+pow(this->largo,2))<<endl;
		}
};



#endif
