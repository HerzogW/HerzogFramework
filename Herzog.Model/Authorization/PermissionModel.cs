using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herzog.Model.Authorization
{
    [Table("Permission")]
    public class PermissionModel
    {
        [Key]
        public string Id { get; set; }

        public string PermissionCode { get; set; }

        public string PermissionDescription { get; set; }
    }
}
