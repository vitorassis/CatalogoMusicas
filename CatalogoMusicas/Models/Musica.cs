using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoMusicas.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Indice { get; set; }
        public int PastaId { get; set; }
        public virtual List<Tom> Tons { get; set; } = new List<Tom>();
    }
}
