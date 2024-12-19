using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPOO
{
    internal class Escritora : BinaryWriter
    {
        public Escritora(Stream str) : base(str)
        {
        }

        public void Write(Empleado emp)
        {
            base.Write("emp");
            base.Write(emp.Nombre);
            base.Write(emp.Apellidos);
            base.Write(emp.Edad);
            base.Write(emp.Dni);
            base.Write(emp.Salario);
            base.Write(emp.Telefono);
        }

        public void Write(Directivo dir)
        {
            base.Write("dir");
            base.Write(dir.Nombre);
            base.Write(dir.Apellidos);
            base.Write(dir.Edad);
            base.Write(dir.Dni);
            base.Write(dir.Departamento);
            base.Write(dir.Personas);
        }


   
    }
}
