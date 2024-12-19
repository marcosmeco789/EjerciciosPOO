using System;
using System.Collections.Generic;
using System.IO;

namespace EjerciciosPOO
{
    internal class Program
    {
        public static void ganancias(IPastaGansa inter)
        {
            Console.WriteLine("Cuales son las ganancias de la empresa?");
            Console.WriteLine(inter.ganarPasta(double.Parse(Console.ReadLine())) + "€");
        }

        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();
            Lectora leer;
            Escritora escribir;

            string path = Environment.GetEnvironmentVariable("appdata") + "\\bdPersonas.dat";

            if (File.Exists(path))
            {
                leer = new Lectora(File.Open(path, FileMode.Open));

                while ((leer.BaseStream.Position != leer.BaseStream.Length))
                {
                    string identificador = leer.ReadString();
                    if (identificador == "emp")
                    {
                        Empleado empleado = leer.ReadEmpleado();
                        personas.Add(empleado);
                    }
                    else if (identificador == "dir")
                    {
                        Directivo directivo = leer.ReadDirectivo();
                        personas.Add(directivo);
                    } else
                    {
                        Console.WriteLine("Hay algun error con el archivo!\nPulsa alguna tecla para cerrar");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                }
                leer.Dispose();
            }


            int selector;
            do
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Añadir Empleado");
                Console.WriteLine("2. Añadir Directivo");
                Console.WriteLine("3. Visualizar Colección");
                Console.WriteLine("4. Salir\n");
                selector = int.Parse(Console.ReadLine());

                switch (selector)
                {
                    case 1:
                        Empleado emp = new Empleado();
                        emp.Introduccion();
                        personas.Add(emp);

                        escribir = new Escritora(File.Open(path, FileMode.Append));
                        escribir.Write(emp);
                        escribir.Dispose();

                        break;
                    case 2:
                        Directivo direc = new Directivo();
                        direc.Introduccion();
                        personas.Add(direc);

                        escribir = new Escritora(File.Open(path, FileMode.Append));
                        escribir.Write(direc);
                        escribir.Dispose();

                        break;
                    case 3:
                        VisualizarColeccion(personas);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (selector != 4);
        }

        static void VisualizarColeccion(List<Persona> personas)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-5} {3,-10} {4,-15} {5,-10}", "Nombre", "Apellidos", "Edad", "DNI", "Tipo", "Detalles");
            Console.WriteLine(new string('-', 90));

            foreach (var persona in personas)
            {
                string tipo = persona.GetType().Name;
                string detalles = "";

                if (persona is Empleado emp)
                {
                    detalles = $"Salario: {emp.Salario}, Teléfono: {emp.Telefono}";
                }
                else if (persona is Directivo dir)
                {
                    detalles = $"Departamento: {dir.Departamento}, Personas: {dir.Personas}";
                }

                Console.WriteLine("{0,-15} {1,-15} {2,-5} {3,-10} {4,-15} {5,-10}", persona.Nombre, persona.Apellidos, persona.Edad, persona.Dni, tipo, detalles);
            }
            Console.WriteLine();
        }
    }
}
