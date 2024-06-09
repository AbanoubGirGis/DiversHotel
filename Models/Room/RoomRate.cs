using Models.Seasons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Room
{
    public class RoomRate
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        public RoomType roomType { get; set; }

        [Required]
        [ForeignKey("Season")]
        public int SeasonId { get; set; }

        public Season season { get; set; }

        [Required]
        public decimal RatePerNight { get; set; }
    }
}
