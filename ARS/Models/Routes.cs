using System.ComponentModel.DataAnnotations;

namespace ARS.Models
{
    public class Routes
    {
        [Key]
        public int Route_ID { get; set; }
        public string Departure_City { get; set; }
        public string Arrival_City { get; set; }
        public string Departure_Time { get; set; }
        public string Arrival_Time { get; set; }
        public int No_Of_Passenger { get; set; }


        public List<Flights> Flights { get; set; }
    }
}
