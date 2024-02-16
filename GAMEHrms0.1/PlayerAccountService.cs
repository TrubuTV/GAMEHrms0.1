using GAMEHrms;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace GAMEHrms
{
    public class PlayerAccountService
    {
        private readonly string connectionString;

        public PlayerAccountService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(PlayerAccount account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO PlayerAccount (Username, Password, Email, RegistrationDate, LastLoginDate, AccountStatus, AccountType) " +
                    "VALUES (@Username, @Password, @Email, @RegistrationDate, @LastLoginDate, @AccountStatus, @AccountType)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", account.Username);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@Email", account.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", account.RegistrationDate);
                    command.Parameters.AddWithValue("@LastLoginDate", account.LastLoginDate);
                    command.Parameters.AddWithValue("@AccountStatus", account.AccountStatus);
                    command.Parameters.AddWithValue("@AccountType", account.AccountType);

                    command.ExecuteNonQuery();
                }
            }
        }

        public PlayerAccount Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT * FROM PlayerAccount WHERE PlayerID = {id}";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PlayerAccount
                            {
                                PlayerID = Convert.ToInt32(reader["PlayerID"]),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Email = reader["Email"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]),
                                LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"]),
                                AccountStatus = reader["AccountStatus"].ToString(),
                                AccountType = reader["AccountType"].ToString(),

                                

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

        public void Update(PlayerAccount account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = $"UPDATE PlayerAccount SET " +
                    $"Username = '{account.Username}', Password = '{account.Password}', Email = '{account.Email}', " +
                    $"RegistrationDate = '{account.RegistrationDate}', LastLoginDate = '{account.LastLoginDate}', " +
                    $"AccountStatus = '{account.AccountStatus}', AccountType = '{account.AccountType}' " +
                    $"WHERE PlayerID = {account.PlayerID}";
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
                string deleteQuery = $"DELETE FROM PlayerAccount WHERE PlayerID = {id}";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
