using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("QuanLy")]
    public class QuanLy
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        public int? IdPhanLoai { get; set; }
        public string TenChucVu { get; set; }
        public bool GioiTinh { get; set; } = true;
        public string LoiNgo { get; set; }
        public string ChiTiet { get; set; }
        public string Avata { get; set; }
        public bool Status { get; set; }
        public int? STT { get; set; }
        public int? IdCongTy { get; set; }
    }
}
