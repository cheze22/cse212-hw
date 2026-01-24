using System;

class Auto
{
    string color;
    string marca;
    int llanta;

    static string PreguntarMarca (string NombrePropietario){

        Console.Writeline("Cual es la marca de tu auto?");
        marca = Console.Readline();
        string total="Hola "+NombrePropietario+" tu marca es "+marca;
        return total;
    }
    static string PedirNombrePropietario(){
        Console.WriteLine("Cual es tu nombre?");
        string name = Console.Readline();
        return name;
    }

}

class Program{
   static void Main(string[] args){
        Auto primerauto = new Auto();
        

        string NameOwner = primerauto.PedirNombrePropietario();
        string Resultado = primerauto.PreguntarMarca(NameOwner);
        Console.WriteLine(Resultado);
   } 
}


Auto.PreguntarMarca(Name);

Receta > COmida millones de veces


 atributos

    variables que son solo para la clase en la mayoria de los casos, pero tambien 
    pueden tener ajustes


 funciones

    funciones necesitan informacion
    funciones sin informacion
    funciones que necesitan dos tipos de informacion
    funciones que devuelven informacion

 
