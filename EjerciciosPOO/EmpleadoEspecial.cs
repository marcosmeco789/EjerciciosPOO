using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPOO
{
    class EmpleadoEspecial : Empleado, IPastaGansa
    {
        public double ganarPasta(double beneficiosEmp)
        {
            double ganancia = beneficiosEmp * 0.05;
            return ganancia;
        }

        public override double Hacienda()
        {
            return base.Hacienda() * (1.005);
        }

        public EmpleadoEspecial(string nombre, string apellidos, int edad, string dni, int salario, string telefono)
            :base(nombre,  apellidos,  edad,  dni,  salario, telefono)
            
        {

        }
    }
}
