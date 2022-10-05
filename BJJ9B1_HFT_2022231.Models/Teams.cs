using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Models
{
    class Teams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public int Ranking { get; set; }
        [StringLength(240)]
        public string TeamName { get; set; }
        public DateTime Created { get; set; }
        public int ConstructorPoints { get; set; }
        public DateTime FirstWin { get; set; }
        public Guid TeamPrincipalId { get; set; }
        public string TitleSponsor { get; set; }

    }
}
