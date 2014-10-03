using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P3ImageApp.Models
{
    public partial class Tab_Campo
    {
        public int idcampo { get; set; }

        [Required]
        public int idsubcategoria { get; set; }

        [Required]
        public int ordem { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo { get; set; }

        public string lista { get; set; }
        public virtual Tab_Subcategoria Tab_Subcategoria { get; set; }
    }
}
