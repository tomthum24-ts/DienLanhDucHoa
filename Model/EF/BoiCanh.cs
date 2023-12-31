﻿namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoiCanh")]
    public partial class BoiCanh
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int DisplayOrder { get; set; }
        public string NoiDung { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public string Classmain { get; set; }
        public int IdDuAn { get; set; }
        public string Title { get; set; }
    }
}
