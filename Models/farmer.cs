namespace Gurleen200356784.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class farmer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int farmerid { get; set; }

        [Required]
        [StringLength(50)]
        public string farmername { get; set; }

        public int cropid { get; set; }

        public virtual crop crop { get; set; }
    }
}
