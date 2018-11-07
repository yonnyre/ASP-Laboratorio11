using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace laboratorio_11.Models
{
    public class ProductoModel
    {
        [Display(Name = "Id")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "Nombre requerido")]
        public string NombreProducto { get; set; }

        [Display(Name = "Codigo de Proveedor")]
        public int IdProveedor { get; set; }

        [Display(Name = "Codigo de Categoria")]
        public int IdCategoria { get; set; }

        [Display(Name = "Cantidad por Unidad")]
        [Required(ErrorMessage = "Cantidad requerido")]
        public string CantidadPorUnidad { get; set; }

        [Display(Name = "Precio Unidad")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioUnidad { get; set; }

        [Display(Name = "Unidades Existentes")]
        public int UnidadesEnExistencia { get; set; }

        [Display(Name = "Unidades en Pedido")]
        public int UnidadesEnPedido { get; set; }

        [Display(Name = "Nuevo Pedido")]
        public int NivelNuevoPedido { get; set; }

        [Display(Name = "Suspendido")]
        public bool Suspendido { get; set; }
        
    }
}