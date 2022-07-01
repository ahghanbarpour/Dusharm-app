using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.ViewModels
{
    public class DoctorViewModel
    {
        public string family { get; set; }
        public string rdate { get; set; }
        public string rtime { get; set; }
        public patient patient { get; set; }
        public string field { get; set; }
    }
}
