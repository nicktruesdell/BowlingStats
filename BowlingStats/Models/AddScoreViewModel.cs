using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingStats.Models
{
    public class AddScoreViewModel
    {
        public int Points { get; set; }
        public int Spares { get; set; }
        public int Strikes { get; set; }
        public int GameId { get; set; }
        [Display(Name = "Player")]
        public int PlayerId { get; set; }
    }
}
