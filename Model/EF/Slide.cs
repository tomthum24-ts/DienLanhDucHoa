namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [Display(Name = "hinh anh")]
        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Thu tu")]
        public int? DisplayOrder { get; set; }
        [Display(Name = "duong dan")]
        [StringLength(250)]
        public string Link { get; set; }
        [Display(Name = "Mo ta")]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [Display(Name = "Hien thi")]
        public bool Status { get; set; }
        [StringLength(50)]
        public string Classmain { get; set; }
        public int? IDCategory { get; set; }
        [Display(Name = "Noi dung")]
        public string NoiDung { get; set; }
        public string Title { get; set; }
        public int? IdManHinh { get; set; }
        public string TenManHinh { get; set; }
    }
}
