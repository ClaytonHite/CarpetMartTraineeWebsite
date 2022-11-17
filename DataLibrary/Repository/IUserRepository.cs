using DataLibrary.DTOs;
using System.Data;

namespace DataLibrary.Repository
{
    public interface IUserRepository
    {
        UserDTO AddUserProfile(UserDTO user);
        UserDTO CheckExistingProfile(string id);
        UserDTO ConvertDataTableToDTO(DataTable dataTable);
        List<UserDTO> ConvertDataTableToDTOList(DataTable dataTable);
        int DeleteProfile(string MSId);
        UserDTO UpdateUserProfile(UserDTO user);
    }
}