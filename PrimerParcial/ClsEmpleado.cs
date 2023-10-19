using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimerParcial
{
    
    internal class ClsEmpleado
    {
        static int cantidad = 10;
        static int indiceAuxiliar = 0;
        static string[] cedulas = new string[cantidad];
        static string[] nombres = new string[cantidad];
        static string[] direcciones = new string[cantidad];
        static string[] telefonos = new string[cantidad];
        static float[] salarios = new float[cantidad];

        public static void init()
        {
            cedulas = Enumerable.Repeat(string.Empty, cantidad).ToArray();
            nombres = Enumerable.Repeat(string.Empty, cantidad).ToArray();
            direcciones = Enumerable.Repeat(string.Empty,cantidad).ToArray();
            telefonos = Enumerable.Repeat(string.Empty, cantidad).ToArray();
            salarios = Enumerable.Repeat(0f, cantidad).ToArray();

            Console.WriteLine("Arreglos inicializados");
            wait();
        }

        public static void add()
        {
            char opcion = 'N';
            do
            {
                Console.WriteLine($"Ingresando empleado {indiceAuxiliar}");
                Console.WriteLine("Digite numero de cedula :");
                cedulas[indiceAuxiliar] = Console.ReadLine();
                Console.WriteLine("Digite nombre :");
                nombres[indiceAuxiliar] = Console.ReadLine();
                Console.WriteLine("Digite direccion :");
                direcciones[indiceAuxiliar] = Console.ReadLine();
                Console.WriteLine("Digite telefono :");
                telefonos[indiceAuxiliar] = Console.ReadLine();
                Console.WriteLine("Digite salario :");
                salarios[indiceAuxiliar] = float.Parse(Console.ReadLine());

                Console.WriteLine("Desea ingresar otro empleado S/N");
                opcion = Console.ReadLine().ToUpper()[0];
                indiceAuxiliar++;

                if(opcion != 'N' && opcion != 'S')
                {
                    Console.WriteLine("Opcion Incorrecta");
                    wait();
                    break;
                }

            } while (opcion != 'N');
        }

        static int search() {
            int index = -1;

            Console.WriteLine("Digite el numero de cedula:");
            string id = Console.ReadLine();
            bool finded = false;

            index = Array.FindIndex(cedulas, cedula => cedula.Contains(id));
            finded = cedulas.Contains(id);

            if(! finded )
            {
                Console.WriteLine($"Elemento correspondiente a {id} no corresponde a ningun empleado");
                wait();
            }

            return index;
        }

        static void wait()
        {
            Console.WriteLine("Digite una tecla para continuar....");
            Console.ReadKey();
        }

        public static void consult()
        {
            int index = search();

            if( index >= 0 )
            {
                Console.WriteLine($"Cedula: {cedulas[index]} | Nombre: {nombres[index]} | Direccion: {direcciones[index]} | Telefono: {telefonos[index]} | Salario: {salarios[index]}");

                wait();
            }
            
        }

        public static void modify()
        {
            int index = search();

            if ( index >= 0 )
            {
                Console.WriteLine("Digite nombre :");
                nombres[index] = Console.ReadLine();
                Console.WriteLine("Digite direccion :");
                direcciones[index] = Console.ReadLine();
                Console.WriteLine("Digite telefono :");
                telefonos[index] = Console.ReadLine();
                Console.WriteLine("Digite salario :");
                salarios[index] = float.Parse(Console.ReadLine());

                Console.WriteLine($"El empleado cedula: {cedulas[index]} se ha modificado correctamente");
                wait();
            }
        }

        public static void delete()
        {
            int index = search();

            if(index >= 0)
            {
                cedulas[index] = string.Empty;
                nombres[index] = string.Empty;
                direcciones[index] = string.Empty;
                telefonos[index] = string.Empty;
                salarios[index] = 0f;

                Console.WriteLine($"El empleado cedula: {cedulas[index]} se ha borrado correctamente");
                wait();
            }
        }

        public static void reportAll(string title)
        {
            Console.WriteLine($"              {title}             ");
            for (int i = 0; i < indiceAuxiliar; i++)
            {
                if(salarios[i] != 0)
                {
                    Console.WriteLine("_________________________________________________________________________");
                    Console.WriteLine($"Cedula: {cedulas[i]} | Nombre: {nombres[i]} | Direccion: {direcciones[i]} | Telefono: {telefonos[i]} | Salario: {salarios[i]}");
                }
                
            }
            Console.WriteLine("_________________________________________________________________________");

            wait();
        }

        public static float getAverage(float[] valores)
        {
            float average = valores.Where(x => x != 0).ToArray().Average();

            return average;
        }

        public static float getMax(float[] valores)
        {
            float max = valores.Where(x => x != 0).ToArray().Max();

            return max;
        }

        public static float getMin(float[] valores)
        {
            float min = valores.Where(x => x!= 0).ToArray().Min();

            return min;
        }

        public static void reportAverage()
        {
            Console.WriteLine($"El promedio de salarios es: {getAverage(salarios)}");
            wait();
        }

        public static void reportMaxMin()
        {
            Console.WriteLine($"El maximo de salarios es: {getMax(salarios)} y el minimo de salarios es: {getMin(salarios)}");
            wait();
        }
    }
}
