using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPOO
{
    class Empleado : Persona
    {
        private double salario;
        private double irpf;
        private string telefono;

        public double Salario
        {
            set
            {
                salario = value;
                if (value < 600)
                {
                    irpf = 7;
                }
                else if (value <= 3000)
                {
                    irpf = 15;
                }
                else
                {
                    irpf = 20;
                }

            }

            get
            {
                return salario;
            }

        }

        public double Irpf
        {
            get
            {
                return irpf;
            }
        }

        public string Telefono
        {
            set
            {
                telefono = value;
            }

            get
            {
                return "+34" + telefono;
            }
        }

        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine(Salario);
            Console.WriteLine(Irpf);
            Console.WriteLine(Telefono);


        }

        public override void Introduccion()
        {
            base.Introduccion();
            Console.WriteLine("Introduce el salario: ");
            Salario = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el telefono: ");
            Telefono = Console.ReadLine();
        }

        public void mostrar(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("Nombre: " + Nombre);
                    break;

                case 1:
                    Console.WriteLine("Apellidos: " + Apellidos);
                    break;

                case 2:
                    Console.WriteLine("Edad: " + Edad);
                    break;

                case 3:
                    Console.WriteLine("Dni: " + Dni);
                    break;

                case 4:
                    Console.WriteLine("Salario: " + Salario);
                    break;

                case 5:
                    Console.WriteLine("Irpf: " + Irpf);
                    break;

                case 6:
                    Console.WriteLine("Telefono: " + Telefono);
                    break;


                default:
                    break;
            }
        }


        public override double Hacienda()
        {
            return (Irpf * Salario / 100);
        }


        public Empleado(string nombre, string apellidos, int edad, string dni, int salario, string telefono)
            : base(nombre, apellidos, edad, dni)
        {

            this.Salario = salario;
            this.Telefono = telefono;

        }

        public Empleado()
            : this("", "", 0, "", 0, "")
        {

        }
    }
}
