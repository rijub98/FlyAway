using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class Seats
    {
        [Key]
        public int Seats_ID { get; set; }
        public string Seats_Type { get; set; }
        public int Total_Seats { get; set; }
        public int Price_Per_Seat { get; set; }
        public int Check_In_Baggage_Per_Seat { get; set; }

        // Foreign key for Flights  (One to Many Relationship)
        public int Flights_ID { get; set; }
        [ForeignKey("Flights_ID")]
        public Flights Flight { get; set; }

        public List<Bookings> Bookings { get; set; }

    }
}
