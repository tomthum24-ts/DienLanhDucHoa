
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EF
{
    [Table("CongTyQuanLy")]
    public class CongTyQuanLy
    {
        public int Id { get; set; }
        public string TenCongTy { get; set; }
        public string GhiChu { get; set; }
        public bool Status { get; set; }
        public int? STT { get; set; }
    }
}
