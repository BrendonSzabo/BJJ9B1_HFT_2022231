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
        public int Id { get; set; }
        [StringLength(240)]
        
        public string PrincipalName { get; set; }
        public int TeamID { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime Birth { get; set; }
        public int ChampionshipWins { get; set; }
        [StringLength(240)]
        public string? FirstWin { get; set; }

        /// <summary>
        /// Teams virtual method
        /// </summary>
        public virtual Teams Tm { get; set; }

        public TeamPrincipals()
        {
        }

        public TeamPrincipals(string s)
        {
            string[] f = s.Split('/');
            this.Id = int.Parse(f[0]);
            PrincipalName = f[1];
            DebutDate = Convert.ToDateTime(f[3]);
            Birth = Convert.ToDateTime(f[4]);
            ChampionshipWins = int.Parse(f[5]);
            if (f[6] == "null")
            {
                FirstWin = null;
            }
            else
            {
                FirstWin = f[6];
            }
            TeamID = int.Parse(f[7]);
        }
    }
}
