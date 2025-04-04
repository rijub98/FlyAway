using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class Bookings
    {
        [Key]
        public int Bookings_ID { get; set; }
        public string Bookings_Date { get; set; }
        public int Bookings_Cost { get; set; }

        // Foreign key for Flight
        public int Flights_ID { get; set; }

        [ForeignKey("Flights_ID")]
        public Flights Flight { get; set; }

        // Foreign key for Seat
        public int Seats_ID { get; set; }

        [ForeignKey("Seats_ID")]
        public Seats Seat { get; set; }

        // Foreign key for Passenger
        public int Passenger_ID { get; set; }

        [ForeignKey("Passenger_ID")]
        public Passenger Passenger { get; set; }
    }
}
