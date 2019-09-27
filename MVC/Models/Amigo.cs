using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Amigo
    {
        [Key]
        [Display(Name = "ID")]
        public int idamigo { set; get; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se necesita un nombre.")]
        public string nombre { set; get; }

        [Display(Name = "Cumpleaños")]
        public DateTime fecnac { set; get; }

        [Display(Name = "Direccion")]
        public string direccion { set; get; }

        [Display(Name = "Telefono")]
        public string telefono { set; get; }
    }
}