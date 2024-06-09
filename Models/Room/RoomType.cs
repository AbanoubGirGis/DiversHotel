﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Room
{
    public class RoomType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
