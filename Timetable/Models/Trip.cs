using System.ComponentModel.DataAnnotations;

namespace Timetable.Models
{
    public class Trip
    {
        [Key] public int tripId { get; set; }
        public int wayId { get; set; }
        public DateTime dateAndTime { get; set; }
    }
}
