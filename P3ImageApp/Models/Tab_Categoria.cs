using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P3ImageApp.Models
{
    public partial class Tab_Categoria
    {
        public Tab_Categoria()
        {
            this.Tab_Subcategoria = new List<Tab_Subcategoria>();
        }

        public int idcategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        public virtual ICollection<Tab_Subcategoria> Tab_Subcategoria { get; set; }
    }
}
