using System.ComponentModel.DataAnnotations;

namespace ARS.Models
{
    public class Passenger
    {
        [Key]
        public int Passenger_ID { get; set; }
        public string Passenger_Name { get; set; }
        public string Passenger_Gender { get; set; }
        public string Passenger_DOB { get; set; }
        public string Passenger_Contact { get; set; }

        public List<Bookings> Bookings { get; set; }
    }
}
