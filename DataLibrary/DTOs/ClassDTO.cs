using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DTOs
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassStartDate { get; set; }
        public string ClassEndDate { get; set; }
        public string ClassStartTime { get; set; }
        public string ClassEndTime { get; set; }
        public string ClassInformation { get; set; }
        public string ClassHost { get; set; }
        public string ClassAddress { get; set; }
    }
}
