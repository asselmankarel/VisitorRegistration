using System;
using VisitorRegistrationLibrary.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace VisitorRegistrationLibrary.DataAccess
{
    public class MySqlConnector : IDataConnector
    {

        private string ConnectionString = "Server=127.0.0.1;Database=visitor-registration;User Id=root;Password=root;";

        public MySqlConnector()
        {
        }

        public void CreateCompany(CompanyModel model)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            { 
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "AddCompany";
                    cmd.Parameters.AddWithValue("@CompanyName", model.Name);
                    cmd.Parameters["@CompanyName"].Direction = System.Data.ParameterDirection.Input;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            
        }

        public List<CompanyModel> GetAllCompanies()
        {
            List<CompanyModel> output = new List<CompanyModel>();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllCompanies";
                  

                    connection.Open();
                    cmd.Connection = connection;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CompanyModel model = new CompanyModel();
                        model.Id = (int)reader["Id"];
                        model.Name = (string)reader["Name"];
                        output.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }

            return output;
        }
    }
}