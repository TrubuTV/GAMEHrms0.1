using GAMEHrms;
using GAMEHrms0._1;
using System;

class Program
{
    static string connectionString = "Data Source=DESKTOP-BFH2A89;Initial Catalog=GameHRMS;Integrated Security=True;Trust Server Certificate=True";
    static PlayerAccountService accountService = new PlayerAccountService(connectionString);
    static PlayerDetailsService detailsService = new PlayerDetailsService(connectionString);
    static PlayerProgressService progressService = new PlayerProgressService(connectionString);
    static GameStatsService statsService = new GameStatsService(connectionString);
    static LoginHistoryService loginHistoryService = new LoginHistoryService(connectionString);
    static PasswordHistoryService passwordHistoryService = new PasswordHistoryService(connectionString);

    

    static void Main(string[] args)
    {
        Console.WriteLine("GameHRMS Console Application");

        string option;
        do
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1: Create Player Account");
            Console.WriteLine("2: View Player Account");
            Console.WriteLine("3: Add Player Details");
            Console.WriteLine("4: View Player Details");
            Console.WriteLine("5: Add Player Progress");
            Console.WriteLine("6: View Player Progress");
            Console.WriteLine("7: Add Game Stats");
            Console.WriteLine("8: View Game Stats");
            Console.WriteLine("9: Add Login History");
            Console.WriteLine("10: View Login History");
            Console.WriteLine("11: Add Password History");
            Console.WriteLine("12: View Password History");
            Console.WriteLine("0: Exit");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreatePlayerAccount();
                    break;
                case "2":
                    Console.Clear();
                    ViewPlayerAccount();
                    break;
                case "3":
                    Console.Clear();
                    AddPlayerDetails();
                    break;
                case "4":
                    Console.Clear();
                    ViewPlayerDetails();
                    break;
                case "5":
                    Console.Clear();
                    AddPlayerProgress();
                    break;
                case "6":
                    Console.Clear();
                    ViewPlayerProgress();
                    break;
                case "7":
                    Console.Clear();
                    AddGameStats();
                    break;
                case "8":
                    Console.Clear();
                    ViewGameStats();
                    break;
                case "9":
                    Console.Clear();
                    AddLoginHistory();
                    break;
                case "10":
                    Console.Clear();
                    ViewLoginHistory();
                    break;
                case "11":
                    Console.Clear();
                    AddPasswordHistory();
                    break;
                case "12":
                    Console.Clear();
                    ViewPasswordHistory();
                    break;
                    
            }
        } while (option != "0");
    }

    static void CreatePlayerAccount()
    {
        Console.WriteLine("\nCreating Player Account...");
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        var account = new PlayerAccount
        {
            Username = username,
            Password = password,
            Email = email,
            RegistrationDate = DateTime.Now,
            LastLoginDate = DateTime.Now,
            AccountStatus = "Active",
            AccountType = "Regular"
        };

        accountService.Create(account);
        Console.WriteLine("Account created successfully.");
    }

    static void ViewPlayerAccount()
    {
        Console.WriteLine("\nEnter Player ID:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var account = accountService.Read(id);
            if (account != null)
            {
                Console.WriteLine($"Username: {account.Username}, Email: {account.Email}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void AddPlayerDetails()
    {
        Console.WriteLine("\nAdding Player Details...");
        Console.Write("Enter Player ID: ");
        int playerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter Address: ");
        string address = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();

        var details = new PlayerDetails
        {
            PlayerID = playerId,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Address = address,
            PhoneNumber = phoneNumber
        };

        detailsService.Create(details);
        Console.WriteLine("Details added successfully.");
    }

    static void ViewPlayerDetails()
    {
        Console.WriteLine("\nEnter Player ID to view details:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var details = detailsService.Read(id);
            if (details != null)
            {
                Console.WriteLine($"Name: {details.FirstName} {details.LastName}, Address: {details.Address}");
            }
            else
            {
                Console.WriteLine("Details not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void AddPlayerProgress()
    {
        Console.WriteLine("\nAdding Player Progress...");
        Console.Write("Enter Player ID: ");
        int playerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Game Level: ");
        int gameLevel = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Experience Points: ");
        int experiencePoints = Convert.ToInt32(Console.ReadLine());

        var progress = new PlayerProgress
        {
            PlayerID = playerId,
            GameLevel = gameLevel,
            ExperiencePoints = experiencePoints
        };

        progressService.Create(progress);
        Console.WriteLine("Progress added successfully.");
    }

    static void ViewPlayerProgress()
    {
        Console.WriteLine("\nEnter Progress ID to view progress:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var progress = progressService.Read(id);
            if (progress != null)
            {
                Console.WriteLine($"PlayerID: {progress.PlayerID},Player Level {progress.GameLevel}, Player Exp: {progress.ExperiencePoints},Achivements: {progress.Achievements}");
            }
            else
            {
                Console.WriteLine("Progress not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void AddGameStats()
    {
        Console.WriteLine("\nAdding Game Stats...");
        Console.Write("Enter Player ID: ");
        int playerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Total Games Played: ");
        int totalGamesPlayed = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Total Wins: ");
        int totalWins = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Total Losses: ");
        int totalLosses = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Average Score: ");
        double averageScore = Convert.ToDouble(Console.ReadLine());

        var stats = new GameStats
        {
            PlayerID = playerId,
            TotalGamesPlayed = totalGamesPlayed,
            TotalWins = totalWins,
            TotalLosses = totalLosses,
            AverageScore = averageScore
        };

        statsService.Create(stats);
        Console.WriteLine("Game Stats added successfully.");
    }

    static void ViewGameStats()
    {
        Console.WriteLine("\nEnter Stats ID to view game stats:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var stats = statsService.Read(id);
            if (stats != null)
            {
                Console.WriteLine($"PlayerID: {stats.PlayerID}, TotalGamesPlayed: {stats.TotalGamesPlayed}, TotalWins: {stats.TotalWins}, TotalLosses: {stats.TotalLosses}, AverageScore: {stats.AverageScore}");
            }
            else
            {
                Console.WriteLine("Game Stats not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void AddLoginHistory()
    {
        Console.WriteLine("\nAdding Login History...");
        Console.Write("Enter Player ID: ");
        int playerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Login Time (YYYY-MM-DD HH:mm:ss): ");
        DateTime loginTime = DateTime.Parse(Console.ReadLine());

        var loginHistory = new LoginHistory
        {
            PlayerID = playerId,
            LoginTime = loginTime
        };

        loginHistoryService.Create(loginHistory);
        Console.WriteLine("Login History added successfully.");
    }

    static void ViewLoginHistory()
    {
        Console.WriteLine("\nEnter History ID to view login history:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var loginHistory = loginHistoryService.Read(id);
            if (loginHistory != null)
            {
                Console.WriteLine($"PlayerID: {loginHistory.PlayerID}, LoginTime: {loginHistory.LoginTime}");
            }
            else
            {
                Console.WriteLine("Login History not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    static void AddPasswordHistory()
    {
        Console.WriteLine("\nAdding Password History...");
        Console.Write("Enter Player ID: ");
        int playerId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Old Password: ");
        string oldPassword = Console.ReadLine();
        Console.Write("Enter Change Time (YYYY-MM-DD HH:mm:ss): ");
        DateTime changeTime = DateTime.Parse(Console.ReadLine());

        var passwordHistory = new PasswordHistory
        {
            PlayerID = playerId,
            OldPassword = oldPassword,
            ChangeTime = changeTime
        };

        passwordHistoryService.Create(passwordHistory);
        Console.WriteLine("Password History added successfully.");
    }

    static void ViewPasswordHistory()
    {
        Console.WriteLine("\nEnter History ID to view password history:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var passwordHistory = passwordHistoryService.ReadAllForPlayer(id);
            if (passwordHistory != null)
            {
                Console.WriteLine($"PlayerID: {passwordHistory[0].PlayerID}, OldPassword: {passwordHistory[0].OldPassword}, ChangeTime: {passwordHistory[0].ChangeTime}");
            }
            else
            {
                Console.WriteLine("Password History not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}
