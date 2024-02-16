using GAMEHrms;
using Microsoft.Data.SqlClient;
using System;

namespace GAMEHrms0._1
{
    public class PlayerDetailsService
    {
        private readonly string connectionString;

        public PlayerDetailsService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(PlayerDetails details)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO PlayerDetails (FirstName, LastName, DateOfBirth, Address, PhoneNumber) " +
                    $"VALUES ('{details.FirstName}', '{details.LastName}', '{details.DateOfBirth}', '{details.Address}', '{details.PhoneNumber}')";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public PlayerDetails Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT * FROM PlayerDetails WHERE PlayerID = {id}";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PlayerDetails
                            {
                                PlayerID = Convert.ToInt32(reader["PlayerID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void Update(PlayerDetails details)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = $"UPDATE PlayerDetails SET " +
                    $"FirstName = '{details.FirstName}', LastName = '{details.LastName}', DateOfBirth = '{details.DateOfBirth}', " +
                    $"Address = '{details.Address}', PhoneNumber = '{details.PhoneNumber}' " +
                    $"WHERE PlayerID = {details.PlayerID}";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = $"DELETE FROM PlayerDetails WHERE PlayerID = {id}";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
