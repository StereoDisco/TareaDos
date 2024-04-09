using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaDos.Data_Access;
using TareaDos.Models;

namespace TareaDos.Services;

    public class AreaServices
    {
        private DBConnector connector = DBConnector.GetInstance();
        public List<AreasDTO> GetAll()
        {
            List<AreasDTO> areasDTOs = new List<AreasDTO>();
            try
            {
                using (MySqlConnection connection = connector.ConnectToDatabase())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand($"SELECT * FROM AREAS", connection))
                    {
                        using (MySqlDataReader reader =command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AreasDTO area = new AreasDTO
                                {
                                    Id = int.Parse(reader["id"].ToString()),
                                    Nombre = reader["nombre"].ToString(),
                                    Descripcion = reader["descripcion"].ToString(),
                                };
                                areasDTOs.Add(area);
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
            return areasDTOs;
        }

    public AreasDTO GetByName(string nombre)
    {
        try
        {
            using (MySqlConnection connection =connector.ConnectToDatabase())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT * FROM AREAS WHERE nombre = @Nombre", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AreasDTO area = new AreasDTO
                                {
                                    Id = int.Parse(reader["id"].ToString()),
                                    Nombre = reader["nombre"].ToString(),
                                    Descripcion = reader["descripcion"].ToString(),
                                };
                                return area;
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
        
    }

