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
                        using (MySqlDataReader reader =command.ExecuteReader())
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

    }

