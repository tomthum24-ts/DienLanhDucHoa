using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("LoaiDuAn")]
    public class LoaiDuAn
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenLoaiDuAn { get; set; }
        [Required(ErrorMessage = "Đường dẫn không được để trống")]
        [Display(Name = "Đường dẫn")]
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool Status { get; set; }
        public string SeoTitle { get; set; }
        [Display(Name = "Số thứ tự")]
        public int? Stt { get; set; }
    }
}
