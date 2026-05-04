#include <iostream>
#include <algorithm>
using namespace std;

int main() {
	cout<<"Jairo Jassiel Aguilera Romero\t20232001430"<<endl;
	
	//Declaracion de variables
	string str1="esto es una cadena bonita llena de texto bonito y tiene mucho texto, texto y mas texto, todo bonito.",str2;
	cout<<"Ingrese el string a buscar: ";
	getline(cin,str2);
	
	//Transformar los dos string para que se omita mayusculas y minusculas
	transform(str1.begin(),str1.end(),str1.begin(),::toupper);
	transform(str2.begin(),str2.end(),str2.begin(),::toupper);
	
	//Encontrar texto introducido
	int n=0,c=0;
	while (true){
		c=str1.find(str2,c);
		c+=1;
		if(c==0)
			break;	
		else 
			n++;
	}
	if (n==0)
		cout<<"No se econtro :(";
	else
		cout<<"Se ha encontrado "<<n<<" veces :)";
}
