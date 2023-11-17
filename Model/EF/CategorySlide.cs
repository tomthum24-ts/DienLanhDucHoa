using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("CategorySlide")]
    public class CategorySlide
    {
        public int Id { get; set; }
        public string TenLoaiSlide { get; set; }
        public bool Status { get; set; }
    }
}
