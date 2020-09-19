using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diamond.Models
{
    public class Categoria
    {

        public int ID { get; set; }
        public string nome { get; set; }
        public int responsabile_ID { get; set; }
    }
}
