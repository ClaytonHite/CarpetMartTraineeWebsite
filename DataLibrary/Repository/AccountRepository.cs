using DataLibrary.DataAccessLayer;
using DataLibrary.DTOs;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;

namespace DataLibrary.Repository
{
	public class AccountRepository
	{
		public AccountDTO VerifyAccount(AccountDTO accDTO, string connectionString)
		{
			DataAccess dal = new DataAccess(connectionString);
			Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
			paramDictionary.Add("Username", accDTO.Username);
			paramDictionary.Add("Password", accDTO.Password);
            DataTable dataTable = dal.VerifyAccountViaStoredProcedure("spVerifyAccount", paramDictionary);
			return ConvertDataTableToDTO(dataTable);
        }
		public List<AccountDTO> ConvertObjectListToDTO(List<object> dataObjects)
		{
			List<AccountDTO> accDTOs = new List<AccountDTO>();

			foreach(object[] obj in dataObjects)
			{
				AccountDTO accountDTO = new AccountDTO();
				accountDTO.Id = Convert.ToInt32(obj[0]);
				accountDTO.Username = obj[1].ToString();
				accountDTO.Password = obj[2].ToString();
				accountDTO.AccessRights = Convert.ToInt32(obj[3]);
			}
			return accDTOs;
		}
		public AccountDTO ConvertDataTableToDTO(DataTable dataTable)
		{
			AccountDTO accDTO = new AccountDTO();
			foreach(DataRow row in dataTable.Rows)
			{
				accDTO.Id = Convert.ToInt32(row["Id"]);
				accDTO.Username = row["Username"].ToString();
                accDTO.Password = row["Password"].ToString();
				accDTO.AccessRights = Convert.ToInt32(row["AccessRights"]);
            }
			return accDTO;
		}

    }
}
