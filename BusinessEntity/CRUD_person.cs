using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class CRUD_person
    {
        public int id { get; set; }
        public string family { get; set; }
        public string rdate { get; set; }
        public string rtime { get; set; }

    }
    public class patient : CRUD_person
    {
        public string name { get; set; }
        public int code { get; set; }
        public string Birthday { get; set; }
        public string tel { get; set; }
        [Required]
        public doctor doctor { get; set; }
        
    }
    public class doctor : CRUD_person
    {
        
        public patient patient { get; set; }
        public string field { get; set; }


    }


}
