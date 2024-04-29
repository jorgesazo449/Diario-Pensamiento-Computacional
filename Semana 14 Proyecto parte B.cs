using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //INICIO

            Console.WriteLine("¡Bienvenido al Simulador de Gasto de Energon!");

            //solicito que el usuario ingrese la informacion del robot
            Console.Write("Ingrese el nombre del robot: ");   
            string nombreRobot = Console.ReadLine();
            Console.Write("Ingrese el tipo de modo alterno: ");
            string modoAlterno = Console.ReadLine();
            Console.Write("Ingrese el nivel inicial de energon (1-100): ");
            float nivelEnergon = float.Parse(Console.ReadLine());
            //este if sirve para cuando el usuario ingrese un numero mayor de lo permitido
            if (nivelEnergon > 100)  
            {
                Console.WriteLine("Nivel de Energon invalido (mayor que 100)");
                Console.WriteLine("Ingrese nuevamente el nivel inicial de energon (1-100): ");
                nivelEnergon = float.Parse(Console.ReadLine());
            }
            //es para cuando el usuario ingrese un numero menor a lo permitido
            if (nivelEnergon < 0) 
            {
                Console.WriteLine("Nivel de Energon invalido (menor que 0)");
                Console.WriteLine("Ingrese nuevamente el nivel inicial de energon (1-100): ");
                nivelEnergon = float.Parse(Console.ReadLine());
            }

            Console.Write("Ingrese la posición inicial del robot: ");
            float posicion = float.Parse(Console.ReadLine());

            //las variables a utilizar
            string modoActual = "robot";      
            float tiempo;
            float gasto;
            float posicionFinal;
            float diferencia;
            bool estadoRobot = true;  

            bool salir = false;
            while (salir == false)
            //aca se le solicita al usuario cual es la accion que quiere que haga el robot
            {
                Console.WriteLine("\n------ MENÚ ------");      
                Console.WriteLine("1. Ver información del robot");
                Console.WriteLine("2. Cargar energon");
                Console.WriteLine("3. Transformarse (roll out)");
                Console.WriteLine("4. Movilizarse");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese una opción: ");
                string opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":      //aca muestra en la pantalla las caracteristicas del robot, el gasto de energon en porcentaje y su posicion en km
                        Console.WriteLine("----------------------------------------");     
                        Console.WriteLine("Nombre del robot: " + nombreRobot);
                        Console.WriteLine("Modo alterno: " + modoAlterno);
                        Console.WriteLine("Nivel de Energon: " + nivelEnergon + "%");
                        Console.WriteLine("Posicion del robot: " + posicion + "kms");
                        Console.WriteLine("----------------------------------------");
                        break;

                    case "2":

                        if (nivelEnergon <= 95) //es para calcular el energon cuando el robot se moviliza sin pasarse del 100%
                        {
                            nivelEnergon = nivelEnergon + 5;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Nivel actual de Energon: " + nivelEnergon + "%");
                            Console.WriteLine("----------------------------------------");
                        }
                        else   //es para cuando el robot llego a su 100% en el tanque de energon
                        {
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("No se puede recargar más cantidad de Energon");
                            Console.WriteLine("----------------------------------------");
                        }

                        break;
                    case "3": //es para cuando el robot pasa a su estado alterno y biceversa

                        if (estadoRobot == true)
                        {
                            modoActual = modoAlterno;
                            estadoRobot = false;
                        }
                        else
                        {
                            modoActual = "robot";
                            estadoRobot=true;
                        }

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Transformado en " + modoActual);
                        Console.WriteLine("----------------------------------------");
                        break;
                    case "4":
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("¿Cuanto tiempo en horas desea que el robot se mueva?");
                        Console.WriteLine("----------------------------------------");
                        tiempo = float.Parse(Console.ReadLine());

                        //este switch realiza una acción segun el valor de modoActual
                        switch (modoActual) 
                        {

                            case "robot": //si el modoActual es robot entonces se hacen los calculos de gastos y avance correspondientes al robot
                                gasto = tiempo * 5;
                                diferencia = nivelEnergon - gasto;

                                if (diferencia < 0)
                                {
                                    Console.WriteLine("Energon Insuficiente");

                                }
                                if (diferencia > 0)
                                {
                                    for (int i=1; i <= tiempo; i++) { //Se realiza la iteración para mostrar el avance y gasto por hora segun el tiempo ingresado

                                    posicionFinal = posicion + 50;
                                    diferencia = nivelEnergon - 5;

                                    Console.WriteLine("La posición del Robot es de: " + posicionFinal + " kms");
                                    posicion = posicionFinal;
                                    Console.WriteLine("La cantidad de Energon es de: " + diferencia + "%");
                                    nivelEnergon = diferencia;
                                    }
                                }

                                break;

                            case "auto": //se realizan los calculos correspondientes para saber cuanto recorrio el robot en su transformacion de auto y cuanto energon gasto

                                gasto = tiempo * 10;
                                diferencia = nivelEnergon - gasto;

                                if (diferencia < 0)
                                {
                                    Console.WriteLine("Energon Insuficiente");

                                }
                                if (diferencia > 0)
                                {
                                    for (int i = 1; i <= tiempo; i++) //se realiza la iteracion para mostrar el avance y gasto por hora segun el tiempo ingresado
                                    {
                                        posicionFinal = posicion + 110;
                                        diferencia = nivelEnergon - 10;

                                        Console.WriteLine("La posición del Robot es de: " + posicionFinal + " kms");
                                        posicion = posicionFinal;
                                        Console.WriteLine("La cantidad de Energon es de: " + diferencia + "%");
                                        nivelEnergon = diferencia;
                                    }
                                }

                                break;

                            case "camion": //
                                gasto = tiempo * 25;
                                diferencia = nivelEnergon - gasto;

                                if (diferencia < 0)
                                {
                                    Console.WriteLine("Energon Insuficiente");

                                }
                                if (diferencia > 0)
                                {
                                    for (int i = 1; i <= tiempo; i++) //se realiza la iteracion para mostrar el avance y gasto por hora segun el tiempo ingresado
                                    {
                                        posicionFinal = posicion + 85;
                                        diferencia = nivelEnergon - 25;

                                        Console.WriteLine("La posición del Robot es de: " + posicionFinal + " kms");
                                        posicion = posicionFinal;
                                        Console.WriteLine("La cantidad de Energon es de: " + diferencia + "%");
                                        nivelEnergon = diferencia;
                                    }
                                }


                                break;

                            case "moto":  //se calcula cuanto recorre el robot cuando esta transformado en moto y cuanto energon gasto
                                gasto = tiempo * 20;
                                diferencia = nivelEnergon - gasto;

                                if (diferencia < 0)
                                {
                                    Console.WriteLine("Energon Insuficiente");

                                }
                                if (diferencia > 0)
                                {
                                    for (int i = 1; i <= tiempo; i++) //se realiza la iteracion para mostrar el avance y gasto por hora sugun el tiempo ingresado
                                    {
                                        posicionFinal = posicion + 120;
                                        diferencia = nivelEnergon - 20;

                                        Console.WriteLine("La posición del Robot es de: " + posicionFinal + " kms");
                                        posicion = posicionFinal;
                                        Console.WriteLine("La cantidad de Energon es de: " + diferencia + "%");
                                        nivelEnergon = diferencia;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("Valor invalido (usar minusculas)"); //es para cuando el usuario ingresa mayusculas, ya que solo estan permitidas las minusculas
                                break;
                        }

                        break;
                    case "5":
                        salir = true; //sirve para salir del programa
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida."); //sirve para cuando el usuario ingresa una opcion incorrecta
                        break;



                        //siempre se pone esto al final
                        Console.ReadKey();
                        //FIN

                }
            }



        }
    }
}
