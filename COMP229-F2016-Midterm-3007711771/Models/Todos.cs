namespace COMP229_F2016_Midterm_3007711771.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Todos
    {
        [Key]
        public int TodoID { get; set; }

        [Required]
        [StringLength(50)]
        public string TodoDescirption { get; set; }

        public string TodoNotes { get; set; }

        public bool Completed { get; set; }
    }
}
