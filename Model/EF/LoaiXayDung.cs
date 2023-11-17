using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.EF
{
    [Table("LoaiXayDung")]
    public class LoaiXayDung
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string TenLoaiDuAn { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Đường dẫn")]
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool Status { get; set; }
        public string SeoTitle { get; set; }
        public int? Stt { get; set; }
        [Display(Name = "Chi tiết")]
        
        public string NoiDung { get; set; }
        public string Image { get; set; }
        public string Mota { get; set; }
    }
}
