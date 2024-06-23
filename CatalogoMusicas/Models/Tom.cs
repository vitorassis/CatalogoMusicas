using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoMusicas.Models
{
    public class Tom
    {
        public int Id { get; set; }
        public int MusicaId { get; set; }
        public string Tonalidade { get; set; }
    }
}
