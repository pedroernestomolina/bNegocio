//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibEntitySistema
{
    using System;
    using System.Collections.Generic;
    
    public partial class productos_hnd_precio
    {
        public string autoProducto { get; set; }
        public string autoMedida_1 { get; set; }
        public string autoMedida_2 { get; set; }
        public string autoMedida_3 { get; set; }
        public int contenido_1 { get; set; }
        public int contenido_2 { get; set; }
        public int contenido_3 { get; set; }
        public decimal neto_1 { get; set; }
        public decimal neto_2 { get; set; }
        public decimal neto_3 { get; set; }
        public decimal utilidad_1 { get; set; }
        public decimal utilidad_2 { get; set; }
        public decimal utilidad_3 { get; set; }
        public decimal fullDivisa_1 { get; set; }
        public decimal fullDivisa_2 { get; set; }
        public decimal fullDivisa_3 { get; set; }
        public int idEmpresaPrecio { get; set; }
    
        public virtual empresa_hnd_precios empresa_hnd_precios { get; set; }
        public virtual productos productos { get; set; }
    }
}
