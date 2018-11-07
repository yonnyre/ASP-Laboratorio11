using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using laboratorio_11.Models;

namespace laboratorio_11.Models
{
    public class Proveedor
    {
        [Key]
        [Display(Name = "Codigo del Proveedor")]
        public int IdProveedor { get; set; }

        [Display(Name = "Nombre de la Compañia")]
        [Required(ErrorMessage = "El campo {0} es oblicagorio")]
        public string NombreCompañia { get; set; }

        [Display(Name = "Nombre del Contacto")]
        public string NombreContacto { get; set; }

        [Display(Name = "Cargo del Contacto")]
        public string CargoContacto { get; set; }

        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        public virtual ICollection<ProductoModel> Productos { get; set; }
    }
}