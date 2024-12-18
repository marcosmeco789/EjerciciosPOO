using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPOO
{
    class Directivo : Persona, IPastaGansa
    {
        public string Departamento { set ; get; }
        private double beneficios;
        private int personas;
        private double pastaGanada;


        public double PastaGanada
        {
            set
            {
                pastaGanada = value;
            }
            get
            {
                return pastaGanada;
            }

        }

        public int Personas
        {
            set
            {
                personas = value;
                if (value <= 10)
                {
                    beneficios = 2;
                }
                else if ( value <= 50)
                {
                    beneficios = 3.5;
                }
                else 
                {
                    beneficios = 4;
                }
            }

            get
            {
                return personas;
            }

        }

        public static Directivo operator --(Directivo d1)
        {
                d1.beneficios--;
            if (d1.beneficios < 0)
            {
                d1.beneficios = 0;
            }

            return d1;
        }


        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine("Departamento: " + Departamento);
            Console.WriteLine("Beneficios: " + beneficios);
            Console.WriteLine("Personas: " + Personas);
        }

        public override void Introduccion()
        {
            base.Introduccion();

            Console.WriteLine("Introduce el nombre del departamento: ");
            Departamento = Console.ReadLine();

            Console.WriteLine("Introduce el numero de personas: ");
            Personas = int.Parse(Console.ReadLine());

        }



        public double ganarPasta(double beneficiosEmp)
        {
            Directivo d = this;

            if (beneficiosEmp <= 0)
            {
                d--;
                this.PastaGanada = 0;
                return 0;
            }

            double ganancia = beneficiosEmp * beneficiosEmp / 100;
            beneficiosEmp = ganancia;
            PastaGanada = ganancia;
            return ganancia;


        }
        public override double Hacienda()
        {
            return PastaGanada * 0.30;
        }


        public Directivo(string nombre, string apellidos, int edad, string dni, string departamento,int personas)
            :base(nombre, apellidos, edad, dni)
        {
            this.Departamento = departamento;
            this.Personas = personas;
        }


        public Directivo()
        {
            
        }
    }
}
