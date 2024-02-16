using Microsoft.Data.SqlClient;
using System;

namespace GAMEHrms
{
    public class GameStatsService
    {

        private readonly string connectionString;

        public GameStatsService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(GameStats stats)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO GameStats (PlayerID, TotalGamesPlayed, TotalWins, TotalLosses, AverageScore) " +
                    $"VALUES ({stats.PlayerID}, {stats.TotalGamesPlayed}, {stats.TotalWins}, {stats.TotalLosses}, {stats.AverageScore})";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public GameStats Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT * FROM GameStats WHERE StatsID = {id}";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new GameStats
                            {
                                StatsID = Convert.ToInt32(reader["StatsID"]),
                                PlayerID = Convert.ToInt32(reader["PlayerID"]),
                                TotalGamesPlayed = Convert.ToInt32(reader["TotalGamesPlayed"]),
                                TotalWins = Convert.ToInt32(reader["TotalWins"]),
                                TotalLosses = Convert.ToInt32(reader["TotalLosses"]),
                                AverageScore = Convert.ToDouble(reader["AverageScore"])
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

        public void Update(GameStats stats)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = $"UPDATE GameStats SET " +
                    $"PlayerID = {stats.PlayerID}, TotalGamesPlayed = {stats.TotalGamesPlayed}, " +
                    $"TotalWins = {stats.TotalWins}, TotalLosses = {stats.TotalLosses}, AverageScore = {stats.AverageScore} " +
                    $"WHERE StatsID = {stats.StatsID}";
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
                string deleteQuery = $"DELETE FROM GameStats WHERE StatsID = {id}";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
