﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Model
{
    [Table("TabEntity")]
    public class TestEntity
    {
        [Key]
        public string Id { get; set; }

        [Column("UserName")]
        public string Name { get; set; }
    }
}
