using System;
using System.Collections.Generic;

namespace TiendaVirutal.Models
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
