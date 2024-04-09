using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaDos.Data_Access;
using TareaDos.Models;

namespace TareaDos.Services;

public class EmpleadoServices
{
    private DBConnector connector = DBConnector.GetInstance();
    public List<EmpleadoDTO> ShowAll()
    {
        List<EmpleadoDTO> empleadoDTOs = new List<EmpleadoDTO>();
        try
        {
            using (MySqlConnection connection = connector.ConnectToDatabase())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM EMPLEADOS", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmpleadoDTO empleado = new EmpleadoDTO
                            {
                                Id = int.Parse(reader["id"].ToString()),
                                Nombre = reader["nombre"].ToString(),
                                Documento = reader["documento"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                AreaId = int.Parse(reader["area_id"].ToString()),
                            };
                            empleadoDTOs.Add(empleado);
                        }
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine($"Error en la base de datos al obtener los empleados: {e.Message}");
        }
        catch (Exception e)
        {
            throw new Exception("no se puede realizar la consulta {}", e);
        }
        return empleadoDTOs;
    }

    public EmpleadoDTO GetByDocument(string documento)
    {
        try
        {
            using (MySqlConnection connection = connector.ConnectToDatabase())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM EMPLEADOS WHERE documento = @Documento", connection))
                {
                    command.Parameters.AddWithValue("@Documento", documento);
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EmpleadoDTO empleado = new EmpleadoDTO
                                {
                                    Id = int.Parse(reader["id"].ToString()),
                                    Nombre = reader["nombre"].ToString(),
                                    Documento = reader["documento"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    AreaId = int.Parse(reader["area_id"].ToString()),
                                };
                                return empleado;
                            }
                            else
                            {
                                throw new Exception("Empleado no encontrado");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("No se pudo realizar la consulta: {}", e);
        }

    }

    public EmpleadoDTO GetByID(int id)
    {
        try
        {
            using (MySqlConnection connection = connector.ConnectToDatabase())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM EMPLEADOS WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EmpleadoDTO empleado = new EmpleadoDTO
                                {
                                    Id = int.Parse(reader["id"].ToString()),
                                    Nombre = reader["nombre"].ToString(),
                                    Documento = reader["documento"].ToString(),
                                    Direccion = reader["direccion"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    AreaId = int.Parse(reader["area_id"].ToString()),
                                };
                                return empleado;
                            }
                            else
                            {
                                throw new Exception("Empleado no encontrado");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("No se pudo realizar la consulta: {}", e);
        }
    }

    public List<EmpleadoAreaDTO> GetByArea(string area)
    {
        List<EmpleadoAreaDTO> empleadoAreaDTOs = new List<EmpleadoAreaDTO>();
        try
        {
            using (MySqlConnection connection = connector.ConnectToDatabase())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT EMPLEADOS.nombre, EMPLEADOS.documento, AREAS.nombre as AREANOM FROM EMPLEADOS JOIN AREAS ON EMPLEADOS.area_id = AREAS.id WHERE AREAS.Nombre = @Area", connection))
                {
                    command.Parameters.AddWithValue("@Area", area);
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmpleadoAreaDTO empleadoArea = new EmpleadoAreaDTO
                                {
                                    Nombre = reader["nombre"].ToString(),
                                    Documento = reader["documento"].ToString(),
                                    Area = reader["AREANOM"].ToString(),
                                };

                                empleadoAreaDTOs.Add(empleadoArea);
                            }
                            return empleadoAreaDTOs;

                            throw new Exception("Empleado no encontrado");
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("No se pudo realizar la consulta: {}", e);
        }
        
    }
        
    }



