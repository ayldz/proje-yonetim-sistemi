namespace ProjectMan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string icon { get; set; }

        [Required]
        [StringLength(50)]
        public string text { get; set; }

        [Required]
        [StringLength(50)]
        public string controller { get; set; }

        [Required]
        [StringLength(50)]
        public string action { get; set; }
    }
}
