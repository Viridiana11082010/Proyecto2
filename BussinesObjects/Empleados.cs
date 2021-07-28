using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class Empleados
    {
        public int? id { get; set; }
        public string Nombre_Completo { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Correo_Eletronico{ get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        public string Celular{ get; set; } 

        public DateTime Fecha_Ingreso { get; set; }
}
}
