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
    }
}
