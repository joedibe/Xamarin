using System;
using System.Collections.Generic;
using System.Text;

namespace ListExercise.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string NameWithAddress
        {
            get
            {
                return string.Format("{0}, {1}", Name, Address);
            }
        }

        public string CheckInAndOutDate
        {
            get
            {
                return string.Format("{0} - {1}", CheckInDate.ToString("MMMM dd, yyyy"), CheckOutDate.ToString("MMMM dd, yyyy"));
            }
        }
    }
}
