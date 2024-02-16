using GAMEHrms;
using Microsoft.Data.SqlClient;
using System;

namespace GAMEHrms
{
    public class PlayerProgressService
    {
        private readonly string connectionString;

        public PlayerProgressService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(PlayerProgress progress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO PlayerProgress (PlayerID, GameLevel, ExperiencePoints, Achievements) " +
                    $"VALUES ({progress.PlayerID}, {progress.GameLevel}, {progress.ExperiencePoints}, '{progress.Achievements}')";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public PlayerProgress Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT * FROM PlayerProgress WHERE ProgressID = {id}";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PlayerProgress
                            {
                                ProgressID = Convert.ToInt32(reader["ProgressID"]),
                                PlayerID = Convert.ToInt32(reader["PlayerID"]),
                                GameLevel = Convert.ToInt32(reader["GameLevel"]),
                                ExperiencePoints = Convert.ToInt32(reader["ExperiencePoints"]),
                                Achievements = reader["Achievements"].ToString()

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


        public void Update(PlayerProgress progress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = $"UPDATE PlayerProgress SET " +
                    $"PlayerID = {progress.PlayerID}, GameLevel = {progress.GameLevel}, ExperiencePoints = {progress.ExperiencePoints}, " +
                    $"Achievements = '{progress.Achievements}' WHERE ProgressID = {progress.ProgressID}";
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
                string deleteQuery = $"DELETE FROM PlayerProgress WHERE ProgressID = {id}";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
