#ifndef PILA_H
#define PILA_H

#include<iostream>
#include<stdexcept>
#include "Nodo.h"
using namespace std;

class Pila{
	private:
		//atributos
		int length;
		Nodo *top;
	public:
		//constructor
		Pila(){
			//Pila nueva inicia con CERO Nodos
			//y su tope apuntando a NULL
			this->length = 0;
			this->top = NULL;
		}
		//metodos
		int getLength(){
			return this->length;
		}
		Nodo *getTop(){
			return this->top;
		}
		//metodo push: apila un nuevo Nodo en el tope de la Pila
		void push(string value){
			//1) crear nuevo Nodo
			Nodo *nuevo = new Nodo(value);
			//2) next de nuevo apuntalo a top
			nuevo->next = this->top;
			//3) top apuntarlo a nuevo
			this->top = nuevo;
			//4) sumar 1 a length
			this->length++;
		}
		//metodo print: imprime la Pila en pantalla
		void print(){
			//Algoritmo de recorrido para Pila:
			//1) Nodo tmp apunta a top
			Nodo *tmp = this->top;
			cout << "top -> ";
			while( tmp != NULL ){
				//imprimir el valor del Nodo tmp
				cout << "\t" << tmp->value << endl;
				//pasar al siguiente Nodo
				tmp = tmp->next;
			}
			cout << "********* NULL *********" << endl;
		}
		//metodo pop: extrae el Nodo que esta en el tope de la pila
		Nodo *pop(){
			//1) si no hay Nodos entonces retornar NULL
			if( this->length == 0 ) return NULL;
			//2) apuntar extraer hacia top
			Nodo *extraer = this->top;
			//3) top apunta al next del actual top
			this->top = this->top->next;
			//4) el next de extraer apuntarlo a NULL
			extraer->next = NULL;
			//5) restar 1 a length
			this->length--;
			//6 retornar extraer
			return extraer;
		}
};


#endif






