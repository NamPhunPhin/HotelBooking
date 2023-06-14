﻿using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class QuatityHotelsInTheCityModel
    {
        [Key]
        public int city_id { get; set; }

        public string? name { get; set; }

        public string? image_name { get; set; }

        public int? quatity_hotels { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}