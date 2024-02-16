using System;

namespace GAMEHrms
{
    public class GameStats
    {
        public int StatsID { get; set; }
        public int PlayerID { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public double AverageScore { get; set; }
    }
}
