using System;

namespace GAMEHrms
{
    public class PlayerProgress
    {
        public int ProgressID { get; set; }
        public int PlayerID { get; set; }
        public int GameLevel { get; set; }
        public int ExperiencePoints { get; set; }
        public string Achievements { get; set; }
    }
}
