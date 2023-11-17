using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("linhVucHoatDong")]
    public class LinhVucHoatDong
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Đường dẫn")]
        public string MetaTitle { get; set; }
        public string NoiDung { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int Stt { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
