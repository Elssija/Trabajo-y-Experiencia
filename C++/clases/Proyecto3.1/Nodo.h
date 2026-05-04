#ifndef NODO_H
#define NODO_H

#include<iostream>
using namespace std;

class Nodo{
	private:
	public:
		string value;
		Nodo *next;
		Nodo(string value){
			this->value = value;
			this->next = NULL;
		}
};

#endif
