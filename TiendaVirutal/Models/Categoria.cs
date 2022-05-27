using System;
using System.Collections.Generic;

namespace TiendaVirutal.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
