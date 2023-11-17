using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("PhanLoaiQuanLy")]
    public class PhanLoaiQuanLy
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string TenPhanLoai { get; set; }
        public bool Status { get; set; }
    }
}
