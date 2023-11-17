using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("XayDung")]
    public class XayDung
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string TenDuAn { get; set; }
        public string MoTa { get; set; }
        public string Link { get; set; }
        public string ViTri { get; set; }
        public string VitriImage { get; set; }
        public int PhoiCanh { get; set; }
        public string TongQuan { get; set; }
        public int LoaiDuAn { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Đường dẫn không được để trống")]
        [Display(Name = "Đường dẫn")]
        public string MetaTitle { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string TienIch { get; set; }
        public string TongQuanImage { get; set; }
        public int PhanLoai { get; set; }
    }
}
