using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("ViTriTuyenDung")]
    public class ViTriTuyenDung
    {
        public int Id { get; set; }
        public string TenViTri { get; set; }
        public int SoLuong { get; set; }
        public string DiaDiem { get; set; }
        public DateTime HanNop { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}
