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
            //id/name/number/teamid/teamname/birth/nationality
            string[] f = s.Split('/');
            id = Convert.ToInt32(f[0]);
            DriverName = f[1];
            Number = Convert.ToInt32(f[2]);
            TeamId = Convert.ToInt32(f[3]);
            TeamName = f[4];
            Born = Convert.ToDateTime(f[5]);
            Nationality = f[6];
        }
    }
}
