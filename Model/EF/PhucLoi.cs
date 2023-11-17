using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("PhucLoi")]
    public partial class PhucLoi
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        public string NoiDung { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsPhucLoi { get; set; }
    }
}
