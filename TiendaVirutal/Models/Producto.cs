﻿using System;
using System.Collections.Generic;

namespace TiendaVirutal.Models
{
    public partial class Producto
    {
        public Producto()
        {
            PedidoDetalle = new HashSet<PedidoDetalle>();
        }

        public int Id { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdMarca { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string Url { get; set; }
        public bool? Destacado { get; set; }
        public bool? Activo { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
