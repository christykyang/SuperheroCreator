using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroCreator.Models
{
    public class Superhero
    {
        public int SuperheroId { get; set; }
        public string Name { get; set; }
        public string AlterEgoName { get; set; }
        public string PrimarySuperpower { get; set; }
        public string SecondarySuperpower { get; set; }
        public string CatchPhrase { get; set; }
    }
}
