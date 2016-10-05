using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using HansonFoods.Enums;

namespace HansonFoods.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(256)]
        [Url]
        public string Url { get; set; }

        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public RatingEnum Rating { get; set; }
    }
}