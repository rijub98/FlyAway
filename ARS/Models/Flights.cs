using System.ComponentModel.DataAnnotations;

namespace ARS.Models
{
    public class Flights
    {
        [Key]
        public int Flights_ID { get; set; }
        public string Flights_Name { get; set; }
        public string Flights_Type { get; set; }
        public string Flights_Status { get; set; }
        public int Flights_Duration { get; set; }
        public int Flights_Amount { get; set; }

        // Foreign key for Routes  (One to Many Relationship)
        public int RouteID { get; set; }
        public Routes Route { get; set; }

        public List<Seats> Seats { get; set; }

        public List<Bookings> Bookings { get; set; }
    }
}
