using DataLibrary.DataAccessLayer;
using DataLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLibrary.Repository
{
    public class RegisteredClassesRepository : IRegisteredClassesRepository
    {
        private string _connectionString;
        public RegisteredClassesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<RegisteredClassesDTO> GetListOfTraineesForClass(string className)
        {
            DataAccess dal = new DataAccess(_connectionString);
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("ClassName", className);
            DataTable dataTable = dal.PopulateDataTableViaStoredProcedure("spGetListOfTraineesForClasses", paramDictionary);
            return ConvertDataTableToDTO(dataTable);
        }
        public List<RegisteredClassesDTO> ConvertDataTableToDTO(DataTable dataTable)
        {
            List<RegisteredClassesDTO> rCDTOList = new List<RegisteredClassesDTO>();
            List<UserDTO> uDTOList = new List<UserDTO>();
            RegisteredClassesDTO rCDTO = new RegisteredClassesDTO();
            rCDTO.userDTOList = uDTOList;
            int classIdentifier = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                ClassDTO classDTO = new ClassDTO();
                classDTO.ClassName = row["ClassName"].ToString();
                classDTO.ClassStartDate = row["ClassStartDate"].ToString();
                classDTO.ClassEndDate = row["ClassEndDate"].ToString();
                classDTO.ClassStartTime = row["ClassStartTime"].ToString();
                classDTO.ClassEndTime = row["ClassEndTime"].ToString();
                classDTO.ClassInformation = row["ClassInformation"].ToString();
                classDTO.ClassHost = row["ClassHost"].ToString();
                classDTO.ClassAddress = row["ClassAddress"].ToString();

                if(classIdentifier != classDTO.ClassId)
                {
                    rCDTOList.Add(rCDTO);
                    rCDTO = new RegisteredClassesDTO();
                    uDTOList = new List<UserDTO>();
                    rCDTO.userDTOList = uDTOList;
                    classIdentifier = classDTO.ClassId;
                    rCDTO.classDTO = classDTO;
                }

                UserDTO uDTO = new UserDTO();
                uDTO.Id = Convert.ToInt32(row["Id"]);
                uDTO.MSId = row["MSId"].ToString();
                uDTO.FirstName = row["FirstName"].ToString();
                uDTO.MiddleName = row["MiddleName"].ToString();
                uDTO.LastName = row["LastName"].ToString();
                uDTO.AddressLine1 = row["AddressLine1"].ToString();
                uDTO.AddressLine2 = row["AddressLine2"].ToString();
                uDTO.City = row["City"].ToString();
                uDTO.State = row["State"].ToString();
                uDTO.Zip = row["Zip"].ToString();
                uDTO.Phone = row["Phone"].ToString();
                uDTO.Email = row["Email"].ToString();

                rCDTO.userDTOList.Add(uDTO);
                rCDTO.classDTO = classDTO;
                rCDTOList.Add(rCDTO);
            }

            return rCDTOList;
        }
    }
}
