using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Models
{
    class Drivers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [StringLength(240)]
        public string DriverName { get; set; }
        public Guid TeamId { get; set; }
        public DateTime Birth { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime FirstPole { get; set; }
        public DateTime FirstGPVictory { get; set; }
        public DateTime FirstChampionshipWin { get; set; }
        public int ChampionshipVictories { get; set; }
        public int CurrentPoints { get; set; }
        public int RaceStarts { get; set; }
        public int GPWins { get; set; }

    }
}
