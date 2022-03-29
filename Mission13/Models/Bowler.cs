using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission13.Models
{
    public class Bowler
    {
        // create the bowler table
        [Key]
        [Required]
        public int BowlerID { get; set; }

        [Required]
        public string BowlerLastName { get; set; }

        [Required]
        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit { get; set; }

        [Required]
        public string BowlerAddress { get; set; }

        [Required]
        public string BowlerCity { get; set; }

        [Required]
        public string BowlerState { get; set; }

        [Required]
        public string BowlerZip { get; set; }

        [Required]
        public string BowlerPhoneNumber { get; set; }

        // bring in the team table
        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
