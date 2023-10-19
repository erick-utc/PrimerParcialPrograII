using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    internal class ClsMenu
    {
        static int opcion;

        static void displayTitle(string title)
        {
            Console.WriteLine("************************************");
            Console.WriteLine($"          {title}        ");
            Console.WriteLine("************************************");
        }

        static void displayOptions(string type)
        {
            switch(type)
            {
                case "menu":
                    Console.WriteLine("1 - Inicializar Arreglos");
                    Console.WriteLine("2 - Agregar Empleados");
                    Console.WriteLine("3 - Consultar Empleados");
                    Console.WriteLine("4 - Modificar Empleados");
                    Console.WriteLine("5 - Borrar Empleados");
                    Console.WriteLine("6 - Reportes");
                    Console.WriteLine("7 - Salir");
                    break;
                case "submenu":
                    Console.WriteLine("1 - Reporte empleados");
                    Console.WriteLine("2 - Listar todos los Empleados");
                    Console.WriteLine("3 - Calcular y mostrar promedio de salario");
                    Console.WriteLine("4 - Calcular y mostrar el salario mas alto y el mas bajo de todos los empleados");
                    Console.WriteLine("5 - Salir");
                    break;
            }
            
        }

        public static void menu()
        {
            do
            {
                displayTitle("Sistema HR");
                displayOptions("menu");
                Console.WriteLine("Ingrese una opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        displayTitle("Inicializar");
                        ClsEmpleado.init();
                        Console.Clear();
                        break;
                    case 2:
                        displayTitle("Agregar Empleados");
                        ClsEmpleado.add();
                        Console.Clear();
                        break;
                    case 3:
                        displayTitle("Consultar Empleados");
                        ClsEmpleado.consult();
                        Console.Clear();
                        break;
                    case 4:
                        displayTitle("Modificar Empleados");
                        ClsEmpleado.modify();
                        Console.Clear();
                        break;
                    case 5:
                        displayTitle("Borrar Empleados");
                        ClsEmpleado.delete();
                        Console.Clear();
                        break;
                    case 6:
                        submenu();
                        break;
                    case 7:
                        break;
                }
            } while (opcion != 7);
            
        }

        public static void submenu()
        {
            do
            {
                displayTitle("Reportes");
                displayOptions("submenu");
                Console.WriteLine("Ingrese una opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                Console.Clear();
                switch(opcion)
                {
                    case 1:
                        displayTitle("Reporte empleados");
                        ClsEmpleado.consult();
                        Console.Clear();
                        break;
                    case 2:
                        displayTitle("Listar todos los Empleados");
                        ClsEmpleado.reportAll("Todos los empleados");
                        Console.Clear();
                        break; 
                    case 3:
                        displayTitle("Promedio de Salarios");
                        ClsEmpleado.reportAverage();
                        Console.Clear();
                        break; 
                    case 4:
                        displayTitle("Maxima y Minimo Salarios");
                        ClsEmpleado.reportMaxMin();
                        Console.Clear();
                        break; 
                    case 5:
                        break;

                }
            } while (opcion != 5);
        }
    }
}
