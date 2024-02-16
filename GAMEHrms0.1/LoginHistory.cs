using System;

namespace GAMEHrms0._1
{
    public class LoginHistory
    {
        public int LogID { get; set; }
        public int PlayerID { get; set; }
        public DateTime LoginTime { get; set; }
        public string IPAddress { get; set; }
    }
}
