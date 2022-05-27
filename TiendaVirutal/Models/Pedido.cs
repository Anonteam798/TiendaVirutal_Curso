using System;
using System.Collections.Generic;

namespace TiendaVirutal.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoDetalle = new HashSet<PedidoDetalle>();
        }

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTarjeta { get; set; }
        public DateTime? FechaHora { get; set; }
        public string Estado { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Tarjeta IdTarjetaNavigation { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
