namespace DatabasaProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class kymdan_Users
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Uid { get; set; }

        [Required]
        [StringLength(50)]
        public string Pwd { get; set; }

        [Required]
        [StringLength(100)]
        public string Fullname { get; set; }
    }
}
