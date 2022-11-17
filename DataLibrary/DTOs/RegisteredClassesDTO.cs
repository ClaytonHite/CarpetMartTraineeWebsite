using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DTOs
{
    public class RegisteredClassesDTO
    {
        public ClassDTO classDTO { get; set; }
        public List<UserDTO> userDTOList { get; set; }
    }
}
