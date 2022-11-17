using DataLibrary.DTOs;
using DataLibrary.Repository;

namespace WebsiteProject.Tests
{
    public class FakeUserRepository : IUserRepository
    {
        public List<UserDTO> userDTOList = new List<UserDTO>();
        public UserDTO AddUserProfile(UserDTO user)
        {
            userDTOList.Add(user);
            return user;
        }

        public UserDTO CheckExistingProfile(string id)
        {
            return userDTOList.FirstOrDefault(user => user.MSId == id);            
        }

        public UserDTO ConvertDataTableToDTO(System.Data.DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> ConvertDataTableToDTOList(System.Data.DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public int DeleteProfile(string MSId)
        {
            var user = CheckExistingProfile(MSId);
            if(user == null)
            {
                return 0;
            }
            userDTOList.Remove(user);
            return 1;
        }

        public List<UserDTO> RegisteredUsersForClassList(string className)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUserProfile(UserDTO user)
        {
            DeleteProfile(user.MSId);
            AddUserProfile(user);
            return user;
        }
    }
}
