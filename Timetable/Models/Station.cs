using System.ComponentModel.DataAnnotations;

namespace Timetable.Models
{
    public class Station
    {
        [Key] public int stationId { get; set; }
        public string stationName { get; set; } 
    }
}
