using System;

namespace GAMEHrms
{
    public class PasswordHistory
    {
        public int HistoryID { get; set; }
        public int PlayerID { get; set; }
        public string OldPassword { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
