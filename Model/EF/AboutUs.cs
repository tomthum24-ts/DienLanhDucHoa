﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("AboutUs")]
    public partial class AboutUs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public string GhiChu { get; set; }
    }
}
