#ifndef LISTASIMPLE_H
#define LISTASIMPLE_H

#include<iostream>
#include<stdexcept>
#include "Nodo.h"
using namespace std;

class ListaSimple{
	private:
		//atributos
		Nodo	*first;
		Nodo	*last;
		int		length;
	public:
		ListaSimple(){
			this->first = NULL;
			this->last = NULL;
			this->length = 0; //no tiene Nodos aun
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
		//metodo para agregar un nuevo Nodo al final de la lista
		void push(string value){
			//1) crear un nuevo Nodo llamado tmp cuyo valor sea value
			Nodo *tmp = new Nodo(value);
			/*2) Si length es Cero entonces:
				a) first y last apuntaran al Nodo tmp
			sino
				a) el next del Nodo last apuntara al Nodo tmp
				b) el Nodo last apuntara a tmp*/
			if( this->length == 0 ){
				this->first = tmp;
				this->last = tmp;
			}
			else{
				this->last->next = tmp;
				this->last = tmp;
			}
			//3) sumar 1 a length
			this->length++;
		}
		//metodo para imprimir el contenido de la lista en pantalla
		void print(){
			//Algoritmo de recorrido
			//1) Declarar variable tmp de tipo Nodo y apuntarla a first
			Nodo *tmp = this->first;
			/*2) Mientras el Nodo tmp sea distinto de NULL entonces:
					a) imprimir el value de tmp
					b) apuntar tmp al next de tmp (pasar al siguiente Nodo
				Sino:
					a) terminar el recorrido*/
			while( tmp != NULL ){
				cout << tmp->value << "->";
				tmp = tmp->next; //pasar al siguiente Nodo
			}
			//se termino el recorrido
			cout << "NULL" << endl; //imprimo el letrero NULL
		}
		//metodo para recuperar un Nodo en determinada posicion
		Nodo *get(int pos){
			//guard clauses: pos no puede ser negativo y pos no debe superar al
			//numero de Nodos
			if( pos < 0 )
				throw invalid_argument("Posicion a obtener no debe ser negativa");
			else
				if( pos > this->length-1 )
					throw invalid_argument("Posicion a obtener no existe");
				else{
					//Algoritmo de recorrido
					Nodo *tmp = this->first; //comenzamos en el primer Nodo
					int posicionActual = 0; //contador de saltos
					
					while( tmp != NULL ){
						//si el salto actual es igual a la posicion deseada
						//entonces retornamos el Nodo en que nos encontramos
						if( posicionActual == pos )
							return tmp;
						
						tmp = tmp->next; //pasar al siguiente Nodo
						posicionActual++; //sumar 1 al contador de saltos
					}
				}
		}
		//metodo para cambiarle el valor a un Nodo en determinada posicion
		void set(int pos, string value){
			//recuperar el Nodo en la posicion pos
			//y cambiarle su valor por el nuevo value
			this->get(pos)->value = value;
		}
		//metodo para eliminar un Nodo de la lista
		Nodo *pop(int pos){
			//guard clause: si no hay Nodos entonces dar excepcion
			if( this->length == 0 )
				throw invalid_argument("No hay nodos para eliminar.");
			else{
				//1) apuntar borrar al Nodo a eliminar
				Nodo *borrar = this->get(pos);
				//2) si borrar es igual a first:
				if( borrar == this->first )
					//a) first apunta al next de first:
					this->first = this->first->next;
				else{
					//sino: a) apuntamos anterior al Nodo con posicion-1
					Nodo *anterior = this->get(pos-1);
					//apuntar el next de anterior al next de borrar
					anterior->next = borrar->next;
				}
				//3) si borrar es igual a last entonces:
				if( borrar == this->last )
					//*) si first es igual a NULL entonces:
					if( this->first == NULL )
						//last apunta a NULL
						this->last = NULL;
					else{
						//apuntar last a anterior
						Nodo *anterior = this->get(pos-1);
						this->last = anterior;
					}
				//4) apuntar a NULL el next de borrar
				borrar->next = NULL;
				//5) restar 1 a length
				this->length--;
				//6) retornar el Nodo eliminado
				return borrar;
			}
		}
		//metodo find para buscar un Nodo de acuerdo a su valor
		//devuelve la posicion de la primer coincidencia encontrada
		//si no encuentra nada entonces devuelve -1
		int find(string buscado){
			//este metodo es mas eficiente con el algoritmo de recorrido
			//no se recomienda hacer este metodo usando get y for porque no es eficiente
			Nodo *tmp = this->first;
			int posicion = 0;
			while( tmp != NULL ){
				if( tmp->value == buscado ) //si el valor del Nodo actual es igual al buscado...
					return posicion;				//...entonces retornamos dicho Nodo
				
				tmp = tmp->next; //pasar al siguiente Nodo
				posicion++; //sumar 1 a posicion
			}
			//si llego aqui entonces no encontro nada
			return -1;
		}
};

#endif










