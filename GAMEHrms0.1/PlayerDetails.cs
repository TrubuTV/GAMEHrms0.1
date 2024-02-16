using System;

namespace GAMEHrms
{
    public class PlayerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int PlayerID { get; internal set; }
    }
}
