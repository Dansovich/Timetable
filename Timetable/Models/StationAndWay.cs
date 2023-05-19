using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Timetable.Models
{
    public class StationAndWay
    {
        [Key] public int stationAndWayId { get; set; } 
        public int stationId { get; set; }
        public int wayId { get; set; }
    }
}
