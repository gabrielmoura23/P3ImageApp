using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P3ImageApp.Models
{
    public partial class Tab_Subcategoria
    {
        public Tab_Subcategoria()
        {
            this.Tab_Campo = new List<Tab_Campo>();
        }

        public int idsubcategoria { get; set; }

        [Required]
        public int idcategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        public virtual ICollection<Tab_Campo> Tab_Campo { get; set; }
        public virtual Tab_Categoria Tab_Categoria { get; set; }
    }
}
