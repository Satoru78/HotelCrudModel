using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrudModel
{
    public class Hotel
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Stardom { get; set; }


        public string GetInfo()
        {
            if
            (!string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(Title) &&
            !string.IsNullOrEmpty(Stardom))
            {
                return $"ID: {ID}, Title: {Title}, Country: {Country}, Stardom: {Stardom}";
            }
            else
            {
                return "Error!Not found...";
            }
        }
    }
}
