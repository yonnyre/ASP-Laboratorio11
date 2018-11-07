using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace laboratorio_11.Models
{
    public class Categoria
    {

        [Key]
        [Display(Name = "Codigo de la Categoria")]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCategoria { get; set; }

        [Display(Name = "Descripcion")]
        public string DescripcionCategoria { get; set; }

        [Display(Name = "Imagen")]
        public string Imagen { get; set; }


        public virtual ICollection<ProductoModel> Productos { get; set; }
    }
}