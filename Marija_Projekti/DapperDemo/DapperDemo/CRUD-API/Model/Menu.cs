using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Model
{
    public class Menu
    {
        [Key]
        public int IDMenu { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }

    }
}
