#ifndef COLA_H
#define COLA_H

#include<iostream>
#include<stdexcept>
#include "Nodo.h"

using namespace std;

class Cola{
	private:
		//atributos
		Nodo *first;
		Nodo *last;
		int length;
	public:
		//constructor
		Cola(){
			//Cola nueva
			this->first = NULL;
			this->last = NULL;
			this->length = 0;
		}
		//metodos
		Nodo *getFirst(){
			return this->first;
		}
		Nodo *getLast(){
			return this->last;
		}
		int getLength(){
			return this->length;
		}
		void enqueue(string value){
			//agregar Nodo a la Cola
			//crear Nodo nuevo
			Nodo *nuevo = new Nodo(value);
			//si no hay Nodos, last y first apuntan a nuevo
			if( this->length == 0 ){
				this->first = nuevo;
				this->last = nuevo;
			}
			else{
				//si hay Nodos entonces el next de last apunta a nuevo
				this->last->next = nuevo;
				//luego last apunta a nuevo
				this->last = nuevo;
			}
			//length suma 1
			this->length++;
		}
		void print(){
			//es el mismo de la lista simple
			Nodo *tmp = this->first;
			//recorrer cada Nodo hasta llegar a NULL
			cout << "(TURNO)->";
			while( tmp != NULL ){
				//imprimir el value de tmp
				cout << tmp->value << "->";
				//pasar al siguiente Nodo
				tmp = tmp->next;
			}
			cout << "(ULTIMO)" << endl;
		}
		Nodo *dequeue(){
			//solo si first es distinto de NULL
			if( this->first != NULL ){
				//Nodo a extraer apunta a first
				Nodo *extraer = this->first;
				//first apunta a next de first
				this->first = this->first->next;
				//next de extraer apunta a NULL para cortar su relacion con Cola
				extraer->next = NULL;
				//length resta uno
				this->length--;
				//hacer return de extraer
				return extraer;
			}
			else
				return NULL;
		}
};

#endif
