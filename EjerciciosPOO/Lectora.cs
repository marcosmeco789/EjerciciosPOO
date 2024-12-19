﻿using System;
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

        public Directivo ReadDirectivo()
        {


            string nombre = ReadString();
            string apellidos = ReadString();
            int edad = ReadInt32();
            string dni = ReadString();
            double salario = ReadDouble();
            string departamento = ReadString();
            int personas = ReadInt32();

            return new Directivo(nombre, apellidos, edad, dni, departamento, personas);
        }
    }
}
