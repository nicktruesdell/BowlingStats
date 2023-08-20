using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int Points { get; set; }
        public int Spares { get; set; }
        public int Strikes { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public Score()
        {
        }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
