#include <iostream>
#include <algorithm>

using namespace std;

int main(){
	cout<<"Jairo Jassiel Aguilera Romero\t20232001430"<<endl;
	string n;
	int x,y;
	int O=0;
	string game[3][3]={
	{"_","_","_"},
	{"_","_","_"},
	{"_","_","_"}
	};
	
	while (true){
		cout<<"Turno de: ";
		getline(cin,n);
		transform(n.begin(),n.end(),n.begin(),::toupper);
		if(n=="X"){
			cout<<"Turno de X\n";
			cout<<"Ingrese la posicion x: "<<endl;
			cin>>x;
			cout<<"Ingrese la posicion y: "<<endl;
			cin>>y;
			if(x>3 || y>3 || y<=0 || x<=0){
				cout<<"Ingrese un numero entre 1 y 3"<<endl;
				cin.ignore();
				continue;
			}
			else{
				x--;y--;
				game[x][y]=n;
			}
		}
		else if(n=="0"){
			cout<<"Turno de 0\n";
			cout<<"Ingrese la posicion x: ";
			cin>>x;
			cout<<"Ingrese la posicion y: ";
			cin>>y;
			if(x>3 || y>3 || y<=0 || x<=0){
				cout<<"Ingrese un numero entre 1 y 3"<<endl;
				cin.ignore();
				continue;
			}
			else{
				x--;y--;
				game[x][y]=n;
			}
		}
		else{
			cout<<"Ingrese solo 0 o X\n";
			continue;
		}
		if(x==-1 || y==-1){
			cout<<"El juego ha terminado :(";
			break;
			}
		else{
		//imprimir
			cout<<" 	1	2	3"<<endl;
			for(int i=0;i<3;i++){
				for(int j=0;j<3;j++){
					if(j==0)
						cout<<i+1;
					cout<<"	"<<game[i][j];
					if(j==2)
						cout<<endl;
				}
			}
			cout<<"**************************\n";
			for(int i=0;i<3;i++){
			//columnas
			if(game[0][i]==n && game[1][i]==n && game[2][i]==n){
				O++;
				break;
			}
			//filas
			if(game[i][0]==n && game[i][1]==n && game[i][2]==n){
				O++;
				break;
			}
				
			//diagonales 1
			if(game[0][0]==n && game[1][1]==n && game[2][2]==n){
				O++;
				break;
			}
				
			//diagonales 2
			if(game[2][2]==n && game[1][1]==n && game[0][0]==n){
				O++;
				break;
				}	
			}
			}
		if(O>0){
			cout<<"El usuario de las "<< n <<" ha ganado :)";
			break;
		}
	}
		
}
