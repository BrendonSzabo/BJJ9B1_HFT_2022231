using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Models
{
    public class Teams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1,10)]
        [Required]
        public int Id { get; set; }
        [Range(1, 10)]
        [Required]
        public int Ranking { get; set; }
        [StringLength(240)]
        [Required]
        public string TeamName { get; set; }
        [Required]
        public DateTime FirstEntry { get; set; }
        [Required]
        public int ConstructorPoints { get; set; }
        [Required]
        public int RaceStarts { get; set; }
        [Range(1, 10)]
        [Required]
        public int PrincipalID { get; set; }
        [Required]
        public int Wins { get; set; }

        /// <summary>
        /// Driver virtual collection method
        /// </summary>
        public virtual ICollection<Drivers> Drv { get; set; }
        /// <summary>
        /// TeamPrincipals virtual method
        /// </summary>
        public virtual TeamPrincipals Princ { get; set; }

        public Teams()
        {
            Drv = new HashSet<Drivers>();
        }
        /// <summary>
        /// constructor values
        /// </summary>
        /// <param name="s">id/name/firstentry/rank/championshippoints/racestarts</param>
        public Teams(string s)
        {
            string[] f = s.Split('/');
            this.Id = int.Parse(f[0]);
            TeamName = f[1];
            FirstEntry = Convert.ToDateTime(f[2]);
            Ranking = int.Parse(f[3]);
            ConstructorPoints = int.Parse(f[4]);
            RaceStarts = int.Parse(f[5]);
            Drv = new HashSet<Drivers>();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Team Name: {TeamName}, First Entry: {FirstEntry.Year}.{FirstEntry.Month}.{FirstEntry.Day}, Rank: {Ranking}, Championship points: {ConstructorPoints}, Race Starts: {RaceStarts}";
        }
    }
}
