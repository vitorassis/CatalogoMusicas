using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoMusicas.Models
{
    public class Pasta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Musica> Musicas { get; set; } = new(); 
    }
}
