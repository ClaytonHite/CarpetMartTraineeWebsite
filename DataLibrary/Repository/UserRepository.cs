using DataLibrary.DataAccessLayer;
using DataLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public class UserRepository
    {
        public UserDTO CheckExistingProfile(string id, string connString)
        {
            DataAccess dal = new DataAccess(connString);
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("Id", id);
            DataTable dataTable = dal.PopulateDataTableViaStoredProcedure("spCheckExistingProfile", paramDictionary);
            return ConvertDataTableToDTO(dataTable);
        }
        public UserDTO ConvertDataTableToDTO(DataTable dataTable)
        {
            UserDTO uDTO = new UserDTO();
            foreach (DataRow row in dataTable.Rows)
            {
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
            }
            return uDTO;
        }
    }
}
