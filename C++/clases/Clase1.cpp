#include <iostream>
 using namespace std;
 
 int main (){
 	/*
 	arreglos:
 	es una estructura de datos estaticos, secuenciales y homogeneos.
 	estatica: no puede camviar su tamaño
 	homogeneo: todos sus elementos son del mismo tipo
 	secuencial: sus elementos en memoria se almacenan de forma consecutiva en la memoria
	*/	
	//int a[500000];
 	/*
 	como el arreglo es secuencial puede estar en la memoria sin estorbos por lo tanto un arreglo de 5 millones
 	no se puede crear.
 	*/
 	int array1[8];
 	int array2[]={2,3,4,5,6};
 	
 	cout<<"Direccion de memoria de array1: "<<array1<<endl;
	cout<<"Direccion de memoria de array2: "<<array2<<endl;
	
		//obtener en que direccion de memoria inicia y termina una variable
	cout<<"array2 inicia en: "<<begin(array2)<<endl;
	cout<<"array2 termina en: "<<end(array2)<<endl;
	// saber el tamaño de un arreglo:
	cout<<"Tamano de array2: "<<end(array2)-begin(array2)<<endl;
	
	//imprimmir aarreglos con la ayuda del bucle for
	for (int i=0;i<8;i++){
		cout<<array2[i]<<endl;
	}
	
	// el resultado de restar end y begin se puede tambien almacenar en una variable int o long
	 	
 	return 0;
 }