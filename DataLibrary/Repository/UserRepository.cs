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
            paramDictionary.Add("MSId", id);
            DataTable dataTable = dal.PopulateDataTableViaStoredProcedure("spCheckExistingProfile", paramDictionary);
            return ConvertDataTableToDTO(dataTable);
        }
        public UserDTO AddUserProfile(UserDTO user, string connString)
        {
			DataAccess dal = new DataAccess(connString);
			Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
			paramDictionary.Add("MSId", user.MSId);
			paramDictionary.Add("FirstName", user.FirstName);
			paramDictionary.Add("MiddleName", user.MiddleName);
			paramDictionary.Add("LastName", user.LastName);
			paramDictionary.Add("AddressLine1", user.AddressLine1);
            if (user.AddressLine2 != null)
            {
                paramDictionary.Add("AddressLine2", user.AddressLine2);
            }
            else
            {
				paramDictionary.Add("AddressLine2", " ");
			}
			paramDictionary.Add("City", user.City);
			paramDictionary.Add("State", user.State);
			paramDictionary.Add("Zip", user.Zip);
			paramDictionary.Add("Phone", user.Phone);
			paramDictionary.Add("Email", user.Email);
			DataTable dataTable = dal.PopulateDataTableViaStoredProcedure("spAddUserProfile", paramDictionary);
			return ConvertDataTableToDTO(dataTable);
		}
		public UserDTO UpdateUserProfile(UserDTO user, string connString)
        {
			DataAccess dal = new DataAccess(connString);
			Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
			paramDictionary.Add("MSId", user.MSId);
			paramDictionary.Add("FirstName", user.FirstName);
			paramDictionary.Add("MiddleName", user.MiddleName);
			paramDictionary.Add("LastName", user.LastName);
			paramDictionary.Add("AddressLine1", user.AddressLine1);
			if (user.AddressLine2 != null)
			{
				paramDictionary.Add("AddressLine2", user.AddressLine2);
			}
			else
			{
				paramDictionary.Add("AddressLine2", " ");
			}
			paramDictionary.Add("City", user.City);
			paramDictionary.Add("State", user.State);
			paramDictionary.Add("Zip", user.Zip);
			paramDictionary.Add("Phone", user.Phone);
			paramDictionary.Add("Email", user.Email);
			DataTable dataTable = dal.PopulateDataTableViaStoredProcedure("spUpdateUserProfile", paramDictionary);
			return ConvertDataTableToDTO(dataTable);
		}
		public int DeleteProfile(string MSId, string connString)
		{
            DataAccess dal = new DataAccess(connString);
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("MSId", MSId);
            DataTable dataTable = dal.PopulateDataTableViaStoredProcedure("spUpdateUserProfile", paramDictionary);
            return Convert.ToInt32(dal.DeleteDataViaStoredProcedure("spDeleteUserProfile", paramDictionary));
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
