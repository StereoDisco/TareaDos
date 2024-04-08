using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaDos.Models
{
    public class EmpleadoDTO
    {
        private int id;
        private string nombre;
        private string documento;
        private string direccion;
        private string telefono;
        private int areaId;

        public EmpleadoDTO () { }
        public EmpleadoDTO (int id, string nombre, string documento, string direccion, string telefono, int areaId)
        {
            this.id = id;
            this.nombre = nombre;
            this.documento = documento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.areaId = areaId;
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
        public string Documento
        { 
            get { return documento; } 
            set {  documento = value; } 
        }
        public string Direccion
        { 
            get { return direccion; } 
            set { direccion = value; } }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public int AreaId 
        {  
            get { return areaId; } 
            set {  areaId = value; } 
        }

        public void showInformation()
        {
            Console.WriteLine($"Id: {id} | Nombre: {nombre} | Documento: {documento} | Dirección {direccion} | Telefono: {telefono} | Area ID: {areaId}");
        }
    }
    

}