using Microsoft.Data.SqlClient;
using System;

namespace GAMEHrms
{
    public class PlayerAccount
    {
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string AccountStatus { get; set; }
        public string AccountType { get; set; }
    }
}
