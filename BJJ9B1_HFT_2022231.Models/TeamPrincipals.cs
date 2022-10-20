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
        public int? ChampionshipWins { get; set; }
        public DateTime? FirstWin { get; set; }

        /// <summary>
        /// Teams virtual method
        /// </summary>
        public virtual Teams Tm { get; set; }

        public TeamPrincipals()
        {
        }
        /// <summary>
        /// constructor values
        /// </summary>
        /// <param name="s">id/name/teamid/debutdate/birth/wins/teamid</param>
        public TeamPrincipals(string s)
        {
            string[] f = s.Split('/');
            this.Id = int.Parse(f[0]);
            PrincipalName = f[1];
            DebutDate = Convert.ToDateTime(f[2]);
            Birth = Convert.ToDateTime(f[3]);
            ChampionshipWins = int.Parse(f[4]);
            if (f[6] == "null")
            {
                FirstWin = null;
            }
            else
            {
                FirstWin = Convert.ToDateTime(f[5]);
            }
            TeamID = int.Parse(f[6]);
        }
    }
}
