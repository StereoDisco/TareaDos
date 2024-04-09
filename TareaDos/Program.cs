using TareaDos.Models;
using TareaDos.Services;
using TareaDos.Data_Access;


class Program
{
    static void Main()
    {

        Console.WriteLine("Mostrando todos los empleados en una lista");
        EmpleadoServices empleadoServices = new EmpleadoServices();
        List<EmpleadoDTO> empleadoDTOs = empleadoServices.ShowAll();
        foreach (EmpleadoDTO e in empleadoDTOs)
        {
            e.showInformation();
        }

        Console.WriteLine();
        Console.WriteLine("Mostrando un empleado por documento");

        EmpleadoDTO empleado = empleadoServices.GetByDocument("30901234");
        empleado.showInformation();


        Console.WriteLine();
        Console.WriteLine("Mostrando un empleado por id");


        EmpleadoDTO empleadoPorId = empleadoServices.GetByID(3);
        empleadoPorId.showInformation();

        
        Console.WriteLine("");
        Console.WriteLine("** Mostrando Todas las Áreas **");


        AreaServices areaServices = new AreaServices();
        List<AreasDTO> areasDTOs = new AreaServices().GetAll();
        foreach (AreasDTO a in areasDTOs)
        {
            a.showInformation();
        }

        Console.WriteLine("");
        Console.WriteLine("** Mostrando Área por Nombre **");

        AreasDTO areaPorNombre = areaServices.GetByName("Testing");
        areaPorNombre.showInformation();
        Console.WriteLine("");
       


        Console.WriteLine("");
        Console.WriteLine("** Mostrando Empleado con área **");

        EmpleadoServices empleadoServices1 = new EmpleadoServices();
        List<EmpleadoAreaDTO> empleadoAreaDTO = empleadoServices1.GetByArea("testing");
        foreach (EmpleadoAreaDTO a in empleadoAreaDTO)
        { a.showInformation(); }
        Console.ReadKey(true);
    }
}