namespace Gurleen200356784.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crop()
        {
            farmers = new HashSet<farmer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cropid { get; set; }

        [Required]
        [StringLength(50)]
        public string cropname { get; set; }

        public byte seasonal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<farmer> farmers { get; set; }
    }
}
