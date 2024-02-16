using Microsoft.Data.SqlClient;
using System;

namespace GAMEHrms
{
    public class LoginHistoryService
    {
        private readonly string connectionString;

        public LoginHistoryService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(GAMEHrms0._1.LoginHistory history)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO LoginHistory (PlayerID, LoginTime, IPAddress) " +
                    $"VALUES ({history.PlayerID}, '{history.LoginTime}', '{history.IPAddress}')";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public GAMEHrms0._1.LoginHistory Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT * FROM LoginHistory WHERE LogID = {id}";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new GAMEHrms0._1.LoginHistory
                            {
                                LogID = Convert.ToInt32(reader["LogID"]),
                                PlayerID = Convert.ToInt32(reader["PlayerID"]),
                                LoginTime = Convert.ToDateTime(reader["LoginTime"]),
                                IPAddress = reader["IPAddress"].ToString()
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

        public void Update(GAMEHrms0._1.LoginHistory history)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = $"UPDATE LoginHistory SET " +
                    $"PlayerID = {history.PlayerID}, LoginTime = '{history.LoginTime}', IPAddress = '{history.IPAddress}' " +
                    $"WHERE LogID = {history.LogID}";
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
                string deleteQuery = $"DELETE FROM LoginHistory WHERE LogID = {id}";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
