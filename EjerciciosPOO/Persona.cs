using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPOO
{
    abstract class Persona
    {

        private int edad;
        private string dni;

        public Persona(string nombre, string apellidos, int edad, string dni)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Dni = dni;
        }

        public Persona()
            : this("", "", 0, "")
        {

        }

        public string Nombre { set; get; }
        public string Apellidos { set; get; }

        public int Edad
        {

            set
            {
                if (edad < 0)
                {
                    edad = 0;
                }
                else
                {
                    edad = value;
                }
            }

            get
            {
                return edad;
            }

        }

        public string Dni
        {
            set
            {
                dni = value;
            }

            get
            {
                string[] letras = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
                // string letras = "TRWA";
                var resto = int.Parse(dni) % 23;
                return dni + letras[resto];
            }
        }


        public virtual void mostrar()
        {
            Console.WriteLine("Nombre: "+Nombre);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("DNI: " + Dni);
        }

        public virtual void Introduccion()
        {
            Console.WriteLine("Introduce el nombre: ");
            Nombre = Console.ReadLine();
            Console.WriteLine("Introduce los apellidos: ");
            Apellidos = Console.ReadLine();
            Console.WriteLine("Introduce la edad: ");
            try
            {
                Edad = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de edad no válido. Se establecerá a 0.");
                Edad = 0;
            }
            Console.WriteLine("Introduce el dni (sin la letra): ");
            Dni = Console.ReadLine();
        }

        public abstract double Hacienda();



    }
}
