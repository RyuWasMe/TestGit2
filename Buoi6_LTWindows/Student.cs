namespace Buoi6_LTWindows
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [StringLength(10)]
        public string StudentID { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Faculty { get; set; }

        public double? AvrScore { get; set; }
    }
}
