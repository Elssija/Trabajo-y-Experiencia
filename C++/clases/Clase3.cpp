//clase numero 3
/*
"Arreglos bidimensionales"
es un arreglo que apunto principal que apunta a otros arreglos secundarios
*/
#include <iostream>
using namespace std;

int main(){
	//usualmente nosotros lo visualizamos como una tabla
	
	/*
	declaracion de arreglos unidimensionales
	1) declarar sin inicializar
	*/	
	int array[5][3];
	
	//2) declarar prellenado o sea incializado.
	// es obligatorio defenir el tamaño de cada arreglo secundario;
	int array2[][3]={
	{8,7,6},{823,79,61},{88,76,65},{81,73,62},{4,5,96}	
	};
	
	//imprimir un arreglo secundario de forma tabular
	for (int i=0;i<end(array2)-begin(array2);i++){
		for (int j=0;j < end(array2[i])-begin(array2[i]);j++){
			cout << array2[i][j];
		}
		cout<<endl;
	}
	
	return 8;
}