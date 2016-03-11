using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionService.Connections
{
    public class _3AmigoService
    {
        public _3AmigoService()
        {
            string SQLConnectionString;

            SQLConnectionString = "Server=tcp:amigos.database.windows.net,1433;Database=3Amigo;User ID=HeadHoncho@amigos;Password={Doritos!};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            using (SqlConnection connection = new SqlConnection(SQLConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandType = CommandType.Text;
                command.CommandText = @""; //Put Command Here

                connection.Open();

                //SqlDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    //Assign it to a collection or something
                //}
            }
        }
    }
}
