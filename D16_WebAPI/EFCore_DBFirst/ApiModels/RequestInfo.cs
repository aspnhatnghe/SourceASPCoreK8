using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_DBFirst.ApiModels
{
    public class RequestInfo
    {
        [Required]
        [MinLength(2)]
        public string Value { get; set; }
    }
}
