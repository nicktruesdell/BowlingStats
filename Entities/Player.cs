using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public Player()
        {
            Scores = new HashSet<Score>();
        }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
