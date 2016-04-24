namespace ProjectMan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        internal DateTime startDateActual;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Milestone = new HashSet<Milestone>();
            Task = new HashSet<Task>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime startdateplanned { get; set; }

        [Column(TypeName = "date")]
        public DateTime enddateplanned { get; set; }

        [Column(TypeName = "date")]
        public DateTime stardateactual { get; set; }

        [Column(TypeName = "date")]
        public DateTime enddateactual { get; set; }

        public short progress { get; set; }

        public int company { get; set; }

        public int projectmanager { get; set; }

        public virtual Company Company1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Milestone> Milestone { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Task { get; set; }
    }
}
