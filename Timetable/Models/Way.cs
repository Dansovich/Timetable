using System.ComponentModel.DataAnnotations;

namespace Timetable.Models
{
    public class Way
    {
        [Key] public int wayId { get; set; }
        public string vehicleType { get; set; }
    }
}
