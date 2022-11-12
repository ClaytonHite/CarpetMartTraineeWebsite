using DataLibrary.DTOs;
using DataLibrary.Repository;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.BusinessLogic
{
    public class UserBL
    {
        public UserViewModel CheckExistingProfile(string id)
        {
            string connString = Config.GetConnectionString("DefaultConnection");
            UserRepository userRepository = new UserRepository();
            UserDTO userDTO = userRepository.CheckExistingProfile(id, connString);
            UserModel userModel = ConvertDTOToModel(userDTO);
            return ConvertModelToViewModel(userModel);
        }
        public UserViewModel UpdateUserInfo(UserViewModel uvm)
        {
            return uvm;
        }
        public UserModel ConvertDTOToModel(UserDTO uDTO)
        {
            UserModel userModel = new UserModel();
            userModel.Id = uDTO.Id;
            userModel.MSId = uDTO.MSId;
            userModel.FirstName = uDTO.FirstName;
            userModel.MiddleName = uDTO.MiddleName;
            userModel.LastName = uDTO.LastName;
            userModel.AddressLine1 = uDTO.AddressLine1;
            userModel.AddressLine2 = uDTO.AddressLine2;
            userModel.City = uDTO.City;
            userModel.State = uDTO.State;
            userModel.Zip = uDTO.Zip;
            userModel.Phone = userModel.Phone;
            userModel.Email = uDTO.Email;
            return userModel;
        }
        public UserViewModel ConvertModelToViewModel(UserModel uM)
        {
            UserViewModel uVModel = new UserViewModel();
            uVModel.FirstName = uM.FirstName;
            uVModel.MiddleName = uM.MiddleName;
            uVModel.LastName = uM.LastName;
            uVModel.AddressLine1 = uM.AddressLine1;
            uVModel.AddressLine2 = uM.AddressLine2;
            uVModel.City = uM.City;
            uVModel.State = uM.State;
            uVModel.Zip = uM.Zip;
            uVModel.Phone = uM.Phone;
            uVModel.Email = uM.Email;
            return uVModel;
        }
    }
}
