namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotLine")]
    public partial class HotLine
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Đường dẫn")]
        public string Link { get; set; }
        public string GhiChu { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public bool IsChat { get; set; }
    }
}
