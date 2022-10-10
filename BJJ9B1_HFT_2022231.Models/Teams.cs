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
        public int id { get; set; }
        public int Ranking { get; set; }
        [StringLength(240)]
        public string TeamName { get; set; }
        public DateTime FirstEntry { get; set; }
        public int ConstructorPoints { get; set; }
        public int RaceStarts { get; set; }
        public int PrincipalID { get; set; }
        public int Wins { get; set; }

        /// <summary>
        /// Driver virtual method
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

        public Teams(string s)
        {

            string[] f = s.Split('/');
            this.id = int.Parse(f[0]);
            Ranking = int.Parse(f[3]);
            TeamName = f[1];
            FirstEntry = Convert.ToDateTime(f[2]);
            ConstructorPoints = int.Parse(f[4]);
            RaceStarts = int.Parse(f[6]);
            Drv = new HashSet<Drivers>();
        }
    }
}
