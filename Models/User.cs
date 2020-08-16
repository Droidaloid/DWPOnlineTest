using System;


namespace DWPOnlineTest.Models
{
    public class User : IComparable
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string ip_address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public int CompareTo(object other)
        {
            User temp = (User) other;

            if (temp.id < this.id)
            {
                return 1;
            }
            if (temp.id > this.id)
            {
                return -1;
            }

            return 0;
            
        }


    }

}