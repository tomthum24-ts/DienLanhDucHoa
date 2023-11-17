using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("AmThuc")]
    public class AmThuc
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        public string TenDuAn { get; set; }
        public string MoTa { get; set; }
        public string Link { get; set; }
        public string ViTri { get; set; }
        public string TongQuan { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
    }
}
