using TareaDos.Models;
using TareaDos.Services;
using TareaDos.Data_Access;


class Program
{
    static void Main()
    {
        Console.WriteLine("Mostrando todos los empleados en una linea");
        EmpleadoServices empleadoServices = new EmpleadoServices();
        List<EmpleadoDTO> empleadoDTOs = empleadoServices.ShowAll();
        foreach (EmpleadoDTO e in empleadoDTOs)
        {
            e.showInformation();
        }

        Console.ReadKey(true);



    }
}