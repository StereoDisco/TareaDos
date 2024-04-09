using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaDos.Models
{
    public class AreasDTO
    {
        private int id;
        private string nombre;
        private string descripcion;
        

        public AreasDTO () { }
        public AreasDTO (int id, string nombre, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public int Id
        { 
            get { return id; }
            set { id = value; }
        }
        
        public string Nombre 
        { 
            get { return nombre;  }
            set {  nombre = value; }
        }
        public string Descripcion
        { 
            get { return descripcion; } 
            set {  descripcion = value; } 
        }
            

        public void showInformation()
        {
            Console.WriteLine($"Id: {id} | Nombre: {nombre} | Documento: {descripcion}");
        }
    }
    

}