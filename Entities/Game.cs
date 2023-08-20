using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string? Notes { get; set; }

        public Game()
        {
        }

        public virtual IList<Score> Scores { get; set; }
    }
}
