using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("DoiTac")]
    public class DoiTac
    {
        public int Id { get; set; }
        public string TenDoiTac { get; set; }
        public string HinhAnh { get; set; }
        public string Link { get; set; }
        public bool Status { get; set; }
    }
}
