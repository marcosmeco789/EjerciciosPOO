using System;
using System.Collections.Generic;

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

            

            int selector;
            do
            {
                Console.WriteLine("\n[+] Bienvenido al menú!\n\n" +
                    "1 - Visualizar los datos del Directivo\n" +
                    "2 - Visualizar datos Empleado\n" +
                    "3 - Visualizar datos EmpleadoEspecial\n" +
                    "4 - Añadir Directivo\n" +
                    "5 - Añadir Empleado\n" +
                    "6 - Quitar Persona\n" +
                    "7 - Listar todas las Personas\n" +
                    "8 - Salir\n\n");

                selector = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (selector)
                {
                    case 1: 
                        Console.WriteLine("Introduce el índice del Directivo:");
                        int indexDirectivo = int.Parse(Console.ReadLine());
                        if (indexDirectivo >= 0 && indexDirectivo < personas.Count && personas[indexDirectivo] is Directivo)
                        {
                            var directivo = (Directivo)personas[indexDirectivo];
                            directivo.mostrar();
                            ganancias(directivo);
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido o no es un Directivo.");
                        }
                        break;

                    case 2: 
                        Console.WriteLine("Introduce el índice del Empleado:");
                        int indexEmpleado = int.Parse(Console.ReadLine());
                        if (indexEmpleado >= 0 && indexEmpleado < personas.Count && personas[indexEmpleado] is Empleado)
                        {
                            var empleado = (Empleado)personas[indexEmpleado];
                            Console.WriteLine("Introduce el valor que quieres visualizar: \n\n" +
                                "0 - Nombre\n1 - Apellidos\n2 - Edad\n3 - DNI\n4 - Salario\n5 - IRPF\n6 - Telefono\n");
                            int dato = int.Parse(Console.ReadLine());
                            empleado.mostrar(dato);
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido o no es un Empleado.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Introduce el índice del EmpleadoEspecial:");
                        int indexEmpleadoEs = int.Parse(Console.ReadLine());
                        if (indexEmpleadoEs >= 0 && indexEmpleadoEs < personas.Count && personas[indexEmpleadoEs] is EmpleadoEspecial)
                        {
                            var empleadoEspecial = (EmpleadoEspecial)personas[indexEmpleadoEs];
                            Console.WriteLine("Introduce el valor que quieres visualizar: \n\n" +
                                "0 - Nombre\n1 - Apellidos\n2 - Edad\n3 - DNI\n4 - Salario\n5 - IRPF\n6 - Telefono\n");
                            int dato2 = int.Parse(Console.ReadLine());
                            empleadoEspecial.mostrar(dato2);
                            ganancias(empleadoEspecial);
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido o no es un EmpleadoEspecial.");
                        }
                        break;

                    case 4: 
                        var directivoNuevo = new Directivo();
                        directivoNuevo.Introduccion();
                        personas.Add(directivoNuevo);
                        Console.WriteLine("Directivo añadido.");
                        break;

                    case 5: 
                        var empleadoNuevo = new Empleado();
                        empleadoNuevo.Introduccion();
                        personas.Add(empleadoNuevo);
                        Console.WriteLine("Empleado añadido.");
                        break;

                    case 6: 
                        Console.WriteLine("Introduce el índice de la persona a eliminar:");
                        int indexEliminar = int.Parse(Console.ReadLine());
                        if (indexEliminar >= 0 && indexEliminar < personas.Count)
                        {
                            personas.RemoveAt(indexEliminar);
                            Console.WriteLine("Persona eliminada.");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido.");
                        }
                        break;

                    case 7: 
                        Console.WriteLine("Listado de todas las personas:");
                        for (int i = 0; i < personas.Count; i++)
                        {
                            if (personas[i].GetType().Name == "Empleado")
                            {
                                Console.WriteLine($"[{i}] {personas[i].Nombre} {personas[i].Apellidos} - {personas[i].GetType().Name}");   
                            } else
                            {
                                Console.WriteLine($"[{i}] {personas[i].Nombre} {personas[i].Apellidos} {personas[i].Edad} {personas[i].Dni} - {personas[i].GetType().Name}");
                            }
                        }
                        break;

                    case 8: 
                        Console.WriteLine("[!] Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (selector != 8);
        }
    }
}
