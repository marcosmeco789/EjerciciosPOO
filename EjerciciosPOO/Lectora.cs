using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPOO
{
    internal class Lectora : BinaryReader
    {
        public Lectora(Stream str) : base(str)
        {
        }

        public Empleado ReadEmpleado()
        {
            try
            {
                string nombre = ReadString();
                string apellidos = ReadString();
                int edad = ReadInt32();
                string dni = ReadString();
                if (dni.Length > 0)
                {
                    dni = dni.Remove(dni.Length - 1);
                }
                double salario = ReadDouble();
                string telefono = ReadString().Substring(3);

                return new Empleado(nombre, apellidos, edad, dni, salario, telefono);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR AL LEER EL ARCHIVO: " + ex.Message);
                Console.WriteLine("Presione cualquier tecla para cerrar...");
                Console.ReadKey();
                BaseStream.Close();
                Environment.Exit(1);
                return null;
            }
        }

        public Directivo ReadDirectivo()
        {
            string nombre = ReadString();
            string apellidos = ReadString();
            int edad = ReadInt32();
            string dni = ReadString();
            if (dni.Length > 0)
            {
                dni = dni.Remove(dni.Length - 1);
            }
            string departamento = ReadString();
            int personas = ReadInt32();

            return new Directivo(nombre, apellidos, edad, dni, departamento, personas);
        }
    }
}
