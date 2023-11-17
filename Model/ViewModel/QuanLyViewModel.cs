
namespace Model.ViewModel
{
    public class QuanLyViewModel
    {
        public int ID { get; set; }
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
        public string TenCongTy { get; set; }
    }
}
