using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Models
{
    public class TeamPrincipals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [StringLength(240)]
        public string PrincipalName { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime Birth { get; set; }
        public Guid TeamId { get; set; }
        public int ChampionshipWins { get; set; }
        /// <summary>
        /// First championship victory
        /// </summary>
        public DateTime FirstWin { get; set; }

    }
}
