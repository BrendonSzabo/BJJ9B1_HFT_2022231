using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Models
{
    public class TeamPrincipals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, 10)]
        [Required]
        public int Id { get; set; }
        [StringLength(240)]
        [Required]
        
        public string PrincipalName { get; set; }
        [Range(1,10)]
        [Required]
        public int TeamID { get; set; }
        [Required]
        public DateTime DebutDate { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        [Required]
        public int ChampionshipWins { get; set; }
        public DateTime? FirstWin { get; set; }

        /// <summary>
        /// Teams virtual method
        /// </summary>
        /// 
        
        public virtual Teams Tm { get; set; }

        public TeamPrincipals()
        {
        }
        /// <summary>
        /// constructor values
        /// </summary>
        /// <param name="s">id/name/debutdate/birth/wins/firstwin/teamid</param>
        public TeamPrincipals(string s)
        {
            string[] f = s.Split('/');
            this.Id = int.Parse(f[0]);
            PrincipalName = f[1];
            DebutDate = Convert.ToDateTime(f[2]);
            Birth = Convert.ToDateTime(f[3]);
            ChampionshipWins = int.Parse(f[4]);
            if (f[5] == "null")
            {
                FirstWin = null;
            }
            else
            {
                FirstWin = Convert.ToDateTime(f[5]);
            }
            TeamID = int.Parse(f[6]);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {PrincipalName}, Team Id: {TeamID}, Debute Date: {DebutDate.Year}.{DebutDate.Month}.{DebutDate.Day}, Birth Date: {Birth.Year}.{Birth.Month}.{Birth.Day}, Wins: {ChampionshipWins}, Team Id: {TeamID}";
        }
    }
}
