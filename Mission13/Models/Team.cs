using System;
using System.ComponentModel.DataAnnotations;

namespace Mission13.Models
{
    public class Team
    {
        // create the Team table and class
        [Key]
        [Required]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        public int CaptainID { get; set; }
    }
}
