using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Models
{
    public class Result
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
