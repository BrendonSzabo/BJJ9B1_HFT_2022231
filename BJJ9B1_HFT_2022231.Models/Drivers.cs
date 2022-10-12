using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Models
{
    public class Drivers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(240)]
        public string DriverName { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }
        [StringLength(240)]
        public string TeamName { get; set; }
        public DateTime Born { get; set; }
        [StringLength(240)]
        public string Nationality { get; set; }

        public Drivers()
        {
        }
        /// <summary>
        /// Teams virtual method
        /// </summary>
        public virtual Teams Tm { get; set; }
        public Drivers(string s)
        {

            string[] split = s.Split(';');
            id = Convert.ToInt32(split[0]);
            DriverName = split[1];
            Number = Convert.ToInt32(split[2]);
            TeamId = Convert.ToInt32(split[3]);
            Birth = Convert.ToDateTime(split[4].Replace('_', '.'));
            CurrentPoints = Convert.ToInt32(split[5]);
            GPWins = Convert.ToInt32(split[6]);
            Podiums = Convert.ToInt32(split[7]);
            ChampionshipVictories = Convert.ToInt32(split[8]);
        }
    }
}
