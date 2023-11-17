using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class DuAnAdminModel
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string TenDuAn { get; set; }
        public string MoTa { get; set; }
        public string Link { get; set; }
        public string ViTri { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public int? LoaiDuAn { get; set; }
        public string TienIch { get; set; }
        public string TongQuan { get; set; }
        public string VitriImage { get; set; }
        public string TongQuanImage { get; set; }
    }

}
