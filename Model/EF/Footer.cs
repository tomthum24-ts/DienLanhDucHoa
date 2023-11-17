namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        public int ID { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Hotline { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public string DiaChi { get; set; }
    }
}
