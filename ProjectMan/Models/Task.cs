namespace ProjectMan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime startdateplanned { get; set; }

        [Column(TypeName = "date")]
        public DateTime enddateplanned { get; set; }

        [Column(TypeName = "date")]
        public DateTime startdateactual { get; set; }

        [Column(TypeName = "date")]
        public DateTime enddateactual { get; set; }

        public short progress { get; set; }

        public int project { get; set; }

        public int milestone { get; set; }

        public int assingto { get; set; }

        public virtual Milestone Milestone1 { get; set; }

        public virtual Project Project1 { get; set; }

        public virtual User User { get; set; }
    }
}
