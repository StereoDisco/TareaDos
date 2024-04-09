using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaDos.Models
{
    public class EmpleadoAreaDTO
    {
        private string nombre;
        private string documento;
        private string area;

        public EmpleadoAreaDTO () { }
        public EmpleadoAreaDTO (string nombre, string documento, string area)
        {
            this.nombre = nombre;
            this.documento = documento;
            this.area = area;
        }
        public string Nombre 
        { 
            get { return nombre;  }
            set {  nombre = value; }
        }
        public string Documento
        { 
            get { return documento; } 
            set {  documento = value; } 
        }
        public string Area 
        {  
            get { return area; } 
            set {  area = value; } 
        }

        public void showInformation()
        {
            Console.WriteLine($"Nombre: {nombre} | Documento: {documento} | Area: {area}");
        }
    }
    

}