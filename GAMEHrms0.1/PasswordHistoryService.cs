using Microsoft.Data.SqlClient;
using System;
using GAMEHrms;

namespace GAMEHrms 
{
    public class PasswordHistoryService
    {
        private readonly string connectionString;

        public PasswordHistoryService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(PasswordHistory history)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO PasswordHistory (PlayerID, PasswordHash, ChangeTime) " +
                    $"VALUES ({history.PlayerID}, '{history.OldPassword}', '{history.ChangeTime}')";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<PasswordHistory> ReadAllForPlayer(int id)
        {
            var histories = new List<PasswordHistory>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = $"SELECT * FROM PasswordHistory WHERE PlayerID = {id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerID", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var history = new PasswordHistory
                            {
                                HistoryID = reader.GetInt32(reader.GetOrdinal("PasswordID")),
                                PlayerID = reader.GetInt32(reader.GetOrdinal("PlayerID")),
                                OldPassword = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                ChangeTime = reader.GetDateTime(reader.GetOrdinal("ChangeTime"))
                            };
                            histories.Add(history);
                        }
                    }
                }
            }

            return histories;
        }


        public void Update(PasswordHistory history)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = $"UPDATE PasswordHistory SET " +
                    $"PlayerID = {history.PlayerID}, OldPassword = '{history.OldPassword}', ChangeTime = '{history.ChangeTime}' " +
                    $"WHERE HistoryID = {history.HistoryID}";
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
                string deleteQuery = $"DELETE FROM PasswordHistory WHERE HistoryID = {id}";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
