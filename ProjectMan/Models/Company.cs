namespace ProjectMan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            Project = new HashSet<Project>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string adress { get; set; }

        [Required]
        [StringLength(150)]
        public string billedto { get; set; }

        [Required]
        [StringLength(50)]
        public string contactname { get; set; }

        [Required]
        [StringLength(50)]
        public string contactemail { get; set; }

        [Required]
        [StringLength(50)]
        public string cantacttel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }
    }
}
