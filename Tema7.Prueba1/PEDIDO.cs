//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tema7.Prueba1
{
    using System;
    using System.Collections.Generic;
    
    public partial class PEDIDO
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fecha_pedido { get; set; }
        public Nullable<int> numero_articulos { get; set; }
        public Nullable<decimal> importe { get; set; }
        public Nullable<int> cliente { get; set; }
        public Nullable<int> enviado { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
    }
}
