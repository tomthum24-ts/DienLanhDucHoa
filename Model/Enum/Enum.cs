using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enum
{

    public enum EnumTrangThai
    {
        TrangThai= 1
    }
    public enum EnumLinhVuc
    {
        TrangChu = 4
    }
    public enum EnumSuggestNew { 
        New_ChiTiet_suggest= 5,
    }
    public enum EnumManHinh
    {
        TrangChu = 1,
        DuAn=2,
        TinTuc=3,
        HoiDongQuanTri=4,
        NhanSuQuanLy=5,
        TuyenDung=6,
        GioiThieu=7,
        XayDung=8,
        AmThuc=9,

    }
    public enum EnumQuanLy
    {
        ChuTich = 1,
        GiamDocKhoi = 2,
        BanDieuHanh = 3,
        ThanhVien=4,

    }
    public enum EnumCongTy
    {
        Land = 1,
        Food = 2,
        Construct = 3,

    }
    public class LinkConstants
    {
        public const string SanPham = "san-pham";
        public const string LoaiSanPham = "loai-san-pham";
        public const string DuAn = "du-an";
        public const string LoaiDuAn = "loai-du-an";
        public const string LoaiDichVu = "loai-dich-vu";
        public const string DichVu = "dich-vu";
        public const string LoaiTinTuc = "loai-bai-viet";
        public const string TinTuc = "bai-viet";
    }
}
